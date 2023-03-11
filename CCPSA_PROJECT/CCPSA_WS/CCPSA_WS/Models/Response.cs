using System;
namespace CCPSA_WS.Models
{
    public class Response
    {
        public int httpResponseStatusCode { get; set; }
        public bool success { get; set; }
        public object? data { get; set; }
        public string? message { get; set; }
    }
}

