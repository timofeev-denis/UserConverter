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

namespace UserConverter {
    public partial class MainForm : Form {
        private OracleConnection conn;
        private OracleCommand cmd;
        private OracleTransaction transaction;
        private OracleDataReader dr;

        public MainForm() {
            InitializeComponent();
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
            cmd.CommandText = "SELECT l_name from akriko.cat_executors WHERE id in (SELECT distinct(ispolnitel_cik_id) FROM akriko.appeal)";
            try {
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    if (dr.IsDBNull(0)) {
                        MessageBox.Show("При чтении данных из базы данных произошла ошибка:\n\n" + e.Message);
                        break;
                    }

                }
            } catch (Exception e) {
                MessageBox.Show("При чтении данных из базы данных произошла ошибка:\n\n" + e.Message);
            }

            ((DataGridViewComboBoxColumn)UsersGrid.Columns["delo"]).Items.Add("22221");
            ((DataGridViewComboBoxColumn)UsersGrid.Columns["delo"]).Items.Add("22222");
            ((DataGridViewComboBoxColumn)UsersGrid.Columns["delo"]).Items.Add("22223");

            UsersGrid.Rows.Add();
            UsersGrid.Rows[0].Cells["akriko"].Value = "Вася";
            UsersGrid.Rows.Add();
            UsersGrid.Rows[1].Cells["akriko"].Value = "Петя";
            UsersGrid.Rows.Add();
            UsersGrid.Rows[2].Cells["akriko"].Value = "Саша";
            return true;
        }
    }
}
