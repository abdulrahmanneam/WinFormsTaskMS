
using WinFormsTaskMS.BAL;
using WinFormsTaskMS.DAL;
using static WinFormsTaskMS.Program;

namespace WinFormsTaskMS
{
    public partial class Form1 : Form
    {
        private readonly TaskDBContext _context;
        private string _userName;
        public Form1() : this(new TaskDBContext(), "Guest")
        {




        }
        public Form1(TaskDBContext context, string userName)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
            _userName = userName;
            lblUserName.Text = $"Welcome، {_userName}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool menuExp = false;
        private void MenuTr_Tick(object sender, EventArgs e)
        {
            if (menuExp == false)
            {
                MenuCont.Height += 10;
                if (MenuCont.Height >= 196)
                {
                    MenuTr.Stop();
                    menuExp = true;
                }

            }

            else
            {
                MenuCont.Height -= 10;
                if (MenuCont.Height <= 40)
                {
                    MenuTr.Stop();
                    menuExp = false;
                }
            }

        }

        private void Menu_Click(object sender, EventArgs e)
        {

            MenuTr.Start();
        }
        bool sidebarEx = true;
        private void SidebarTr_Tick(object sender, EventArgs e)
        {
            if (sidebarEx)
            {
                Sidebar.Width -= 10;
                if (Sidebar.Width <= 34)
                {
                    sidebarEx = false;
                    SidebarTr.Stop();
                }
            }
            else
            {
                Sidebar.Width += 10;
                if (Sidebar.Width >= 163)
                {
                    sidebarEx = true;
                    SidebarTr.Stop();
                }
            }
        }

        private void BtnBar_Click(object sender, EventArgs e)
        {
            SidebarTr.Start();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pageTasks1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserTask user = new UserTask(_context);
            user.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaskReports taskReports = new TaskReports(_context);
            taskReports.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login login = new Login(_context);
            login.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryManag category = new CategoryManag(_context);
            category.ShowDialog();

        }

        private void button9_Click(object sender, EventArgs e)
        {

           
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            TaskManga taskManga = new TaskManga(_context);
            taskManga.ShowDialog();
        }
    }
}
