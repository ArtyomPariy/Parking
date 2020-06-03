using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowParking.DomainObjects;
using MoscowParking.ApplicationServices.GetParkingListUseCase;
using MoscowParking.InfrastructureServices.Presenters;

namespace MoscowParking.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingsController : ControllerBase
    {
        private readonly ILogger<ParkingsController> _logger;
        private readonly IGetParkingListUseCase _getParkingListUseCase;

        public ParkingsController(ILogger<ParkingsController> logger,
                                IGetParkingListUseCase getParkingListUseCase)
        {
            _logger = logger;
            _getParkingListUseCase = getParkingListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllParkings()
        {
            var presenter = new ParkingListPresenter();
            await _getParkingListUseCase.Handle(GetParkingListUseCaseRequest.CreateAllParkingsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{parkingId}")]
        public async Task<ActionResult> GetParking(long parkingId)
        {
            var presenter = new ParkingListPresenter();
            await _getParkingListUseCase.Handle(GetParkingListUseCaseRequest.CreateParkingRequest(parkingId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("Addresses/{address}")]
        public async Task<ActionResult> GetAddressFilter(string address)
        {
            var presenter = new ParkingListPresenter();
            await _getParkingListUseCase.Handle(GetParkingListUseCaseRequest.CreateOrganizationParkingsRequest(address), presenter);
            return presenter.ContentResult;
        }
    }
}