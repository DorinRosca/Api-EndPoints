using ApiEndPoints.Features.Brands.Entities;
using ApiEndPoints.Features.Cars.Dto;
using ApiEndPoints.Features.Vehicles.Entities;
using MediatR;

namespace ApiEndPoints.Features.Cars.Query.GetAll
{
    public record GetFilteredCarsQuery(CarFilterDto model) : IRequest<CarFilterDto>
     {
          public List<CarDto> Cars = model.Cars;
          //selected filter
          public List<byte> SelectedVehicleId = model.SelectedVehicleId;

          public List<byte> SelectedBrandId = model.SelectedBrandId;
          //filters
          public string SearchCarName = model.SearchCarName;
          public List<Vehicle> Vehicles = model.Vehicles;
          public List<Brand> Brands = model.Brands;

     }
}
