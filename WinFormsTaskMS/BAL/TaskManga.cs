using Microsoft.EntityFrameworkCore;
using ServiceStack;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static WinFormsTaskMS.Program;
using TaskStatus = WinFormsTaskMS.Program.TaskStatus;

namespace WinFormsTaskMS.BAL
{
    public partial class TaskManga : Form
    {
        private readonly TaskDBContext _context;
        public TaskManga() : this(new TaskDBContext())
        {




        }
        public TaskManga(TaskDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text) ||
                    cmbPriority.SelectedItem == null ||
                    cmbStatus.SelectedItem == null ||
                    cmbUser.SelectedValue == null ||
                    cmbCategory.SelectedValue == null)
                {
                    MessageBox.Show("يرجى ملء جميع الحقول المطلوبة!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // إنشاء كائن جديد من المهمة
                var newTask = new TaskItem
                {
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    DueDate = dtpDueDate.Value,
                    Priority = cmbPriority.SelectedItem.ToString(),
                    Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), cmbStatus.SelectedItem.ToString()), // تحويل النص إلى Enum
                    userId = Convert.ToInt32(cmbUser.SelectedValue), // ربط المستخدم بالمعرف الخاص به
                    CategoryId = Convert.ToInt32(cmbCategory.SelectedValue) // ربط الفئة بالمعرف الخاص بها
                };

                // إضافة المهمة إلى قاعدة البيانات
                _context.taskitem.Add(newTask);
                _context.SaveChanges();

