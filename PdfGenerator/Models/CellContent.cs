using PdfGenerator.Enums;

namespace PdfGenerator.Models;

/// <summary>
///     A cell in a Table.
/// </summary>
public class CellContent
{
    /// <summary>
    ///     Cell Text
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    ///     Cell Font Size
    /// </summary>
    public int FontSize { get; set; }
    /// <summary>
    ///    when it is number have Separator between each 3 character
    /// </summary>
    public int IsNumber { get; set; }
    /// <summary>
    ///     Cell Font Is Bold or not
    /// </summary>
    public bool IsBold { get; set; } = false;
    /// <summary>
    ///     Cell Font Have Border
    /// </summary>
    public bool HaveBorder { get; set; } = false;
    /// <summary>
    ///     Cell Font Have Border
    /// </summary>
    public CellAlignment CellAlignment { get; set; } = CellAlignment.Center;

    /// <summary>
    ///     Set Url to cell when click into it call the url
    /// </summary>
    public string HoverUrl { get; set; } = "";
}