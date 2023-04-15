using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Attributes;
using System.Text;
using System.Text.Json;

namespace MiddleWare_Sample.ResultViewModel
{
    public class FuncResult
    {
        public Status Status { set; get; }
        public bool IsSuccess { get; set; }
        public Error Error { set; get; }

        public object Entity { set; get; }
        public long? Total { set; get; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }



    }


    public enum Status
    {
        ok = 200,
        created = 201,
        Modified = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500

        
        
    }

}
