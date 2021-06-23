
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
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageAppointment = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDui = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAddDisease = new System.Windows.Forms.Button();
            this.cmbInstitucion = new System.Windows.Forms.ComboBox();
            this.lblDui = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblInstitution = new System.Windows.Forms.Label();
            this.nudAge = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPageTracking = new System.Windows.Forms.TabPage();
            this.tabPageVaccination = new System.Windows.Forms.TabPage();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.pnlMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.tabProgram.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageAppointment.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).BeginInit();
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
            this.pnlMenu.Size = new System.Drawing.Size(212, 664);
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
            this.pnlTitleBar.Size = new System.Drawing.Size(782, 70);
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
            this.tabProgram.Size = new System.Drawing.Size(782, 594);
            this.tabProgram.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabProgram.TabIndex = 2;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.label1);
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(774, 566);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "tabPageMain";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(768, 560);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido {usuario}\r\nTenga buen dia\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageAppointment
            // 
            this.tabPageAppointment.Controls.Add(this.tableLayoutPanel1);
            this.tabPageAppointment.Controls.Add(this.panel1);
            this.tabPageAppointment.Location = new System.Drawing.Point(4, 24);
            this.tabPageAppointment.Name = "tabPageAppointment";
            this.tabPageAppointment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAppointment.Size = new System.Drawing.Size(774, 566);
            this.tabPageAppointment.TabIndex = 1;
            this.tabPageAppointment.Text = "tabPageAppointment";
            this.tabPageAppointment.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.Controls.Add(this.txtDui, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAddress, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddDisease, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbInstitucion, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDui, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblInstitution, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.nudAge, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 300);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtDui
            // 
            this.txtDui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDui.Location = new System.Drawing.Point(281, 4);
            this.txtDui.Name = "txtDui";
            this.txtDui.Size = new System.Drawing.Size(273, 29);
            this.txtDui.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(281, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(273, 29);
            this.txtName.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(281, 78);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(273, 29);
            this.txtAddress.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(281, 115);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(273, 29);
            this.txtEmail.TabIndex = 3;
            // 
            // btnAddDisease
            // 
            this.btnAddDisease.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddDisease.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddDisease.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAddDisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDisease.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddDisease.Location = new System.Drawing.Point(281, 151);
            this.btnAddDisease.Name = "btnAddDisease";
            this.btnAddDisease.Size = new System.Drawing.Size(221, 31);
            this.btnAddDisease.TabIndex = 4;
            this.btnAddDisease.Text = "Ver o añadir enfermedades";
            this.btnAddDisease.UseVisualStyleBackColor = false;
            // 
            // cmbInstitucion
            // 
            this.cmbInstitucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInstitucion.FormattingEnabled = true;
            this.cmbInstitucion.Location = new System.Drawing.Point(281, 189);
            this.cmbInstitucion.Name = "cmbInstitucion";
            this.cmbInstitucion.Size = new System.Drawing.Size(273, 29);
            this.cmbInstitucion.TabIndex = 5;
            // 
            // lblDui
            // 
            this.lblDui.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDui.AutoSize = true;
            this.lblDui.Location = new System.Drawing.Point(234, 8);
            this.lblDui.Name = "lblDui";
            this.lblDui.Size = new System.Drawing.Size(41, 21);
            this.lblDui.TabIndex = 6;
            this.lblDui.Text = "DUI:";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(200, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 21);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Nombre:";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(192, 82);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(83, 21);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Domicilio:";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(138, 119);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(137, 21);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "E-mail (Opcional):";
            // 
            // lblInstitution
            // 
            this.lblInstitution.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.Location = new System.Drawing.Point(184, 193);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(91, 21);
            this.lblInstitution.TabIndex = 10;
            this.lblInstitution.Text = "Institucion:";
            // 
            // nudAge
            // 
            this.nudAge.Location = new System.Drawing.Point(281, 225);
            this.nudAge.Name = "nudAge";
            this.nudAge.Size = new System.Drawing.Size(85, 29);
            this.nudAge.TabIndex = 12;
            this.nudAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Edad:";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(281, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "AÑADIR CITA";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 53);
            this.panel1.TabIndex = 0;
            // 
            // tabPageTracking
            // 
            this.tabPageTracking.Location = new System.Drawing.Point(4, 24);
            this.tabPageTracking.Name = "tabPageTracking";
            this.tabPageTracking.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTracking.Size = new System.Drawing.Size(774, 566);
            this.tabPageTracking.TabIndex = 2;
            this.tabPageTracking.Text = "tabPageTracking";
            this.tabPageTracking.UseVisualStyleBackColor = true;
            // 
            // tabPageVaccination
            // 
            this.tabPageVaccination.Location = new System.Drawing.Point(4, 24);
            this.tabPageVaccination.Name = "tabPageVaccination";
            this.tabPageVaccination.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVaccination.Size = new System.Drawing.Size(774, 566);
            this.tabPageVaccination.TabIndex = 3;
            this.tabPageVaccination.Text = "tabPageVaccination";
            this.tabPageVaccination.UseVisualStyleBackColor = true;
            // 
            // tabPageStats
            // 
            this.tabPageStats.Location = new System.Drawing.Point(4, 24);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStats.Size = new System.Drawing.Size(774, 566);
            this.tabPageStats.TabIndex = 4;
            this.tabPageStats.Text = "tabPageStats";
            this.tabPageStats.UseVisualStyleBackColor = true;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 664);
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
            this.tabPageMain.ResumeLayout(false);
            this.tabPageAppointment.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtDui;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAddDisease;
        private System.Windows.Forms.ComboBox cmbInstitucion;
        private System.Windows.Forms.Label lblDui;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblInstitution;
        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