                // تأكيد نجاح الحفظ
                MessageBox.Show("تم حفظ المهمة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // تحديث البيانات في DataGridView
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTasks()
        {
            var tasks = _context.taskitem
                .Select(t => new
                {

                    t.Title,
                    t.Description,
                    t.DueDate,
                    t.Priority,
                    Status = t.Status.ToString(), // تحويل Enum إلى نص
                    Name = t.user.Name, // جلب اسم المستخدم بدلاً من الـ Id
                    CategoryName = t.Category.Name // جلب اسم الفئة بدلاً من الـ Id
                })
                .ToList();

            DataGridView1.DataSource = tasks;
        }
        private void TaskManga_Load(object sender, EventArgs e)
        {
            cmbUser.DataSource = _context.user.ToList();
            cmbUser.DisplayMember = "Name"; // عرض اسم المستخدم
            cmbUser.ValueMember = "Id"; // القيمة المخفية (الـ ID)

            // تحميل بيانات الفئات (Categories)
            cmbCategory.DataSource = _context.categories.ToList();
            cmbCategory.DisplayMember = "Name"; // عرض اسم الفئة
            cmbCategory.ValueMember = "Id"; // القيمة المخفية (الـ ID)

            // تحميل القيم الخاصة بالأولوية
            cmbPriority.Items.AddRange(new string[] { "Low", "Medium", "High" });

            // تحميل قيم الـ Enum في ComboBox الخاص بالحالة (Status)
            cmbStatus.DataSource = Enum.GetValues(typeof(TaskStatus));

            // تحميل المهام الحالية إلى DataGridView
            LoadTasks();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var se = SearchTasks.Text.ToLower();
            var search = _context.taskitem
            .Where(s => s.Title.ToLower().StartsWith(se))
                .Select(s => new { s.Title, s.Description, s.DueDate, s.Priority, Name = s.user.Name, s.Status, CategoryName = s.Category.Name })
                .ToList();

            DataGridView1.DataSource = search;
        }

        private string selectedTaskTitle = "";
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DataGridView1.Rows[e.RowIndex];

            // حفظ معرف المهمة المختارة
            selectedTaskTitle = row.Cells["Title"].Value.ToString();

            // تحميل البيانات إلى الحقول
            txtTitle.Text = row.Cells["Title"].Value.ToString();
            txtDescription.Text = row.Cells["Description"].Value.ToString();
            dtpDueDate.Value = Convert.ToDateTime(row.Cells["DueDate"].Value);
            cmbPriority.SelectedItem = row.Cells["Priority"].Value.ToString();
            cmbStatus.SelectedItem = Enum.Parse(typeof(TaskStatus), row.Cells["Status"].Value.ToString());
            cmbUser.SelectedValue = _context.user.FirstOrDefault(u => u.Name == row.Cells["Name"].Value.ToString())?.Id;
            cmbCategory.SelectedValue = _context.categories.FirstOrDefault(c => c.Name == row.Cells["CategoryName"].Value.ToString())?.Id;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedTaskTitle))
                {
                    MessageBox.Show("يرجى تحديد مهمة للتعديل!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // البحث عن المهمة باستخدام العنوان
                var taskToUpdate = _context.taskitem.FirstOrDefault(t => t.Title == selectedTaskTitle);
                if (taskToUpdate != null)
                {
                    // تحديث البيانات
                    taskToUpdate.Title = txtTitle.Text;
                    taskToUpdate.Description = txtDescription.Text;
                    taskToUpdate.DueDate = dtpDueDate.Value;
                    taskToUpdate.Priority = cmbPriority.SelectedItem.ToString();
                    taskToUpdate.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), cmbStatus.SelectedItem.ToString());
                    taskToUpdate.userId = Convert.ToInt32(cmbUser.SelectedValue);
                    taskToUpdate.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);

                    // حفظ التعديلات
                    _context.SaveChanges();

                    MessageBox.Show("تم تحديث المهمة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // إعادة تحميل المهام في DataGridView
                    LoadTasks();
                }
                else
                {
                    MessageBox.Show("المهمة غير موجودة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التحديث: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedTaskTitle))
                {
                    MessageBox.Show("يرجى تحديد مهمة للحذف!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تأكيد الحذف
                DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذه المهمة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // البحث عن المهمة باستخدام العنوان
                    var taskToDelete = _context.taskitem.FirstOrDefault(t => t.Title == selectedTaskTitle);
                    if (taskToDelete != null)
                    {
                        // حذف المهمة
                        _context.taskitem.Remove(taskToDelete);
                        _context.SaveChanges();

                        MessageBox.Show("تم حذف المهمة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // إعادة تحميل المهام في DataGridView
                        LoadTasks();
                    }
                    else
                    {
                        MessageBox.Show("المهمة غير موجودة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedTaskTitle))
                {
                    MessageBox.Show("يرجى تحديد مهمة للتعديل!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // البحث عن المهمة باستخدام العنوان
                var taskToUpdate = _context.taskitem.FirstOrDefault(t => t.Title == selectedTaskTitle);
                if (taskToUpdate != null)
                {
                    // تحديث البيانات
                    taskToUpdate.Title = txtTitle.Text;
                    taskToUpdate.Description = txtDescription.Text;
                    taskToUpdate.DueDate = dtpDueDate.Value;
                    taskToUpdate.Priority = cmbPriority.SelectedItem.ToString();
                    taskToUpdate.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), cmbStatus.SelectedItem.ToString());
                    taskToUpdate.userId = Convert.ToInt32(cmbUser.SelectedValue);
                    taskToUpdate.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);

                    // حفظ التعديلات
                    _context.SaveChanges();

                    MessageBox.Show("تم تحديث المهمة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    // إعادة تحميل المهام في DataGridView
                    LoadTasks();
                    txtTitle.Clear();
                    txtDescription.Clear();


                }
                else
                {
                    MessageBox.Show("المهمة غير موجودة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التحديث: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedTaskTitle))
                {
                    MessageBox.Show("يرجى تحديد مهمة للحذف!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تأكيد الحذف
                DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذه المهمة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // البحث عن المهمة باستخدام العنوان
                    var taskToDelete = _context.taskitem.FirstOrDefault(t => t.Title == selectedTaskTitle);
                    if (taskToDelete != null)
                    {
                        // حذف المهمة
                        _context.taskitem.Remove(taskToDelete);
                        _context.SaveChanges();

                        MessageBox.Show("تم حذف المهمة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // إعادة تحميل المهام في DataGridView
                        LoadTasks();
                        txtTitle.Clear();
                        txtDescription.Clear();

                    }
                    else
                    {
                        MessageBox.Show("المهمة غير موجودة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void SearchTasks_TextChanged(object sender, EventArgs e)
        {
            var se = SearchTasks.Text.ToLower().Trim(); 

            var search = _context.taskitem
                .Where(s => s.Title.ToLower().Contains(se)) 
                .Select(s => new
                {
                    s.Title,
                    s.Description,
                    s.DueDate,
                    s.Priority,
                    User_Name = s.user.Name, 
                    s.Status,
                    Category_Name = s.Category.Name
                })
                .ToList();

            DataGridView1.DataSource = search;
        }
    }
}
