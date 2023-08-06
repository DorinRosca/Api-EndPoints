using AutoMapper;
using ApiEndPoints.Features.Brands.Command.Create;
using ApiEndPoints.Features.Brands.Command.Edit;
using ApiEndPoints.Features.Brands.Entities;
using ApiEndPoints.Features.Brands.Dto;
using ApiEndPoints.Features.Drives.Command.Create;
using ApiEndPoints.Features.Drives.Command.Edit;
using ApiEndPoints.Features.Drives.Entities;
using ApiEndPoints.Features.Drives.Dto;
using ApiEndPoints.Features.FuelTypes.Command.Create;
using ApiEndPoints.Features.FuelTypes.Command.Edit;
using ApiEndPoints.Features.FuelTypes.Entities;
using ApiEndPoints.Features.FuelTypes.Dto;
using ApiEndPoints.Features.Statuses.Command.Create;
using ApiEndPoints.Features.Statuses.Command.Edit;
using ApiEndPoints.Features.Statuses.Entities;
using ApiEndPoints.Features.Statuses.Dto;
using ApiEndPoints.Features.Transmissions.Command.Create;
using ApiEndPoints.Features.Transmissions.Command.Edit;
using ApiEndPoints.Features.Transmissions.Entities;
using ApiEndPoints.Features.Transmissions.Dto;
using ApiEndPoints.Features.Vehicles.Command.Create;
using ApiEndPoints.Features.Vehicles.Command.Edit;
using ApiEndPoints.Features.Vehicles.Entities;
using ApiEndPoints.Features.Vehicles.Dto;
using Microsoft.AspNetCore.Identity;

namespace ApiEndPoints.AutoMapper
{
    public class AutoMapperProfile:Profile
     {
          public AutoMapperProfile()
          {
               CreateMap<Drive, DriveDto>();
               CreateMap<DriveDto, Drive>();

               CreateMap<Brand, BrandDto>();
               CreateMap<BrandDto,Brand>();

               CreateMap<FuelType,FuelTypeDto>();
               CreateMap<FuelTypeDto,FuelType>();

               CreateMap<Transmission,TransmissionDto>();
               CreateMap<TransmissionDto,Transmission>();

               CreateMap<Vehicle,VehicleDto>();
               CreateMap<VehicleDto,Vehicle>();

               CreateMap<Status, StatusDto>();
               CreateMap<StatusDto,Status>();


     
               CreateMap<StatusDto, CreateStatusCommand>();
               CreateMap<EditStatusCommand, Status>();

               CreateMap<VehicleDto, CreateVehicleCommand>();
               CreateMap<CreateVehicleCommand,Vehicle>();
               CreateMap<EditVehicleCommand, Vehicle>();

               CreateMap<TransmissionDto, CreateTransmissionCommand>();
               CreateMap<CreateTransmissionCommand, Transmission>();
               CreateMap<EditTransmissionCommand, Transmission>();

               CreateMap<FuelTypeDto, CreateFuelTypeCommand>();
               CreateMap<CreateFuelTypeCommand, FuelType>();
               CreateMap<EditFuelTypeCommand, FuelType>();

               CreateMap<BrandDto, CreateBrandCommand>();
               CreateMap<CreateBrandCommand, Brand>();
               CreateMap<EditBrandCommand, Brand>();

               CreateMap<DriveDto, CreateDriveCommand>();
               CreateMap<CreateDriveCommand, Drive>();
               CreateMap<EditDriveCommand, Drive>();


          }
     }
}
