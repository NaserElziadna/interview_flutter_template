using System;

namespace PizzaBE.RestApi.Models
{
    public class MyCustomApiResponse<TPayLoad>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TPayLoad Payload { get; set; }
        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        public MyCustomApiResponse(TPayLoad payload = default(TPayLoad),
                                   string message = "",
                                   int statusCode = 200)
        {
            this.Code = statusCode;
            this.Message = message == string.Empty ? "Success" : message;
            this.Payload = payload;
        }

        public MyCustomApiResponse(TPayLoad payload = default(TPayLoad))
        {
            this.Code = 200;
            this.Message = "Success";
            this.Payload = payload;
        }
    }
}
