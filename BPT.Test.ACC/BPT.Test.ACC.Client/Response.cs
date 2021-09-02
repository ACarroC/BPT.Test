using System;
using System.Collections.Generic;
using System.Text;

namespace BPT.Test.ACC.Client
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public string EstatusCode { get; set; }
    }

    public class ErrorReponse
    {
        public string message { get; set; }
    }
}
