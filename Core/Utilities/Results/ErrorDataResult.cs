using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        // işlem sonucu default : false
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        // Çok az kullanılır. Datayı Default haliyle kullanır.Sadece mesaj içerir.
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        // Bu opsiyon da az kullanılır.
        // Burada hiçbir şey verimiyoruz mesaj göndermiyoruz, base e sadece default ve false gönderiyoruz.
        // default dataya karşılık gelir.
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
