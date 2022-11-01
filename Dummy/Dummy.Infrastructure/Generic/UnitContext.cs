
using Dummy.Infrastructure.Context;

namespace Dummy.Infrastructure.Generic
{
    public class UnitContext : IUnitContext
    {
        public DummyContext Context { get; }
        public UnitContext(DummyContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
