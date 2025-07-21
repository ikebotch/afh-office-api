using AFHOfficeApp.Models.v1;

namespace AFHOfficeApp.Services.v1
{
    public interface IOfficeService
    {
        Task<GenericHttpResponseModel<List<OfficeLocation>>> GetPageAsync(int pageIndex, int pageSize);
    }
}