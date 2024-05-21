using PdfGenerator.Enums;

namespace PdfGenerator.Models;

public class TableContent
{
    /// <summary>
    ///     Set Table Direction
    /// </summary>
    public TableDirection TableDirection { get; set; }
    /// <summary>
    ///     Set Table Header info
    /// </summary>
    public List<CellContent> CellContentHeaderList { get; set; }
    /// <summary>
    ///     Set Table Content body
    /// </summary>
    public List<CellContent> CellContenBodyList { get; set; }
}