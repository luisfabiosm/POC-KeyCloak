using Refit;

namespace Domain.Models.Response
{
    public record SistemaResponse
    {
        public BaseError? Error { get; set; }

        public object DataResponse {get;set;}


        public SistemaResponse(object dataresponse  )
        {
            this.DataResponse = dataresponse;
        }

    }
}
