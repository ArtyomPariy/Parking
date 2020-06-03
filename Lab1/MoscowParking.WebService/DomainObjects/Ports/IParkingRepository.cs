using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowParking.DomainObjects.Ports
{
    public interface IReadOnlyRouteRepository
    {
        Task<Parking> GetParking(long id);

        Task<IEnumerable<Parking>> GetAllParkings();

        Task<IEnumerable<Parking>> QueryParkings(ICriteria<Parking> criteria);

    }

    public interface IParkingRepository
    {
        Task AddRoute(Parking parking);

        Task RemoveRoute(Parking parking);

        Task UpdateRoute(Parking parking);
    }
}
