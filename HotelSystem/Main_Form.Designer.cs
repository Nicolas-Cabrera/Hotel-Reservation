namespace HotelSystem
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.manageClients = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRooms = new System.Windows.Forms.ToolStripMenuItem();
            this.manageReservations = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageClients,
            this.manageRooms,
            this.manageReservations});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(985, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // manageClients
            // 
            this.manageClients.Name = "manageClients";
            this.manageClients.Size = new System.Drawing.Size(101, 20);
            this.manageClients.Text = "Manage Clients";
            this.manageClients.Click += new System.EventHandler(this.ManageClients_Click);
            // 
            // manageRooms
            // 
            this.manageRooms.Name = "manageRooms";
            this.manageRooms.Size = new System.Drawing.Size(102, 20);
            this.manageRooms.Text = "Manage Rooms";
            this.manageRooms.Click += new System.EventHandler(this.ManageRooms_Click);
            // 
            // manageReservations
            // 
            this.manageReservations.Name = "manageReservations";
            this.manageReservations.Size = new System.Drawing.Size(131, 20);
            this.manageReservations.Text = "Manage Reservations";
            this.manageReservations.Click += new System.EventHandler(this.ManageReservations_Click);
            // 
            // Main_Form
            // 
            this.ClientSize = new System.Drawing.Size(985, 609);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Main_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing_1);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageReservationsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem manageClients;
        private System.Windows.Forms.ToolStripMenuItem manageRooms;
        private System.Windows.Forms.ToolStripMenuItem manageReservations;
    }
}