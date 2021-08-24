using DanskeBank.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank.API.Core.Core.Middleware
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;

        public UnitOfWorkMiddleware(RequestDelegate next
           )
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
        {

            try
            {
                await _next(context);
                int result = await unitOfWork.CommitAsync();

                Console.WriteLine(result);
            }
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            catch (Exception ex)
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
