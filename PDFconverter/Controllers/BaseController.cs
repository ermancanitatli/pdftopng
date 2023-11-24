using Microsoft.AspNetCore.Mvc;
using System.Net;
using PDFconverter.Controllers;
using PDFconverter.Helpers;


[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    protected IActionResult OkResponse(object? result = null)
    {
        if (result == null)
            return StatusCode((int)HttpStatusCode.OK, CustomResponseHelper.Success())
                ;

        return StatusCode((int)HttpStatusCode.OK, CustomResponseHelper.Success<object?>(result));
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    protected IActionResult BadRequestResponse(string? errorMessage = null, object? data = null, int? errorCode = null)
    {
        if (string.IsNullOrEmpty(errorMessage)) errorMessage = "";

        if (data == null)
            return StatusCode((int)HttpStatusCode.BadRequest, CustomResponseHelper.Error(errorMessage, errorCode));

        return StatusCode((int)HttpStatusCode.BadRequest,
            CustomResponseHelper.Error<object?>(data, errorMessage, errorCode));
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    protected IActionResult NotFoundResponse(string? errorMessage = null)
    {
        if (string.IsNullOrEmpty(errorMessage)) errorMessage = "kayıt bulunamadı";

        return StatusCode((int)HttpStatusCode.NotFound,
            CustomResponseHelper.Error(errorMessage, (int)HttpStatusCode.NotFound));
    }
}