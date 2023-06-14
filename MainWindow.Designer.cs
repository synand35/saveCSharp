namespace GestionRendezVous
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ClientBtn = new System.Windows.Forms.Button();
            this.MyAppointBtn = new System.Windows.Forms.Button();
            this.TakeMeetingBtn = new System.Windows.Forms.Button();
            this.TabController = new System.Windows.Forms.TabControl();
            this.TakeMeetingPage = new System.Windows.Forms.TabPage();
            MainWindow.Liste = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Search = new System.Windows.Forms.TextBox();
            this.MyAppointsPage = new System.Windows.Forms.TabPage();
            this.DataTableAppoints = new System.Windows.Forms.DataGridView();
            this.MeetWithTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ClientPage = new System.Windows.Forms.TabPage();
            this.ClientData = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TabController.SuspendLayout();
            this.TakeMeetingPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(MainWindow.Liste)).BeginInit();
            this.panel4.SuspendLayout();
            this.MyAppointsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableAppoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ClientPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(171)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ClientBtn);
            this.panel1.Controls.Add(this.MyAppointBtn);
            this.panel1.Controls.Add(this.TakeMeetingBtn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel3.Controls.Add(this.label4);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Name = "label4";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // ClientBtn
            // 
            this.ClientBtn.BackColor = System.Drawing.Color.Transparent;
            this.ClientBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ClientBtn.FlatAppearance.BorderSize = 0;
            this.ClientBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.ClientBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.ClientBtn, "ClientBtn");
            this.ClientBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ClientBtn.Image = global::GestionRendezVous.Properties.Resources.user_edit_line;
            this.ClientBtn.Name = "ClientBtn";
            this.ClientBtn.UseVisualStyleBackColor = false;
            this.ClientBtn.Click += new System.EventHandler(this.ClientBtn_Click);
            // 
            // MyAppointBtn
            // 
            this.MyAppointBtn.BackColor = System.Drawing.Color.Transparent;
            this.MyAppointBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MyAppointBtn.FlatAppearance.BorderSize = 0;
            this.MyAppointBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.MyAppointBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.MyAppointBtn, "MyAppointBtn");
            this.MyAppointBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MyAppointBtn.Image = global::GestionRendezVous.Properties.Resources.mailbox_fill;
            this.MyAppointBtn.Name = "MyAppointBtn";
            this.MyAppointBtn.UseVisualStyleBackColor = false;
            this.MyAppointBtn.Click += new System.EventHandler(this.MyAppointBtn_Click);
            // 
            // TakeMeetingBtn
            // 
            this.TakeMeetingBtn.BackColor = System.Drawing.Color.Transparent;
            this.TakeMeetingBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.TakeMeetingBtn.FlatAppearance.BorderSize = 0;
            this.TakeMeetingBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.TakeMeetingBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.TakeMeetingBtn, "TakeMeetingBtn");
            this.TakeMeetingBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TakeMeetingBtn.Image = global::GestionRendezVous.Properties.Resources.shopping_cart_2_fill;
            this.TakeMeetingBtn.Name = "TakeMeetingBtn";
            this.TakeMeetingBtn.UseVisualStyleBackColor = false;
            this.TakeMeetingBtn.Click += new System.EventHandler(this.TakeMeetingBtn_Click);
            // 
            // TabController
            // 
            this.TabController.Controls.Add(this.TakeMeetingPage);
            this.TabController.Controls.Add(this.MyAppointsPage);
            this.TabController.Controls.Add(this.ClientPage);
            resources.ApplyResources(this.TabController, "TabController");
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            // 
            // TakeMeetingPage
            // 
            this.TakeMeetingPage.Controls.Add(MainWindow.Liste);
            this.TakeMeetingPage.Controls.Add(this.button2);
            this.TakeMeetingPage.Controls.Add(this.button1);
            this.TakeMeetingPage.Controls.Add(this.panel4);
            resources.ApplyResources(this.TakeMeetingPage, "TakeMeetingPage");
            this.TakeMeetingPage.Name = "TakeMeetingPage";
            this.TakeMeetingPage.UseVisualStyleBackColor = true;
            // 
            // Liste
            // 
            MainWindow.Liste.AllowUserToAddRows = false;
            MainWindow.Liste.AllowUserToDeleteRows = false;
            MainWindow.Liste.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            MainWindow.Liste.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            MainWindow.Liste.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            MainWindow.Liste.BorderStyle = System.Windows.Forms.BorderStyle.None;
            MainWindow.Liste.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            MainWindow.Liste.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(MainWindow.Liste, "Liste");
            MainWindow.Liste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            MainWindow.Liste.DefaultCellStyle = dataGridViewCellStyle2;
            MainWindow.Liste.EnableHeadersVisualStyles = false;
            MainWindow.Liste.Name = "Liste";
            MainWindow.Liste.ReadOnly = true;
            MainWindow.Liste.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            MainWindow.Liste.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            MainWindow.Liste.RowHeadersVisible = false;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            MainWindow.Liste.RowsDefaultCellStyle = dataGridViewCellStyle4;
            MainWindow.Liste.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            MainWindow.Liste.RowTemplate.Height = 40;
            MainWindow.Liste.RowTemplate.ReadOnly = true;
            MainWindow.Liste.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            MainWindow.Liste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkCyan;
            this.button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(171)))), ((int)(((byte)(239)))));
            this.panel4.Controls.Add(this.Search);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.Search, "Search");
            this.Search.Name = "Search";
            this.Search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MyAppointsPage
            // 
            this.MyAppointsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MyAppointsPage.Controls.Add(this.DataTableAppoints);
            this.MyAppointsPage.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.MyAppointsPage, "MyAppointsPage");
            this.MyAppointsPage.Name = "MyAppointsPage";
            // 
            // DataTableAppoints
            // 
            this.DataTableAppoints.AllowUserToAddRows = false;
            this.DataTableAppoints.AllowUserToDeleteRows = false;
            this.DataTableAppoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataTableAppoints.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataTableAppoints.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DataTableAppoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataTableAppoints.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataTableAppoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.DataTableAppoints, "DataTableAppoints");
            this.DataTableAppoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataTableAppoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeetWithTD,
            this.Description,
            this.Time});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataTableAppoints.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataTableAppoints.EnableHeadersVisualStyles = false;
            this.DataTableAppoints.Name = "DataTableAppoints";
            this.DataTableAppoints.ReadOnly = true;
            this.DataTableAppoints.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataTableAppoints.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataTableAppoints.RowHeadersVisible = false;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.DataTableAppoints.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DataTableAppoints.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataTableAppoints.RowTemplate.Height = 40;
            this.DataTableAppoints.RowTemplate.ReadOnly = true;
            this.DataTableAppoints.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataTableAppoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // MeetWithTD
            // 
            this.MeetWithTD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MeetWithTD.DataPropertyName = "Mr Charle";
            this.MeetWithTD.Frozen = true;
            resources.ApplyResources(this.MeetWithTD, "MeetWithTD");
            this.MeetWithTD.Name = "MeetWithTD";
            this.MeetWithTD.ReadOnly = true;
            this.MeetWithTD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Description.Frozen = true;
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Time.Frozen = true;
            resources.ApplyResources(this.Time, "Time");
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GestionRendezVous.Properties.Resources.kisspng_meeting_business_flat_design_illustration_meeting_picture_5a804e782f6393_3874581215183581361941;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // ClientPage
            // 
            this.ClientPage.Controls.Add(this.ClientData);
            resources.ApplyResources(this.ClientPage, "ClientPage");
            this.ClientPage.Name = "ClientPage";
            this.ClientPage.UseVisualStyleBackColor = true;
            // 
            // ClientData
            // 
            this.ClientData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.ClientData, "ClientData");
            this.ClientData.Name = "ClientData";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.TabController);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.TabController.ResumeLayout(false);
            this.TakeMeetingPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(MainWindow.Liste)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.MyAppointsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableAppoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ClientPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClientData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ClientBtn;
        private System.Windows.Forms.Button MyAppointBtn;
        private System.Windows.Forms.Button TakeMeetingBtn;
        private System.Windows.Forms.TabControl TabController;
        private System.Windows.Forms.TabPage TakeMeetingPage;
        private System.Windows.Forms.TabPage MyAppointsPage;
        private System.Windows.Forms.TabPage ClientPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView DataTableAppoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeetWithTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridView ClientData;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private static System.Windows.Forms.DataGridView Liste;
    }
}

