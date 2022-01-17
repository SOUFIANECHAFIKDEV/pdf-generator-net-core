using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReports.Controllers
{
    public class Reportcs
    {
        #region
        int _totalColumn = 3;
        Document _docuement;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        #endregion

        public byte[] PrepareReport()
        {
            #region
            _docuement = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _docuement.SetPageSize(PageSize.A4);
            _docuement.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_docuement, _memoryStream);
            _docuement.Open();
            _pdfTable.SetWidths(new float[] { 20f, 150f, 100f });
            #endregion

            this.ReportHeader();
            this.ReportBody();
            _pdfTable.HeaderRows = 2;
            _docuement.Add(_pdfTable);
            _docuement.Close();
            return _memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);
            string ARIALUNI_TFF = @"C:\my files\projects\PDFReports\PDFReports\Reports\Hacen-Liner-Print-out-Light.ttf";
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font f = new Font(bf, 12);

            //infoClient.AddCell(new PdfPCell(new Paragraph(new Chunk("Devis n°  ", fontH10B))) { BorderWidth = 0.75f, BorderColor = borderBotomColor, Padding = 5f, BackgroundColor = tableHeaderColor, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 2 });
            //infoClient.AddCell(new PdfPCell(new Paragraph(new Chunk("Date", fontH10B))) { BorderWidth = 0.75f, BorderColor = borderBotomColor, Padding = 5f, BackgroundColor = tableHeaderColor, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 2 });

            _fontStyle = f;
            _pdfPCell = new PdfPCell(new Phrase("رخصة اللاعب", f));
            //_pdfPCell = new PdfPCell(Paragraph(new Chunk("Devis n°  ")));
            _pdfPCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            //_pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            /*_pdfPCell = new PdfPCell(new Phrase("برسم الموسم الدراسي", f));
            //_pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("2019/2020", f));
            //_pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();*/
        }

        private void ReportBody()
        {
            //#region Table header
            //_fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            //_pdfPCell = new PdfPCell(new Phrase("Serial Number", _fontStyle));
            //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfTable.AddCell(_pdfPCell);

            //_pdfPCell = new PdfPCell(new Phrase("Name", _fontStyle));
            //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfTable.AddCell(_pdfPCell);

            //_pdfPCell = new PdfPCell(new Phrase("Roll", _fontStyle));
            //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfTable.AddCell(_pdfPCell);
            //#endregion
        }
    }
}