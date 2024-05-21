using Microsoft.AspNetCore.Mvc;
using PdfGenerator.Models;

namespace PdfGenerator.Contracts;

public interface IPdfGenerator
{ 
    Task<FileContentResult> CreateReport(PdfGenerationModel PdfGenerationModel);
}