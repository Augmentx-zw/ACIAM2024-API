using Microsoft.Extensions.DependencyInjection;
using System;
using Ark.Gateway.Domain.CommandHandler;
using Ark.Gateway.Domain.QueryHandlers;

namespace Ark.Gateway.API.BE
{
    public class Mediator
    {
        private readonly IServiceProvider _provider;

        public Mediator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Dispatch(ICommand command)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                Type type = typeof(ICommandHandler<>);
                Type[] typeArgs = { command.GetType() };
                Type handlerType = type.MakeGenericType(typeArgs);

                dynamic handler = scope.ServiceProvider.GetRequiredService(handlerType);
                handler.Handle((dynamic)command);
            }
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                Type type = typeof(IQueryHandler<,>);
                Type[] typeArgs = { query.GetType(), typeof(T) };
                Type handlerType = type.MakeGenericType(typeArgs);

                dynamic handler = scope.ServiceProvider.GetRequiredService(handlerType);
                T result = handler.Handle((dynamic)query);

                return result;
            }
        }
    }
}

