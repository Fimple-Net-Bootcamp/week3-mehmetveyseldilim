using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetCare.Data.Contracts
{
    public interface IRepositoryManager
    {
        IAuthenticationRepository AuthenticationRepository { get; }

        IActivityRepository ActivityRepository { get; }

        IFoodRepository FoodRepository { get; }

        IHealthRepository HealthRepository { get; }

        IPetRepository PetRepository { get; }

        ITypeRepository TypeRepository {get;}

    }
}