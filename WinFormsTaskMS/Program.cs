using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WinFormsTaskMS.BAL;
using WinFormsTaskMS.DAL;

namespace WinFormsTaskMS
{
    public static partial class Program
    {
     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSetting.json", optional: false, reloadOnChange: true)
                .Build();


            var services = new ServiceCollection();
            services.AddDbContext<TaskDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<TaskDBContext>();

           
            Application.Run(new Login(dbContext));
        }
        public static bool IsinDesignMode(this UserControl userControl)
        {
            if (Application.ExecutablePath.IndexOf("",StringComparison.OrdinalIgnoreCase)>-1)
            {
                userControl.Controls.Add(new Label()
                {
                    Text = userControl.GetType().Name,
                    AutoSize = false,
                    TextAlign =ContentAlignment.MiddleCenter,
                    Dock =DockStyle.Fill
                });


            }
            return false;
        }

    }
}