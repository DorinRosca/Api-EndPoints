using ApiEndPoints.Features.Brands.Entities;
using ApiEndPoints.Features.Vehicles.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Cars.Dto
{
    public class CarFilterDto
    {
        public List<CarDto> Cars { get; set; }
        //selected filter
        public List<byte> SelectedVehicleId { get; set; }
        public List<byte> SelectedBrandId { get; set; }
        //filters
        public string SearchCarName { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Brand> Brands { get; set; }

        public CarFilterDto()
        {
            SelectedBrandId = new List<byte>();
            SelectedVehicleId = new List<byte>();
        }
    }
}
