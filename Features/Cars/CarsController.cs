using ApiEndPoints.Features.Cars.Command.Create;
using ApiEndPoints.Features.Cars.Command.Delete;
using ApiEndPoints.Features.Cars.Command.Edit;
using ApiEndPoints.Features.Cars.Query.GetAll;
using ApiEndPoints.Features.Cars.Query.GetById;
using ApiEndPoints.Features.Cars.Query.GetDetails;
using ApiEndPoints.Features.Cars.Query.GetEditCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using ApiEndPoints.Features.Cars.Dto;
using LazyCache;

namespace ApiEndPoints.Features.Cars
{
    public class CarsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAppCache _appCache;

        public CarsController(IMediator mediator, IAppCache appCache)
        {
             _mediator = mediator;
             _appCache = appCache;
        }
        public ActionResult Index(CarFilterDto model = null)
        {
            if (!ModelState.IsValid)
            {
                 var carList =  _mediator.Send(new GetFilteredCarsQuery(model)).Result;

                    return View(carList);
            }
            return RedirectToAction("Error", "Home");
        }
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCar(CarCreateDto model)
        {
            var itemsToRemove = new List<string> { "Brand", "Vehicle", "Transmission", "Drive", "FuelType", "Image" };

            foreach (var item in itemsToRemove)
            {
                ModelState.Remove(item);
            }
            if (ModelState.IsValid)
            {
                var result = _mediator.Send(new CreateCarCommand(model)).Result;
                if (result)
                {
                     _appCache.Remove("FilteredCars.Get");
                     return RedirectToAction("Success", "Home");
                }
            }

            var carDetails = await _appCache.GetOrAddAsync("CarDetails.Get", () => _mediator.Send(new GetCarDetailsQuery()));

               return View("CreateCar", carDetails);
        }
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateCar()
        {
             var carDetails = await _appCache.GetOrAddAsync("CarDetails.Get", () => _mediator.Send(new GetCarDetailsQuery()));
            return View("CreateCar", carDetails);
        }

        public async Task<IActionResult> CarDetails(int id)
        {
            if (ModelState.IsValid)
            {
                    var result = await _appCache.GetOrAddAsync("CarById.Get: "+id, () => _mediator.Send(new GetCarByIdQuery(id)));
                    return View(result);
            }
            return RedirectToAction("Error", "Home");

        }
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {

            if (ModelState.IsValid)
            {

                var carDetails =await _appCache.GetOrAddAsync("CarEdit.Get", () => _mediator.Send(new GetEditCarQuery(id)));
                return View(carDetails);
            }
            return RedirectToAction("Error", "Home");

        }
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarEditDto model)
        {
            var itemsToRemove = new List<string> { "Brand", "Vehicle", "Transmission", "Drive", "FuelType", "ImageFile" };
            foreach (var item in itemsToRemove)
            {
                ModelState.Remove(item);
            }
            if (ModelState.IsValid)
            {
                var result = _mediator.Send(new EditCarCommand(model)).Result;
                if (result)
                {
                     _appCache.Remove("FilteredCars.Get");
                     _appCache.Remove("CarById.Get: "+ model.CarId);

                         return RedirectToAction("Success", "Home");
                }
            }
            var invalidFields = ModelState.Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                 .ToDictionary(x => x.Key, x => x.Value.Errors.Select(error => error.ErrorMessage).ToList());

            return RedirectToAction("Error", "Home");

        }
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                var result = _mediator.Send(new DeleteCarCommand(id)).Result;
                if (result)
                {
                     _appCache.Remove("FilteredCars.Get");
                     _appCache.Remove("CarById.Get: "+id);

                         return RedirectToAction("Success", "Home");
                }
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
