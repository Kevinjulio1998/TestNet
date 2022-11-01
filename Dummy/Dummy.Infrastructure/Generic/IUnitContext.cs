using System;
using Dummy.Infrastructure.Context;

namespace Dummy.Infrastructure.Generic
{
    public interface IUnitContext  : IDisposable
    {
        DummyContext Context { get; }
        void Commit();
    }
}
