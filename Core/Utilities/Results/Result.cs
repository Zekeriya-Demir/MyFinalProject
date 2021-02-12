using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result( bool success, string message):this(success) // tek parametreli constructor'a bu parametreyi gönder.
        {
            Message = message;
            
        }

        // Kullanıcıya mesaj göstermek istemiyorsak opsiyon olarak ikinci constructor'ı ekliyoruz.
        public Result(bool success )
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }


        // get read only'dir. read only'ler constructor'larda set edilebilirler.
    }
}
