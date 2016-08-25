namespace Bunnies.Contracts
{
    using System;

    public interface IStreamWriter : IDisposable
    {
        void WriteLine(string value);
    }
}
