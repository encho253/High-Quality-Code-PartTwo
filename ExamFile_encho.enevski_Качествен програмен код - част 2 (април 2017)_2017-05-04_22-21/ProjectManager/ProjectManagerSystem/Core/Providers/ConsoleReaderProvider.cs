using ProjectManagerSystem.Core.Providers.Contracts;
using System;

namespace ProjectManagerSystem.Core.Providers
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}