using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTaskMS.DAL;
using static WinFormsTaskMS.Program;

namespace WinFormsTaskMS.BAL
{
    public partial class Login : Form
    {
        private readonly TaskDBContext _context;
    
        public Login() : this(new TaskDBContext())
        {




        }
        public Login(TaskDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();

        }
        private void loginb_Click(object sender, EventArgs e)
        {
            // البحث عن المستخدم في قاعدة البيانات
            var user = _context.user.FirstOrDefault(u => u.Email == UserName.Text && u.Passowrd == Password.Text);

            if (user != null)
            {
               
                Form1 form1 = new Form1( _context,user.Name);
                form1.Show();
                this.Hide(); // إخفاء نافذة تسجيل الدخول
            }
            else
            {
                MessageBox.Show("Invalid User Name Or Password", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void esc_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
