using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VirtualPetCare.Data.Contracts;

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
    }
}