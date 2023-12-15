using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetCare.Data.Contracts
{
    public interface ITypeRepository
    {
        Task<bool> DoesTypeExists(string typeName);

        Task<IEnumerable<int>> GetTypeIntegerIdsAsync(ICollection<string> petTypeNames);
    }
}