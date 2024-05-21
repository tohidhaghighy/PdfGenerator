namespace PdfGenerator.Models;

public class PdfGenerationModel
{
    public string Filename { get; set; }
    public string ImagePath { get; set; }
    public string FontDirection { get; set; }
    public HeaderImageLocation HeaderImageLocation { get; set; }
    public int HeaderTableColumnCount { get; set; }
    public int BodyTableColumnCount { get; set; }
    public List<CellContent> CellContenHeaderList { get; set; }
    public TableContent TableContent { get; set; }
    public bool IsRTL { get; set; }
}