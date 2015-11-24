﻿namespace UserConverter {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.UsersGrid = new System.Windows.Forms.DataGridView();
            this.executor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.akriko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.departmentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConvertButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersGrid
            // 
            this.UsersGrid.AllowUserToAddRows = false;
            this.UsersGrid.AllowUserToDeleteRows = false;
            this.UsersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.executor_id,
            this.akriko,
            this.delo,
            this.departmentCode,
            this.personCode,
            this.departmentName,
            this.personName});
            this.UsersGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.UsersGrid.Location = new System.Drawing.Point(0, 0);
            this.UsersGrid.Name = "UsersGrid";
            this.UsersGrid.Size = new System.Drawing.Size(947, 473);
            this.UsersGrid.TabIndex = 0;
            // 
            // executor_id
            // 
            this.executor_id.FillWeight = 10F;
            this.executor_id.HeaderText = "ID исполнителя";
            this.executor_id.Name = "executor_id";
            this.executor_id.ReadOnly = true;
            this.executor_id.Width = 50;
            // 
            // akriko
            // 
            this.akriko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.akriko.HeaderText = "Исполнители ЦИК";
            this.akriko.Name = "akriko";
            this.akriko.ReadOnly = true;
            this.akriko.Width = 150;
            // 
            // delo
            // 
            this.delo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.delo.HeaderText = "Пользователи \"Дело\"";
            this.delo.Name = "delo";
            // 
            // departmentCode
            // 
            this.departmentCode.HeaderText = "Код департамента";
            this.departmentCode.Name = "departmentCode";
            this.departmentCode.ReadOnly = true;
            // 
            // personCode
            // 
            this.personCode.HeaderText = "Код человека";
            this.personCode.Name = "personCode";
            this.personCode.ReadOnly = true;
            // 
            // departmentName
            // 
            this.departmentName.HeaderText = "Департамент";
            this.departmentName.Name = "departmentName";
            this.departmentName.ReadOnly = true;
            // 
            // personName
            // 
            this.personName.HeaderText = "Человек";
            this.personName.Name = "personName";
            this.personName.ReadOnly = true;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(836, 484);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(99, 23);
            this.ConvertButton.TabIndex = 1;
            this.ConvertButton.Text = "Конвертировать";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 519);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.UsersGrid);
            this.Name = "MainForm";
            this.Text = "Конвертация исполнителей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UsersGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn executor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn akriko;
        private System.Windows.Forms.DataGridViewComboBoxColumn delo;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn personCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn personName;
        private System.Windows.Forms.Button ConvertButton;

    }
}

