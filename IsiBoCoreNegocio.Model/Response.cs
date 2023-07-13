using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Model
{
    public class Response<T>
    {
        public bool estado { get; set; }
        public StatusCode codigo { get; set; }
        public string? mensaje { get; set; }
        public T? data { get; set; }
        public static Response<T> Success(T content)
        {
            return new Response<T>() { data = content, codigo = StatusCode.OK, mensaje = "Correcto!", estado = true };
        }
        public static Response<T> Error(StatusCode code, string message)
        {
            return new Response<T>() { codigo = code, mensaje = message };
        }
        public static Response<T> UnhandledError(string message = "")
        {
            return new Response<T>() { mensaje = "UnhandledError: " + message, codigo = StatusCode.UnhandledError, data = default(T) };
        }
    }
    public enum StatusCode
    {
        OK = 200,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        UnhandledError = 500,
        ExcepcionError = 500,
    }
}
