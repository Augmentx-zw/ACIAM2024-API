using System;

namespace Ark.Gateway.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
