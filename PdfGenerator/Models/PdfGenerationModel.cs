namespace PdfGenerator.Models;

public class PdfGenerationModel
{
    /// <summary>
    /// set pdf file name
    /// </summary>
    public string? Filename { get; set; } = Guid.NewGuid().ToString();
    /// <summary>
    /// alocate a image address for show in header of pdf
    /// </summary>
    public string ImagePath { get; set; }
    /// <summary>
    /// if you want to change font from B-Nazanin
    /// </summary>
    public string FontDirection { get; set; }
    /// <summary>
    /// Header image location in the page
    /// </summary>
    public HeaderImageLocation HeaderImageLocation { get; set; }
    /// <summary>
    /// header grid column number 
    /// </summary>
    public int HeaderTableColumnCount { get; set; }
    /// <summary>
    /// body grid column number
    /// </summary>
    public int BodyTableColumnCount { get; set; }
    /// <summary>
    /// set list of content for header 
    /// </summary>
    public List<CellContent> CellContenHeaderList { get; set; }
    /// <summary>
    /// set body table content such as header of table and content of table
    /// </summary>
    public TableContent TableContent { get; set; }
    /// <summary>
    /// if you want to make pdf right to left for persian and arabic ,...
    /// </summary>
    public bool IsRTL { get; set; }
}