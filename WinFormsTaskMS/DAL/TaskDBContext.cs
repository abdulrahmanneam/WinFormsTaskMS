using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinFormsTaskMS.Program;

namespace WinFormsTaskMS.DAL
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext()
        {
            
        }
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options) { }
        public DbSet<UserT> user { get; set;}
        public DbSet<Category> categories { get; set;}
        public DbSet<TaskItem> taskitem { get; set; }
      

    }
}
