using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using PdfGenerator.Contracts;
using PdfGenerator.Models;

namespace PdfGenerator.Services;

public class PdfGenerator : IPdfGenerator
{
    public async Task<FileContentResult> CreateReport(PdfGenerationModel PdfGenerationModel)
    {
        Document document = new Document();
        var pdfStream = new MemoryStream();
        var writer = PdfWriter.GetInstance(document, pdfStream);

        var currentPath = Directory.GetCurrentDirectory();
        string logoPath = currentPath + "\\" + PdfGenerationModel.ImagePath; // Provide the path to your logo image
        Image logo = Image.GetInstance(logoPath);
        logo.ScaleToFit(100f, 100f); // Adjust the size of the logo as needed

        // document.PageSize.Width / 2 - 60, document.PageSize.Height - 90f
        logo.SetAbsolutePosition(PdfGenerationModel.HeaderImageLocation.Width, PdfGenerationModel.HeaderImageLocation.Height);

        document.Open();

        document.Add(logo);
        var headerTable = new PdfPTable(PdfGenerationModel.HeaderTableColumnCount);

        BaseFont baseFont = BaseFont.CreateFont(PdfGenerationModel.FontDirection, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

        headerTable.DefaultCell.Border = Rectangle.NO_BORDER;
        headerTable.HorizontalAlignment = Element.ALIGN_CENTER;
        if (PdfGenerationModel.IsRTL)
        {
            headerTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        }
        headerTable.WidthPercentage = 100;

        foreach (var cell in PdfGenerationModel.CellContenHeaderList)
        {
            headerTable.AddCell(CreateCell(cell.Title, cell.FontSize, haveBorder: cell.HaveBorder));
        }
        
        document.Add(headerTable);

        var table = new PdfPTable(PdfGenerationModel.BodyTableColumnCount);
        table.HorizontalAlignment = Element.ALIGN_CENTER;
        if (PdfGenerationModel.IsRTL)
        {
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        }

        document.Add(new Paragraph("  "));

        foreach (var cell in PdfGenerationModel.TableContent.CellContentHeaderList)
        {
            table.AddCell(CreateCell(cell.Title, cell.FontSize, isbold: cell.IsBold));
        }

        table.WidthPercentage = 100;
        foreach (var item in PdfGenerationModel.TableContent.CellContenBodyList)
        {
            table.AddCell(CreateCell(item.Title, item.FontSize, item.IsBold,item.HaveBorder));
        }

        document.Add(table);
        document.Close();
        var content = pdfStream.ToArray();

        return new FileContentResult(
                content,
                "application/pdf")
            { FileDownloadName = PdfGenerationModel.Filename +".pdf" };
    }
    public PdfPCell CreateCell(string text, int fontSize, bool haveBorder = true, bool isbold = false,string hoverUrl="")
    {
        BaseFont baseFont = BaseFont.CreateFont("Content\\BNAZANIN.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font = new Font(baseFont, fontSize);
        if (isbold)
        {
            font = new Font(baseFont, fontSize, iTextSharp.text.Font.BOLD);
        }

        var createdCell = new PdfPCell(new Phrase(text, font));
        createdCell.HorizontalAlignment = Element.ALIGN_CENTER;
        if (!haveBorder)
        {
            createdCell.Border = Rectangle.NO_BORDER;
        }

        if (hoverUrl!="")
        {
            var anchor = new Chunk(text) { };
            anchor.SetAnchor(hoverUrl);
            Phrase p = new Phrase();
            p.Add(anchor); 
            createdCell = new PdfPCell(p);
        }

        return createdCell;
    }
}