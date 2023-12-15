using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.Entities;

namespace VirtualPetCare.Data.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        
        private readonly IMapper _mapper;

        private readonly VirtualPetCareDbContext _context;

        public TypeRepository(IMapper mapper, VirtualPetCareDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<bool> DoesTypeExists(string typeName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<int>> GetTypeIntegerIdsAsync(ICollection<string> petTypeNames)
        {
            List<int> ids = new List<int>();


            var petTypeList = await _context.PetTypes.ToListAsync();

            foreach(var petType in petTypeList) 
            {
                if (petTypeNames.Any(type => string.Equals(type, petType.ThePetType.ToString(), StringComparison.OrdinalIgnoreCase)))
                {
                    ids.Add(petType.Id);
                }
            }

            return ids;

        }
    }
}