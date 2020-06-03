using System.Threading.Tasks;
using System.Collections.Generic;
using MoscowParking.DomainObjects;
using MoscowParking.DomainObjects.Ports;
using MoscowParking.ApplicationServices.Ports;

namespace MoscowParking.ApplicationServices.GetParkingListUseCase
{
    public class GetParkingListUseCase : IGetParkingListUseCase
    {
        private readonly IReadOnlyParkingRepository _readOnlyParkingRepository;

        public GetParkingListUseCase(IReadOnlyParkingRepository readOnlyParkingRepository) 
            => _readOnlyParkingRepository = readOnlyParkingRepository;

        public async Task<bool> Handle(GetParkingListUseCaseRequest request, IOutputPort<GetParkingListUseCaseResponse> outputPort)
        {
            IEnumerable<Parking> parkings = null;
            if (request.ParkingId != null)
            {
                var parking = await _readOnlyParkingRepository.GetParking(request.ParkingId.Value);
                parkings = (parking != null) ? new List<Parking>() { parking } : new List<Parking>();
                
            }
            else if (request.Address != null)
            {
                parkings = await _readOnlyParkingRepository.QueryParkings(new AddressCriteria(request.Address));
            }
            else
            {
                parkings = await _readOnlyParkingRepository.GetAllParkings();
            }
            outputPort.Handle(new GetParkingListUseCaseResponse(parkings));
            return true;
        }
    }
}
