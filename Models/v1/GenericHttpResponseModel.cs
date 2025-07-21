namespace AFHOfficeApp.Models.v1
{
    public class GenericHttpResponseModel<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T? Payload { get; set; }
        public PaginationMetaData? PaginationMetaData { get; set; }
    }

    public class PaginationMetaData
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}