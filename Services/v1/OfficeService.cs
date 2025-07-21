using AFHOfficeApp.Models.v1;

namespace AFHOfficeApp.Services.v1;

public class OfficeService : IOfficeService
{
    private readonly string _apiUrl;
    private readonly HttpClient _httpClient;
    private readonly ILogger<OfficeService> _logger;


    public OfficeService(HttpClient httpClient, IConfiguration config, ILogger<OfficeService> logger)
    {
        var apiUrl = config.GetValue<string>("AfhApiUrl");

        // Check if connection url not null or white space
        if (string.IsNullOrWhiteSpace(apiUrl)) throw new ArgumentException("AfhApiUrl is missing in configuration.");

        _httpClient = httpClient;
        _logger = logger;
        _apiUrl = apiUrl;
    }


    public async Task<GenericHttpResponseModel<List<OfficeLocation>>> GetPageAsync(int pageIndex, int pageSize)
    {
        try
        {
            // Fetch Office location 
            var allOffices = await GetAllOfficesAsync();
            var totalCount = allOffices.Count;

            // Enforce 1-based indexing
            if (pageIndex < 1)
                return new GenericHttpResponseModel<List<OfficeLocation>>
                {
                    Status = "failed",
                    Message = "Page index must be 1 or greater.",
                    Payload = new List<OfficeLocation>()
                };

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // Prevent requesting a page that doesn't exist
            if (pageIndex > totalPages)
                return new GenericHttpResponseModel<List<OfficeLocation>>
                {
                    Status = "failed",
                    Message = $"Page index exceeds total pages ({totalPages}).",
                    Payload = new List<OfficeLocation>()
                };

            // Use Skip/Take for pagination logic
            var pagedOffices = allOffices
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new GenericHttpResponseModel<List<OfficeLocation>>
            {
                Status = "success",
                Message = "Office locations retrieved successfully.",
                Payload = pagedOffices,
                PaginationMetaData = new PaginationMetaData
                {
                    Page = pageIndex,
                    PageSize = pageSize,
                    TotalPages = totalPages,
                    TotalRecords = totalCount
                }
            };
        }
        catch (Exception ex)
        {
            // Generate a reference ID to help trace the error in logs
            var errorId = Guid.NewGuid().ToString();
            _logger.LogError(ex, "Error retrieving office locations. Reference ID: {ErrorId}", errorId);

            return new GenericHttpResponseModel<List<OfficeLocation>>
            {
                Status = "failed",
                Message = $"An unexpected error occurred. Please contact support with reference ID: {errorId}",
                Payload = new List<OfficeLocation>()
            };
        }
    }


    private async Task<List<OfficeLocation>> GetAllOfficesAsync()
    {
        try
        {
            //Fetch all office locations from the external API.
            var response = await _httpClient.GetFromJsonAsync<List<OfficeLocation>>(_apiUrl);
            return response ?? new List<OfficeLocation>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching office data from AFH API.");
            return new List<OfficeLocation>();
        }
    }
}