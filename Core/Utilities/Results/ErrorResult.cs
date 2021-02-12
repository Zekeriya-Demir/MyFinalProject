using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message) // Kalıtım aldığı classın iki parametreli constructor2a gönderir.
        {

        }

        public ErrorResult() : base(false) // Kalıtım aldığı classın tek parametreli constructor2a gönderir.
        {

        }
    }
}
