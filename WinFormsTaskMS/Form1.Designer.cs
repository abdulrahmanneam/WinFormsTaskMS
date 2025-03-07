namespace WinFormsTaskMS
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label1 = new Label();
            BtnBar = new PictureBox();
            lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pictureBox1 = new PictureBox();
            Sidebar = new FlowLayoutPanel();
            panel2 = new Panel();
            button1 = new Button();
            MenuCont = new FlowLayoutPanel();
            panel3 = new Panel();
            Menu = new Button();
            panel7 = new Panel();
            button6 = new Button();
            panel8 = new Panel();
            button2 = new Button();
            button7 = new Button();
            panel9 = new Panel();
            button9 = new Button();
            button10 = new Button();
            panel4 = new Panel();
            button3 = new Button();
            panel5 = new Panel();
            button4 = new Button();
            panel6 = new Panel();
            button5 = new Button();
            MenuTr = new System.Windows.Forms.Timer(components);
            SidebarTr = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BtnBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            Sidebar.SuspendLayout();
            panel2.SuspendLayout();
            MenuCont.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(BtnBar);
            panel1.Controls.Add(lblUserName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(977, 25);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(670, -1);
            label1.Name = "label1";
            label1.Size = new Size(226, 25);
            label1.TabIndex = 1;
            label1.Text = "Task management System";
            // 
            // BtnBar
            // 
            BtnBar.Image = (Image)resources.GetObject("BtnBar.Image");
            BtnBar.Location = new Point(0, 0);
            BtnBar.Name = "BtnBar";
            BtnBar.Size = new Size(34, 24);
            BtnBar.SizeMode = PictureBoxSizeMode.StretchImage;
            BtnBar.TabIndex = 1;
            BtnBar.TabStop = false;
            BtnBar.Click += BtnBar_Click;
            // 
            // lblUserName
            // 
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(63, -1);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(72, 23);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "Teeeeeet";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(173, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(804, 505);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Sidebar
            // 
            Sidebar.BackColor = Color.FromArgb(23, 24, 29);
            Sidebar.Controls.Add(panel2);
            Sidebar.Controls.Add(MenuCont);
            Sidebar.Controls.Add(panel4);
            Sidebar.Controls.Add(panel5);
            Sidebar.Controls.Add(panel6);
            Sidebar.Dock = DockStyle.Left;
            Sidebar.Location = new Point(0, 25);
            Sidebar.Name = "Sidebar";
            Sidebar.Size = new Size(173, 505);
            Sidebar.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(178, 40);
            panel2.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(23, 24, 29);
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(-31, -22);
            button1.Name = "button1";
            button1.Padding = new Padding(25, 0, 0, 0);
            button1.Size = new Size(214, 82);
            button1.TabIndex = 2;
            button1.Text = "             Home";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // MenuCont
            // 
            MenuCont.BackColor = Color.FromArgb(32, 33, 36);
            MenuCont.Controls.Add(panel3);
            MenuCont.Controls.Add(panel7);
            MenuCont.Controls.Add(panel8);
            MenuCont.Controls.Add(panel9);
            MenuCont.Location = new Point(3, 49);
            MenuCont.Name = "MenuCont";
            MenuCont.Size = new Size(170, 40);
            MenuCont.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Controls.Add(Menu);
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(178, 40);
            panel3.TabIndex = 4;
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(23, 24, 29);
            Menu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Menu.ForeColor = Color.White;
            Menu.Image = (Image)resources.GetObject("Menu.Image");
            Menu.ImageAlign = ContentAlignment.MiddleLeft;
            Menu.Location = new Point(-32, -22);
            Menu.Name = "Menu";
            Menu.Padding = new Padding(25, 0, 0, 0);
            Menu.Size = new Size(206, 88);
            Menu.TabIndex = 2;
            Menu.Text = "                         Task Manager";
            Menu.TextAlign = ContentAlignment.MiddleLeft;
            Menu.UseVisualStyleBackColor = false;
            Menu.Click += Menu_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(button6);
            panel7.Location = new Point(0, 40);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(197, 40);
            panel7.TabIndex = 5;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(32, 33, 36);
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(-5, -22);
            button6.Name = "button6";
            button6.Padding = new Padding(25, 0, 0, 0);
            button6.Size = new Size(205, 86);
            button6.TabIndex = 2;
            button6.Text = "              User";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(button2);
            panel8.Controls.Add(button7);
            panel8.Location = new Point(0, 80);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(197, 40);
            panel8.TabIndex = 6;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(32, 33, 36);
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(-4, -23);
            button2.Name = "button2";
            button2.Padding = new Padding(25, 0, 0, 0);
            button2.Size = new Size(205, 86);
            button2.TabIndex = 3;
            button2.Text = "             Category";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(32, 33, 36);
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(-5, -22);
            button7.Name = "button7";
            button7.Padding = new Padding(25, 0, 0, 0);
            button7.Size = new Size(205, 86);
            button7.TabIndex = 2;
            button7.Text = "             Task management";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            panel9.Controls.Add(button9);
            panel9.Controls.Add(button10);
            panel9.Location = new Point(0, 120);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Size = new Size(197, 40);
            panel9.TabIndex = 7;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(32, 33, 36);
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(-4, -23);
            button9.Name = "button9";
            button9.Padding = new Padding(25, 0, 0, 0);
            button9.Size = new Size(205, 86);
            button9.TabIndex = 3;
            button9.Text = "             Task management";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click_1;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(32, 33, 36);
            button10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.White;
            button10.Image = (Image)resources.GetObject("button10.Image");
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(-5, -22);
            button10.Name = "button10";
            button10.Padding = new Padding(25, 0, 0, 0);
            button10.Size = new Size(205, 86);
            button10.TabIndex = 2;
            button10.Text = "             Task management";
            button10.TextAlign = ContentAlignment.MiddleLeft;
            button10.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(button3);
            panel4.Location = new Point(3, 95);
            panel4.Name = "panel4";
            panel4.Size = new Size(158, 40);
            panel4.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(23, 24, 29);
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(-30, -22);
            button3.Name = "button3";
            button3.Padding = new Padding(25, 0, 0, 0);
            button3.Size = new Size(200, 82);
            button3.TabIndex = 2;
            button3.Text = "                         Report";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(button4);
            panel5.Location = new Point(3, 141);
            panel5.Name = "panel5";
            panel5.Size = new Size(170, 40);
            panel5.TabIndex = 4;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(23, 24, 29);
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(-29, -22);
            button4.Name = "button4";
            button4.Padding = new Padding(25, 0, 0, 0);
            button4.Size = new Size(203, 82);
            button4.TabIndex = 2;
            button4.Text = "                        Settings";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(button5);
            panel6.Location = new Point(3, 187);
            panel6.Name = "panel6";
            panel6.Size = new Size(170, 40);
            panel6.TabIndex = 4;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(23, 24, 29);
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(-26, -23);
            button5.Name = "button5";
            button5.Padding = new Padding(25, 0, 0, 0);
            button5.Size = new Size(203, 82);
            button5.TabIndex = 2;
            button5.Text = "                       Log Out";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // MenuTr
            // 
            MenuTr.Interval = 10;
            MenuTr.Tick += MenuTr_Tick;
            // 
            // SidebarTr
            // 
            SidebarTr.Interval = 10;
            SidebarTr.Tick += SidebarTr_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 530);
            Controls.Add(pictureBox1);
            Controls.Add(Sidebar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BtnBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            Sidebar.ResumeLayout(false);
            panel2.ResumeLayout(false);
            MenuCont.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox BtnBar;
        private Label label1;
        private FlowLayoutPanel Sidebar;
        private Button button1;
        private Panel panel2;
        private Panel panel3;
        private Button Menu;
        private Panel panel4;
        private Button button3;
        private Panel panel5;
        private Button button4;
        private Panel panel6;
        private Button button5;
        private FlowLayoutPanel MenuCont;
        private Panel panel7;
        private Button button6;
        private Panel panel8;
        private Button button7;
        private System.Windows.Forms.Timer MenuTr;
        private System.Windows.Forms.Timer SidebarTr;
        private PictureBox pictureBox1;
        private Button button2;
        private Panel panel9;
        private Button button9;
        private Button button10;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserName;
    }
}
