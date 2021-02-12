using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message) // Kalıtım aldığı classın iki parametreli constructor2a gönderir.
        {

        }

        public SuccessResult():base(true) // Kalıtım aldığı classın tek parametreli constructor2a gönderir.
        {

        }
    }
}
