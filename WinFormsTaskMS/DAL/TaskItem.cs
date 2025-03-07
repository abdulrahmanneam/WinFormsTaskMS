using System.ComponentModel.DataAnnotations;

namespace WinFormsTaskMS
{
    public static partial class Program
    {
        public class TaskItem
        {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime DueDate { get; set; }
            public string Priority { get; set; }
            public TaskStatus Status { get; set; }

            public int userId { get; set; }
            public UserT user { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
        }

    }
}