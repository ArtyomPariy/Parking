using MoscowParking.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowParking.ApplicationServices.GetParkingListUseCase
{
    public class GetParkingListUseCaseRequest : IUseCaseRequest<GetParkingListUseCaseResponse>
    {
        public string Address { get; private set; }
        public long? ParkingId { get; private set; }

        private GetParkingListUseCaseRequest()
        { }

        public static GetParkingListUseCaseRequest CreateAllParkingsRequest()
        {
            return new GetParkingListUseCaseRequest();
        }

        public static GetParkingListUseCaseRequest CreateParkingRequest(long parkingId)
        {
            return new GetParkingListUseCaseRequest() { ParkingId = parkingId };
        }
        public static GetParkingListUseCaseRequest CreateOrganizationParkingsRequest(string address)
        {
            return new GetParkingListUseCaseRequest() { Address = address };
        }
    }
}
