using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallApi.Services.Base
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(T objectParam)
        {
            Success = true;
            Message = string.Empty;
            ObjectReturn = objectParam;
        }

        public ServiceResponse(string ErrorMessage)
        {
            Success = false;
            Message = ErrorMessage;
            ObjectReturn = default;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T ObjectReturn { get; private set; }
    }
}
