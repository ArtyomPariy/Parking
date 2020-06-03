using MoscowParking.DomainObjects;
using MoscowParking.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowParking.ApplicationServices.Repositories
{
    public class InMemoryParkingRepository : IReadOnlyParkingRepository,
                                             IParkingRepository 
    {
        private readonly List<Parking> _parkings = new List<Parking>();

        public InMemoryParkingRepository(IEnumerable<Parking> parkings = null)
        {
            if (parkings != null)
            {
                _parkings.AddRange(parkings);
            }
        }

        public Task AddParking(Parking parking)
        {
            _parkings.Add(parking);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Parking>> GetAllParkings()
        {
            return Task.FromResult(_parkings.AsEnumerable());
        }

        public Task<Parking> GetParking(long id)
        {
            return Task.FromResult(_parkings.Where(p => p.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Parking>> QueryParkings(ICriteria<Parking> criteria)
        {
            return Task.FromResult(_parkings.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveParking(Parking parking)
        {
            _parkings.Remove(parking);
            return Task.CompletedTask;
        }

        public Task UpdateParking(Parking parking)
        {
            var foundParking = GetParking(parking.Id).Result;
            if (foundParking == null)
            {
                AddParking(parking);
            }
            else
            {
                if (foundParking != parking)
                {
                    _parkings.Remove(foundParking);
                    _parkings.Add(parking);
                }
            }
            return Task.CompletedTask;
        }
    }
}
