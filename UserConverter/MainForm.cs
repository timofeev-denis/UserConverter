using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.IO;

namespace UserConverter {
    public partial class MainForm : Form {
        private OracleConnection conn;
        private OracleCommand cmd;
        private OracleTransaction transaction;
        private OracleDataReader dr;
        private Dictionary<string, DeloPerson> DeloPersons = new Dictionary<string,DeloPerson>();
        private DateTime ConvertDate = DateTime.Now;
        private string LogFileName = "";

        public MainForm() {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            CenterToScreen();
        }
        private string GetConnectionString() {
            string DBName = "RA00C000";
            string DBUser = "voshod";
            string DBPass = "voshod";
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 3) {
                DBName = args[1];
                DBUser = args[2];
                DBPass = args[3];
            }
            return "Data Source=" + DBName + ";User Id=" + DBUser + ";Password=" + DBPass + ";";
        }
        public bool Fill() {
            try {
                conn = new OracleConnection(GetConnectionString());
                conn.Open();
                transaction = conn.BeginTransaction();
            } catch (Exception e) {
                MessageBox.Show("При подключении к базе данных произошла ошибка:\n\n" + e.Message);
                conn.Close();
                conn.Dispose();
                return false;
            }

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT TO_CHAR(id), l_name from akriko.cat_executors WHERE id in (SELECT distinct(ispolnitel_cik_id) FROM akriko.appeal) ORDER BY UPPER(l_name)";
            try {
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    if (dr.IsDBNull(0) || dr.IsDBNull(1)) {
                        MessageBox.Show("При чтении данных из базы данных произошла ошибка:\n\n");
                        break;
                    } else {
                        UsersGrid.Rows.Add();
                        UsersGrid.Rows[UsersGrid.Rows.Count - 1].Cells["executor_id"].Value = dr.GetString(0);
                        UsersGrid.Rows[UsersGrid.Rows.Count - 1].Cells["akriko"].Value = dr.GetString(1);
                    }

                }
                dr.Close();
                dr.Dispose();
            } catch (Exception e) {
                MessageBox.Show("При чтении данных из базы данных произошла ошибка:\n\n" + e.Message);
            }
            if (UsersGrid.Rows.Count == 0) {
                MessageBox.Show("Отсутствуют неотконвертированные исполнители", "Конвертация исполнителей", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConvertButton.Enabled = false;
            }
            FillDeloDepartmentsColumn();
            return true;
        }
        private void FillDeloPersonsColumn() { 
        }
        private void FillDeloDepartmentsColumn() {
            ((DataGridViewComboBoxColumn)UsersGrid.Columns["delo"]).Items.Add("");
            cmd = conn.CreateCommand();
            cmd.CommandText = "select SUBSTR(p.due, 0, INSTR(p.due, '.', 3 )) departmentCode, p.due personCode, (SELECT d.classif_name FROM department d WHERE d.due = SUBSTR(p.due, 0, INSTR(p.due, '.', 3 ))) departmentName, classif_name from department p where DELETED=0 and due != '0.' order by due";
            try {
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    if (!dr.IsDBNull(0)) {
                        ((DataGridViewComboBoxColumn)UsersGrid.Columns["delo"]).Items.Add(dr.GetString(3));
                        DeloPersons[dr.GetString(3)] = new DeloPerson(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3));
                    }
                }
                
            } catch (Exception e) {
                MessageBox.Show("При чтении данных о подразделениях из базы данных произошла ошибка:\n\n" + e.Message);
            }
            if (dr != null) {
                dr.Close();
                dr.Dispose();
            }
            if (cmd != null) {
                cmd.Dispose();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            conn.Close();
            conn.Dispose();
        }
        void Log(string appeal_id, string executor_id) {
            if (this.LogFileName == "") {
                this.LogFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Conversion-" + this.ConvertDate.ToString("yyyy-MM-dd-HH-mm-ss") + ".log");
            }
            File.AppendAllText(this.LogFileName, appeal_id + ";" + executor_id + "\r\n");
        }
        void Backup(string executor_id) {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select TO_CHAR(id) from akriko.appeal WHERE ISPOLNITEL_CIK_ID=" + executor_id;
            try {
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    if (!dr.IsDBNull(0)) {
                        this.Log(dr.GetString(0), executor_id);
                    }
                }
            } catch (Exception e) {
                MessageBox.Show("При чтении данных о подразделениях из базы данных произошла ошибка:\n\n" + e.Message);
            }
            if (dr != null) {
                dr.Close();
                dr.Dispose();
            } 
            if (cmd != null) {
                cmd.Dispose();
            }

        }
        private string MakeQuery(string akrikoID, DeloPerson deloPerson) {
            return String.Format("UPDATE akriko.appeal SET ISPOLNITEL_CIK_ID=NULL, ISPOLN_DEPT_CIK_DELO='{0}', ISPOLNITEL_CIK_DELO='{1}', ISPOLN_DEPT_CIK_DELO_T='{2}', ISPOLNITEL_CIK_DELO_T='{3}' WHERE ISPOLNITEL_CIK_ID='{4}'", 
                deloPerson.GetDepartmentID(), deloPerson.GetPersonID(), deloPerson.GetDepartmentName(), deloPerson.GetPersonName(), akrikoID );
        }
        private bool UpdateExecutors(string executor_id, DeloPerson deloPerson) {
            bool result = false;
            cmd = conn.CreateCommand();
            cmd.CommandText = MakeQuery(executor_id, deloPerson);
            System.Diagnostics.Trace.WriteLine(cmd.CommandText);
            try {
                cmd.ExecuteNonQuery();
                result = true;
            } catch (Exception e) {
                MessageBox.Show("При записи информации об исполнителях в базу данных произошла ошибка:\n\n" + e.Message);
                this.transaction.Rollback();
            }
            if (cmd != null) {
                cmd.Dispose();
            }
            return result;
        }
        private void ConvertButton_Click(object sender, EventArgs e) {
            bool result = true;
            foreach(DataGridViewRow r in UsersGrid.Rows) {
                if (r.Cells["delo"].Value == null) {
                    continue;
                }
                Backup(r.Cells["executor_id"].Value.ToString());
                if (!UpdateExecutors(r.Cells["executor_id"].Value.ToString(), DeloPersons[r.Cells["delo"].Value.ToString()])) {
                    result = false;
                }
            }
            if (result) {
                this.transaction.Commit();
                MessageBox.Show("Конвертация успешно завершена", "Конвертация исполнителей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}
