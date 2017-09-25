using System;
using System.IO;

namespace ConsoleMemoryApp
{
    class ResourceHolderBase : IDisposable
    {
        private readonly StreamWriter _resource;
        private bool _disposed;

        public ResourceHolderBase(string path) => _resource = new StreamWriter(path);

        protected ResourceHolderBase() => Console.WriteLine("Empty ResourceHolderBase constructor");

        ~ResourceHolderBase() => Dispose(false);

        public void Write(string text) => _resource.Write(text);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _resource?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
