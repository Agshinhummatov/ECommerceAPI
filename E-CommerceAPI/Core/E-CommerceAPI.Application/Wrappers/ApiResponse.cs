using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Wrappers
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(int statusCode, string message, T data = default)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public static ApiResponse<T> Success(T data, string message = "")
        {
            return new ApiResponse<T>(StatusCodes.Status200OK, message, data);
        }

        public static ApiResponse<T> Created(T data, string message = "")
        {
            return new ApiResponse<T>(StatusCodes.Status201Created, message, data);
        }

        public static ApiResponse<T> NotFound(string message)
        {
            return new ApiResponse<T>(StatusCodes.Status404NotFound, message);
        }

        public static ApiResponse<T> BadRequest(string message)
        {
            return new ApiResponse<T>(StatusCodes.Status400BadRequest, message);
        }

        public static ApiResponse<T> InternalServerError(string message)
        {
            return new ApiResponse<T>(StatusCodes.Status500InternalServerError, message);
        }

    }
}
