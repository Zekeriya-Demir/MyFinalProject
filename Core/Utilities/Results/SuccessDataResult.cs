using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        // işlem sonucu default : true
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        // Çok az kullanılır. Datayı Default haliyle kullanır.Sadece mesaj içerir.
        // default dataya karşılık gelir.Product'ın defaultu null'dır.
        public SuccessDataResult(string message) : base(default,true,message)
        {

        }
        // Bu opsiyon da az kullanılır.
        // Burada hiçbir şey verimiyoruz mesaj göndermiyoruz, base e sadece default ve true gönderiyoruz.
        // default dataya karşılık gelir.Product'ın defaultu null'dır.
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
