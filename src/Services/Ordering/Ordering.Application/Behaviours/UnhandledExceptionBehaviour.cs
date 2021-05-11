using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace src.Services.Ordering.Ordering.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;

        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError($"Application request: Unhandled Exception for Request {requestName}, {request}: {ex.Message}.");
                throw;
            }
            
        }
    }
}