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

namespace WinFormsTaskMS.BAL
{
    public partial class UserControlManageTask : UserControl
    {
        TaskDBContext _TaskDBContext;
        public UserControlManageTask()
        {
            InitializeComponent();
        }
        public UserControlManageTask(TaskDBContext taskDBContext)
        {
            this._TaskDBContext = taskDBContext;
            LoadTasks();
          
        }

        private void LoadTasks()
        {

            var TaskItem = _TaskDBContext.taskitem.Select(T => new
            {
                Name = T.Title,
                User = T.user.Name,
                Descriptions = T.Description,
                Date = T.DueDate,
                Prioritys = T.Priority,
                Categorys = T.Category
            }).ToList();
            DataGridView1.DataSource = TaskItem;


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
