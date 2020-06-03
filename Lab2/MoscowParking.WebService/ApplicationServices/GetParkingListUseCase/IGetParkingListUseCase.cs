using System;
using System.Collections.Generic;
using System.Text;
using MoscowParking.ApplicationServices.Interfaces;

namespace MoscowParking.ApplicationServices.GetParkingListUseCase
{
    public interface IGetParkingListUseCase : IUseCase<GetParkingListUseCaseRequest, GetParkingListUseCaseResponse>
    {
    }
}
