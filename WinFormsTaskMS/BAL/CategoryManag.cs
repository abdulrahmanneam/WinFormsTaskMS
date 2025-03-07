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
    public partial class CategoryManag : Form
    {
        private readonly TaskDBContext _context;
        public CategoryManag() : this(new TaskDBContext())
        {




        }
        public CategoryManag(TaskDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
            LoadStudents();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
                Category userT = new Category
                {
                    Name = CategoryName.Text.Trim(),

                };

                // التحقق من أن القيم ليست فارغة
                if (string.IsNullOrWhiteSpace(userT.Name))
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
                CategoryName.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStudents()
        {

            var students = _context.categories.Select(s => new
            {

                Name = s.Name
            }).ToList();

            DataGridView1.DataSource = students;
        }
        private void LoadUsers()
        {
            var users = _context.categories
                .Select(u => new { u.Name }) // عرض الحقول المطلوبة فقط
                .ToList();

            DataGridView1.DataSource = users;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var se = SearchTasks.Text.ToLower();
            var search = _context.categories
                .Where(s => s.Name.ToLower().StartsWith(se))
                .Select(s => new { s.Name })
                .ToList();

            DataGridView1.DataSource = search;

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

                string selectedName = DataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                // البحث عن المستخدم بناءً على البريد الإلكتروني
                var userT = _context.categories.FirstOrDefault(u => u.Name == selectedName);

                if (userT == null)
                {
                    MessageBox.Show("المستخدم غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تحديث بيانات المستخدم
                userT.Name = Catnameup.Text.Trim();


                // التحقق من أن القيم ليست فارغة
                if (string.IsNullOrWhiteSpace(userT.Name))
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
                Catnameup.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التحديث: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // التأكد من تحديد صف صحيح
            {
                DataGridViewRow row = DataGridView1.Rows[e.RowIndex];

                Catnameup.Text = row.Cells["Name"].Value.ToString();


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
                var userT = _context.categories.FirstOrDefault(u => u.Name == selectedUserName);

                if (userT == null)
                {
                    MessageBox.Show("المستخدم غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تأكيد عملية الحذف
                DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _context.categories.Remove(userT);
                    _context.SaveChanges();

                    // تأكيد نجاح الحذف
                    MessageBox.Show("تم حذف المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تحديث البيانات في DataGridView
                    LoadUsers();

                }
                Catnameup.Clear();

            }

            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

