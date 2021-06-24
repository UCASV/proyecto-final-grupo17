using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;
using ProyectoFinalPOOBD.FunctionsMeanwhile;
using ProyectoFinalPOOBD.Repository;
using iText.Layout;
using iText.Layout.Element;
using Document = iText.Layout.Document;

namespace ProyectoFinalPOOBD.Views
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            CreatePdf();
        }

        private void CreatePdf()
        {
            SaveFileDialog pathDialog = new SaveFileDialog();
            pathDialog.Filter = "PDF document (*.pdf)|*.pdf";
            DialogResult response = pathDialog.ShowDialog();

            if (response == DialogResult.OK)
            {
                PdfWriter pdfW = new PdfWriter(pathDialog.FileName);
                PdfDocument pdf = new PdfDocument(pdfW);
                Document document = new Document(pdf, PageSize.LETTER);

                document.SetMargins(60, 20, 55, 20);
                var prueba = new UserServices().Find(1);
                string detalle = "User: " + prueba.Username + Environment.NewLine;
                detalle += "Password: " + prueba.Password;
                Paragraph text = new Paragraph(detalle);

                document.Add(text);
                document.Close();
            }
        }
    }
}
