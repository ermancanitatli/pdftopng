using Microsoft.AspNetCore.Mvc;
using PDFconverter.Contract;
using PDFconverter.Helpers;
using System.Drawing.Imaging;
using PdfiumViewer;

namespace PDFconverter.Controllers;

[Route("api/converter")]
public class ConvertController: BaseController
{
    
    [HttpPut("pdf")]
    [ProducesResponseType(typeof(CustomResponseHelper<OkResult>), 200)]
    [ProducesResponseType(typeof(CustomResponseHelper), 404)]
    public async Task<IActionResult> UpdateName([FromBody] PdfContract request)
    {
        try
        {
            
            using (var document = PdfDocument.Load(request.FilePath))
            {
                
                using (var image = document.Render(0, 300, 300, false))
                {
                    image.Save("pdf/"+request.FileName, ImageFormat.Png);
                }
            }

            return OkResponse();
        }
        catch (Exception ex)
        {
            return BadRequestResponse(ex.Message);
        }
    }
    
    
}