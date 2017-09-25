using System;
using System.IO;

namespace ConsoleMemoryApp
{
    class ResourceHolderDerived : ResourceHolderBase, IDisposable
    {
        private readonly StreamReader _resource;

        public ResourceHolderDerived(string path) => _resource = new StreamReader(path);

        ~ResourceHolderDerived() => Dispose(false);

        public string Read() => _resource.ReadToEnd(); 

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
