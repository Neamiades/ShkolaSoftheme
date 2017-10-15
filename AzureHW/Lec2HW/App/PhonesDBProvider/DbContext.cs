using System;

namespace PhonesDBProvider
{
    public static class DbContext
    {
        private static readonly Lazy<PhonesDBEntities> ContextLazy = new Lazy<PhonesDBEntities>(() => new PhonesDBEntities());
        public static PhonesDBEntities Context => ContextLazy.Value;
    }
}
