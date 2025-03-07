using Guna.UI2.WinForms;
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
    public partial class UserTask : Form
    {
        private readonly TaskDBContext _context;
        public UserTask() : this(new TaskDBContext())
        {




        }
        public UserTask(TaskDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
            LoadStudents();
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void guna2Button1_Click_2(object sender, EventArgs e)
        {

            try
            {
                // التحقق من أن قاعدة البيانات مهيأة
                if (_context == null)
                {
                    MessageBox.Show("Database context is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // إنشاء كائن مستخدم جديد
                UserT userT = new UserT
                {
                    Name = guna2TextBox1.Text.Trim(),
                    Email = guna2TextBox2.Text.Trim(),
                    Passowrd = guna2TextBox3.Text.Trim()
                };

                // التحقق من أن القيم ليست فارغة
                if (string.IsNullOrWhiteSpace(userT.Name) ||
                    string.IsNullOrWhiteSpace(userT.Email) ||
                    string.IsNullOrWhiteSpace(userT.Passowrd))
                {
                    MessageBox.Show("جميع الحقول مطلوبة!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // حفظ المستخدم في قاعدة البيانات
                _context.Add(userT);
                _context.SaveChanges();

                // تأكيد نجاح الحفظ
                MessageBox.Show("تمت إضافة المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // إعادة تعيين الحقول
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                guna2TextBox3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStudents()
        {

            var students = _context.user.Select(s => new
            {

                Name = s.Name,
                Email = s.Email
            }).ToList();

            DataGridView1.DataSource = students;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var se = SearchTasks.Text.ToLower();
            var search = _context.user
                .Where(s => s.Name.ToLower().StartsWith(se))
                .Select(s => new { s.Name, s.Email })
                .ToList();

            DataGridView1.DataSource = search;

        }

        private void LoadUsers()
        {
            var users = _context.user
                .Select(u => new { u.Name, u.Email }) // عرض الحقول المطلوبة فقط
                .ToList();

            DataGridView1.DataSource = users;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن قاعدة البيانات مهيأة
                if (_context == null)
                {
                    MessageBox.Show("Database context is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // التأكد من تحديد صف من DataGridView
                if (DataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("يرجى تحديد مستخدم من القائمة لتحديث بياناته.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedEmail = DataGridView1.SelectedRows[0].Cells["Email"].Value.ToString();

                // البحث عن المستخدم بناءً على البريد الإلكتروني
                var userT = _context.user.FirstOrDefault(u => u.Email == selectedEmail);

                if (userT == null)
                {
                    MessageBox.Show("المستخدم غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تحديث بيانات المستخدم
                userT.Name = usernameup.Text.Trim();
                userT.Email = emailup.Text.Trim();
                userT.Passowrd = passup.Text.Trim();

                // التحقق من أن القيم ليست فارغة
                if (string.IsNullOrWhiteSpace(userT.Name) ||
                    string.IsNullOrWhiteSpace(userT.Email) ||
                    string.IsNullOrWhiteSpace(userT.Passowrd))
                {
                    MessageBox.Show("جميع الحقول مطلوبة!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحديث البيانات في قاعدة البيانات
                _context.Update(userT);
                _context.SaveChanges();

                // تأكيد نجاح التحديث
                MessageBox.Show("تم تحديث بيانات المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // إعادة تحميل البيانات في DataGridView
                LoadUsers();

                // إعادة تعيين الحقول
                usernameup.Clear();
                emailup.Clear();
                passup.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التحديث: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // التأكد من تحديد صف صحيح
            {
                DataGridViewRow row = DataGridView1.Rows[e.RowIndex];

                usernameup.Text = row.Cells["Name"].Value.ToString();
                emailup.Text = row.Cells["Email"].Value.ToString();

                string email = emailup.Text;
                var user = _context.user.FirstOrDefault(s => s.Email == email);

                if (user != null)
                {
                    passup.Text = user.Passowrd;
                }
                else
                {
                    passup.Text = "";
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                // التأكد من تحديد صف من DataGridView
                if (DataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("يرجى تحديد مستخدم من القائمة للحذف.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // الحصول على اسم المستخدم المحدد
                string selectedUserName = DataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                // البحث عن المستخدم في قاعدة البيانات
                var userT = _context.user.FirstOrDefault(u => u.Name == selectedUserName);

                if (userT == null)
                {
                    MessageBox.Show("المستخدم غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تأكيد عملية الحذف
                DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _context.user.Remove(userT);
                    _context.SaveChanges();

                    // تأكيد نجاح الحذف
                    MessageBox.Show("تم حذف المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تحديث البيانات في DataGridView
                    LoadUsers();

                }
                usernameup.Clear();
                emailup.Clear();
                passup.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserTask_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
