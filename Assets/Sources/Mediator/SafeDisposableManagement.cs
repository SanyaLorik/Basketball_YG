using System;
using System.Collections.Generic;

namespace Basketball_YG.Mediator
{
    public class SafeDisposableManagement : IDisposable
    {
        private readonly List<IDisposable> _disposables = new();

        public void Dispose()
        {
            foreach (var disposable in _disposables)
                disposable.Dispose();

            _disposables.Clear();
        }

        public void AddDisposable(params IDisposable[] disposables)
        {
            _disposables.AddRange(disposables);
        }
    }
}