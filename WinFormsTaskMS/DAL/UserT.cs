namespace WinFormsTaskMS
{
    public static partial class Program
    {
        public class UserT
        {
           
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public string Passowrd { get; set; }
 
            public ICollection<TaskItem> taskitem { get; set; }
        }
    }
}