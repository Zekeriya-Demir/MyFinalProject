using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Hem data hem de mesaj ve işlem sonucu içerecek.
    public interface IDataResult<T>:IResult  // aynı zamanda mesaj ve işlem sonucu göndereceğimiz için IResult interfaceni implement ediyoruz.
    {
        T Data { get; }
    }
}
