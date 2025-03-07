using System.ComponentModel.DataAnnotations;

namespace WinFormsTaskMS
{
    public static partial class Program
    {
        public class Category
        {
            [Key]
            public int Id  { get; set; }
            [Required]
            public string Name { get; set; }
            public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        }
    }
}