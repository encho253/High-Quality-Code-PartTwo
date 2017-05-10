using System.Collections.Generic;

namespace ProjectManagerSystem.Core.Providers.Contracts
{
    public interface IValidator
    {
        void Validate<T>(T obj) where T : class;

        IEnumerable<string> GetValidationErrors(object obj);
    }
}