using MoscowParking.ApplicationServices.GetParkingListUseCase;
using System.Net;
using Newtonsoft.Json;
using MoscowParking.ApplicationServices.Ports;

namespace MoscowParking.InfrastructureServices.Presenters
{
    public class ParkingListPresenter : IOutputPort<GetParkingListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ParkingListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetParkingListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Parkings) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
