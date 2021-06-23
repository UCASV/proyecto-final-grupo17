
namespace ProyectoFinalPOOBD.Views
{
    partial class frmMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnStats = new FontAwesome.Sharp.IconButton();
            this.btnVaccinationProcess = new FontAwesome.Sharp.IconButton();
            this.btnAppointmentTracking = new FontAwesome.Sharp.IconButton();
            this.btnAppointmentProcess = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.tabProgram = new System.Windows.Forms.TabControl();
            this.tabPageTracking = new System.Windows.Forms.TabPage();
            this.tabPageVaccination = new System.Windows.Forms.TabPage();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.tabPageAppointment = new System.Windows.Forms.TabPage();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.pnlMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.tabProgram.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.pnlMenu.Controls.Add(this.btnStats);
            this.pnlMenu.Controls.Add(this.btnVaccinationProcess);
            this.pnlMenu.Controls.Add(this.btnAppointmentTracking);
            this.pnlMenu.Controls.Add(this.btnAppointmentProcess);
            this.pnlMenu.Controls.Add(this.panel2);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(212, 647);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnStats
            // 
            this.btnStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStats.FlatAppearance.BorderSize = 0;
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStats.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnStats.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.btnStats.IconColor = System.Drawing.Color.FloralWhite;
            this.btnStats.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.Location = new System.Drawing.Point(0, 304);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(212, 64);
            this.btnStats.TabIndex = 4;
            this.btnStats.Text = "Estadisticas";
            this.btnStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnVaccinationProcess
            // 
            this.btnVaccinationProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVaccinationProcess.FlatAppearance.BorderSize = 0;
            this.btnVaccinationProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVaccinationProcess.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVaccinationProcess.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnVaccinationProcess.IconChar = FontAwesome.Sharp.IconChar.Syringe;
            this.btnVaccinationProcess.IconColor = System.Drawing.Color.FloralWhite;
            this.btnVaccinationProcess.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVaccinationProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVaccinationProcess.Location = new System.Drawing.Point(0, 240);
            this.btnVaccinationProcess.Name = "btnVaccinationProcess";
            this.btnVaccinationProcess.Size = new System.Drawing.Size(212, 64);
            this.btnVaccinationProcess.TabIndex = 3;
            this.btnVaccinationProcess.Text = "Proceso de vacunacion";
            this.btnVaccinationProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVaccinationProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVaccinationProcess.UseVisualStyleBackColor = true;
            this.btnVaccinationProcess.Click += new System.EventHandler(this.btnVaccinationProcess_Click);
            // 
            // btnAppointmentTracking
            // 
            this.btnAppointmentTracking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppointmentTracking.FlatAppearance.BorderSize = 0;
            this.btnAppointmentTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointmentTracking.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAppointmentTracking.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnAppointmentTracking.IconChar = FontAwesome.Sharp.IconChar.ClipboardCheck;
            this.btnAppointmentTracking.IconColor = System.Drawing.Color.FloralWhite;
            this.btnAppointmentTracking.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAppointmentTracking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointmentTracking.Location = new System.Drawing.Point(0, 176);
            this.btnAppointmentTracking.Name = "btnAppointmentTracking";
            this.btnAppointmentTracking.Size = new System.Drawing.Size(212, 64);
            this.btnAppointmentTracking.TabIndex = 2;
            this.btnAppointmentTracking.Text = "Seguimiento \r\nde cita";
            this.btnAppointmentTracking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointmentTracking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAppointmentTracking.UseVisualStyleBackColor = true;
            this.btnAppointmentTracking.Click += new System.EventHandler(this.btnAppointmentTracking_Click);
            // 
            // btnAppointmentProcess
            // 
            this.btnAppointmentProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppointmentProcess.FlatAppearance.BorderSize = 0;
            this.btnAppointmentProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointmentProcess.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAppointmentProcess.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnAppointmentProcess.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnAppointmentProcess.IconColor = System.Drawing.Color.FloralWhite;
            this.btnAppointmentProcess.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAppointmentProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointmentProcess.Location = new System.Drawing.Point(0, 112);
            this.btnAppointmentProcess.Name = "btnAppointmentProcess";
            this.btnAppointmentProcess.Size = new System.Drawing.Size(212, 64);
            this.btnAppointmentProcess.TabIndex = 1;
            this.btnAppointmentProcess.Text = "Proceso de \r\ncita";
            this.btnAppointmentProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointmentProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAppointmentProcess.UseVisualStyleBackColor = true;
            this.btnAppointmentProcess.Click += new System.EventHandler(this.btnAppointmentProcess_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 112);
            this.panel2.TabIndex = 0;
            // 
            // picHome
            // 
            this.picHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picHome.Image = global::ProyectoFinalPOOBD.Properties.Resources.programmer_male_icon;
            this.picHome.Location = new System.Drawing.Point(0, 0);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(212, 112);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome.TabIndex = 0;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(212, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(740, 70);
            this.pnlTitleBar.TabIndex = 1;
            // 
            // tabProgram
            // 
            this.tabProgram.Controls.Add(this.tabPageMain);
            this.tabProgram.Controls.Add(this.tabPageAppointment);
            this.tabProgram.Controls.Add(this.tabPageTracking);
            this.tabProgram.Controls.Add(this.tabPageVaccination);
            this.tabProgram.Controls.Add(this.tabPageStats);
            this.tabProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProgram.Location = new System.Drawing.Point(212, 70);
            this.tabProgram.Name = "tabProgram";
            this.tabProgram.SelectedIndex = 0;
            this.tabProgram.Size = new System.Drawing.Size(740, 577);
            this.tabProgram.TabIndex = 2;
            // 
            // tabPageTracking
            // 
            this.tabPageTracking.Location = new System.Drawing.Point(4, 24);
            this.tabPageTracking.Name = "tabPageTracking";
            this.tabPageTracking.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTracking.Size = new System.Drawing.Size(732, 549);
            this.tabPageTracking.TabIndex = 2;
            this.tabPageTracking.Text = "tabPageTracking";
            this.tabPageTracking.UseVisualStyleBackColor = true;
            // 
            // tabPageVaccination
            // 
            this.tabPageVaccination.Location = new System.Drawing.Point(4, 24);
            this.tabPageVaccination.Name = "tabPageVaccination";
            this.tabPageVaccination.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVaccination.Size = new System.Drawing.Size(732, 549);
            this.tabPageVaccination.TabIndex = 3;
            this.tabPageVaccination.Text = "tabPageVaccination";
            this.tabPageVaccination.UseVisualStyleBackColor = true;
            // 
            // tabPageStats
            // 
            this.tabPageStats.Location = new System.Drawing.Point(4, 24);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStats.Size = new System.Drawing.Size(732, 549);
            this.tabPageStats.TabIndex = 4;
            this.tabPageStats.Text = "tabPageStats";
            this.tabPageStats.UseVisualStyleBackColor = true;
            // 
            // tabPageAppointment
            // 
            this.tabPageAppointment.Location = new System.Drawing.Point(4, 24);
            this.tabPageAppointment.Name = "tabPageAppointment";
            this.tabPageAppointment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAppointment.Size = new System.Drawing.Size(732, 549);
            this.tabPageAppointment.TabIndex = 1;
            this.tabPageAppointment.Text = "tabPageAppointment";
            this.tabPageAppointment.UseVisualStyleBackColor = true;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(732, 549);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "tabPageMain";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 647);
            this.Controls.Add(this.tabProgram);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainForm";
            this.pnlMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.tabProgram.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private FontAwesome.Sharp.IconButton btnAppointmentProcess;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnStats;
        private FontAwesome.Sharp.IconButton btnVaccinationProcess;
        private FontAwesome.Sharp.IconButton btnAppointmentTracking;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.TabControl tabProgram;
        private System.Windows.Forms.TabPage tabPageTracking;
        private System.Windows.Forms.TabPage tabPageVaccination;
        private System.Windows.Forms.TabPage tabPageStats;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageAppointment;
    }
}

