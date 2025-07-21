using AFHOfficeApp.Models.v1;
using AFHOfficeApp.Services.v1;
using Microsoft.AspNetCore.Mvc;

namespace AFHOfficeApp.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OfficesController(IOfficeService officeService) : ControllerBase
    {
        [HttpGet]
        public async Task<GenericHttpResponseModel<List<OfficeLocation>>> GetPaged([FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 4)
        {
            return await officeService.GetPageAsync(pageIndex, pageSize);
        }
    }
}