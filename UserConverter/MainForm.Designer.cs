namespace UserConverter {
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
            this.akriko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersGrid
            // 
            this.UsersGrid.AllowUserToAddRows = false;
            this.UsersGrid.AllowUserToDeleteRows = false;
            this.UsersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.akriko,
            this.delo});
            this.UsersGrid.Location = new System.Drawing.Point(12, 12);
            this.UsersGrid.Name = "UsersGrid";
            this.UsersGrid.Size = new System.Drawing.Size(556, 238);
            this.UsersGrid.TabIndex = 0;
            // 
            // akriko
            // 
            this.akriko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.akriko.HeaderText = "Исполнители ЦИК";
            this.akriko.Name = "akriko";
            this.akriko.ReadOnly = true;
            // 
            // delo
            // 
            this.delo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.delo.HeaderText = "Пользователи \"Дело\"";
            this.delo.Name = "delo";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 262);
            this.Controls.Add(this.UsersGrid);
            this.Name = "MainForm";
            this.Text = "Конвертация исполнителей";
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UsersGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn akriko;
        private System.Windows.Forms.DataGridViewComboBoxColumn delo;

    }
}

