using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinFormsTaskMS.DAL;
using ClosedXML.Excel;
using System.IO;
using static WinFormsTaskMS.Program;
using System.Windows.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Layout.Properties;
using TaskStatusEnum = WinFormsTaskMS.Program.TaskStatus;
using iTextSharp.text.pdf;
using System.Reflection.Metadata;
using Document = iText.Layout.Document;
using PdfEncodings = iText.IO.Font.PdfEncodings;
using PdfFont = iText.Kernel.Font.PdfFont;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;

namespace WinFormsTaskMS.BAL
{
    public partial class TaskReports : Form
    {
        private readonly TaskDBContext _context;

        public TaskReports() : this(new TaskDBContext()) { }

        public TaskReports(TaskDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
        }



        private void LoadTasks(string status)
        {
            if (Enum.TryParse<TaskStatusEnum>(status, out var enumStatus))
            {
                var filteredTasks = _context.taskitem
                                 .Where(t => t.Status == enumStatus)
                                 .Select(t => new
                                 {
                                     t.Id,      
                                     t.Title,    
                                     t.DueDate,  
                                     t.Description,
                                     t.Status,
                                     t.Priority,
                                     UserName = t.user.Name,
                                     Category_Name = t.Category.Name
                                 })
                                 .ToList();
                dataGridView1.DataSource = filteredTasks;
            }

        }

        //private void ExportToPDF()
        //{
        //    var tasks = (List<TaskItem>)dataGridView1.DataSource;

        //    if (tasks == null || tasks.Count == 0)
        //    {
        //        MessageBox.Show("لا يوجد بيانات للتصدير.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    string filePath = @"D:\TaskReport.pdf";

        //    try
        //    {
        //        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            PdfWriter writer = new PdfWriter(stream);
        //            PdfDocument pdf = new PdfDocument(writer);
        //            Document document = new Document(pdf);

        //            // إضافة عنوان التقرير
        //            PdfFont font = PdfFontFactory.CreateFont("Arial", PdfEncodings.IDENTITY_H);
        //            Paragraph title = new Paragraph("تقرير المهام")
        //                .SetTextAlignment(TextAlignment.CENTER)
        //                .SetFontSize(18)
        //                .SetFont(font);
        //            document.Add(title);

        //            // إنشاء جدول
        //            Table table = new Table(5).UseAllAvailableWidth();
        //            table.AddHeaderCell(new Cell().Add(new Paragraph("رقم المهمة").SetFont(font)));
        //            table.AddHeaderCell(new Cell().Add(new Paragraph("اسم المهمة").SetFont(font)));
        //            table.AddHeaderCell(new Cell().Add(new Paragraph("الوصف").SetFont(font)));
        //            table.AddHeaderCell(new Cell().Add(new Paragraph("تاريخ الانتهاء").SetFont(font)));
        //            table.AddHeaderCell(new Cell().Add(new Paragraph("الحالة").SetFont(font)));

        //            // تعبئة البيانات
        //            foreach (var task in tasks)
        //            {
        //                table.AddCell(new Cell().Add(new Paragraph(task.Id.ToString()).SetFont(font)));
        //                table.AddCell(new Cell().Add(new Paragraph(task.Title).SetFont(font)));
        //                table.AddCell(new Cell().Add(new Paragraph(task.Description).SetFont(font)));
        //                table.AddCell(new Cell().Add(new Paragraph(task.DueDate.ToString("yyyy-MM-dd") ?? "N/A").SetFont(font)));
        //                table.AddCell(new Cell().Add(new Paragraph(task.Status.ToString()).SetFont(font)));
        //            }

        //            document.Add(table);
        //            document.Close();
        //        }

        //        MessageBox.Show($"تم تصدير التقرير بنجاح إلى: {filePath}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"حدث خطأ أثناء التصدير: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void ExportToExcel()
        {
            var tasks = dataGridView1.DataSource as IEnumerable<dynamic>;

            if (tasks == null || !tasks.Any())
            {
                MessageBox.Show("لا يوجد بيانات للتصدير.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("تقرير المهام");

                // إضافة العناوين مع التنسيق
                var headerRow = worksheet.Range("A1:H1");
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

                worksheet.Cell(1, 1).Value = "رقم المهمة";
                worksheet.Cell(1, 2).Value = "اسم المهمة";
                worksheet.Cell(1, 3).Value = "الوصف";
                worksheet.Cell(1, 4).Value = "تاريخ الانتهاء";
                worksheet.Cell(1, 5).Value = "الحالة";
                worksheet.Cell(1, 6).Value = "الأولوية";
                worksheet.Cell(1, 7).Value = "المستخدم";
                worksheet.Cell(1, 8).Value = "التصنيف";

                int row = 2;
                foreach (var task in tasks)
                {
                    worksheet.Cell(row, 1).Value = task.Id;
                    worksheet.Cell(row, 2).Value = task.Title;
                    worksheet.Cell(row, 3).Value = task.Description;
                    worksheet.Cell(row, 4).Value = task.DueDate != null ? task.DueDate.ToString("yyyy-MM-dd") : "N/A";
                    worksheet.Cell(row, 5).Value = task.Status.ToString();
                    worksheet.Cell(row, 6).Value = task.Priority;
                    worksheet.Cell(row, 7).Value = task.UserName;
                    worksheet.Cell(row, 8).Value = task.Category_Name;
                    row++;
                }

                // توسيع الأعمدة تلقائيًا
                worksheet.Columns().AdjustToContents();

                // إضافة حدود للجدول
                worksheet.Range($"A1:H{row - 1}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Range($"A1:H{row - 1}").Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // حفظ الملف في المسار المحدد
                string filePath = @"D:\TaskReport.xlsx";
                workbook.SaveAs(filePath);
                MessageBox.Show($"تم تصدير التقرير بنجاح إلى: {filePath}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void TaskReports_Load_1(object sender, EventArgs e)
        {
            // تحميل كل الحالات في ComboBox
            cmbStatus.Items.AddRange(new string[] { "", "Completed", "InProgress", "Pending" });

            cmbStatus.SelectedIndex = 0; // تحديد أول عنصر كافتراضي
            LoadTasks(""); // تحميل جميع المهام عند تشغيل الفورم
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedStatus = cmbStatus.SelectedItem.ToString();
          
            LoadTasks(selectedStatus);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            //ExportToPDF();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
