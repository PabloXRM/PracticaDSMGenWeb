
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;
using System.IO;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Factura_generarPDF) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class FacturaCEN
{
public void GenerarPDF (int p_oid)
{
            /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Factura_generarPDF) ENABLED START*/

           /* var en = _IFacturaRepository.ReadOID(p_oid);
            if (en == null) throw new ModelException("Factura no encontrada: " + p_oid);

            // Ruta de salida
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdf");
            Directory.CreateDirectory(folder);
            string fullPath = Path.Combine(folder, $"factura_{p_oid}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            // Generar PDF con PdfSharp
            var doc = new PdfSharp.Pdf.PdfDocument();
            doc.Info.Title = $"Factura {p_oid}";

            var page = doc.AddPage();
            var gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
            var fontTitle = new PdfSharp.Drawing.XFont("Arial", 16, PdfSharp.Drawing.XFontStyle.Bold);
            var fontBody = new PdfSharp.Drawing.XFont("Arial", 11, PdfSharp.Drawing.XFontStyle.Regular);

            double x = 40, y = 50, line = 20;
            gfx.DrawString("TempoShop - Factura", fontTitle, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(x, y, page.Width - 2 * x, line), PdfSharp.Drawing.XStringFormats.TopLeft); y += line * 1.8;
            gfx.DrawString($"Id: {en.Id}", fontBody, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(x, y, page.Width - 2 * x, line), PdfSharp.Drawing.XStringFormats.TopLeft); y += line;
            gfx.DrawString($"Fecha: {en.Fecha:dd/MM/yyyy}", fontBody, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(x, y, page.Width - 2 * x, line), PdfSharp.Drawing.XStringFormats.TopLeft); y += line;
            gfx.DrawString($"Total: {en.Total}", fontBody, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(x, y, page.Width - 2 * x, line), PdfSharp.Drawing.XStringFormats.TopLeft); y += line;

            doc.Save(fullPath);
            doc.Close();

            // (Opcional) guardar la ruta en la entidad si tienes un campo tipo ficheroUrl
            // en.FicheroUrl = fullPath;
            // _IFacturaRepository.ModifyDefault(en);

            return fullPath;
           */
            /*PROTECTED REGION END*/
        }
}
}
