using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowParking.DomainObjects.Ports
{
    public interface IReadOnlyParkingRepository
    {
        Task<Parking> GetParking(long id);

        Task<IEnumerable<Parking>> GetAllParkings();

        Task<IEnumerable<Parking>> QueryParkings(ICriteria<Parking> criteria);

    }

    public interface IParkingRepository
    {
        Task AddParking(Parking parking);

        Task RemoveParking(Parking parking);

        Task UpdateParkings(Parking parking);
    }
}
