using ApiEndPoints.Features.FuelTypes.Command.Create;
using ApiEndPoints.Features.FuelTypes.Command.Delete;
using ApiEndPoints.Features.FuelTypes.Command.Edit;
using ApiEndPoints.Features.FuelTypes.Query.GetAll;
using ApiEndPoints.Features.FuelTypes.Query.GetById;
using ApiEndPoints.Features.FuelTypes.Dto;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.FuelTypes
{
    public class FuelTypeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAppCache _appCache;

          public FuelTypeController(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }

        public async Task<ActionResult> Index()
        {
            var fuelTypes = await _appCache.GetOrAddAsync("FuelTypes.Get", () => _mediator.Send(new GetAllFuelTypeQuery()));

               return View(fuelTypes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuelTypeDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _mediator.Send(new CreateFuelTypeCommand(model)).Result;
                if (result)
                {
                     _appCache.Remove("FuelTypes.Get");
                     return RedirectToAction("Success", "Home");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(byte id)
        {
            if (ModelState.IsValid)
            {
                var result = _mediator.Send(new DeleteFuelTypeCommand(id)).Result;
                if (result)
                {
                     _appCache.Remove("FuelTypes.Get");
                     _appCache.Remove("FuelTypesById.Get: "+id);
                     return RedirectToAction("Success", "Home");
                }
            }
            return RedirectToAction("Error", "Home");
        }

        public async Task<ActionResult> Edit(byte id)
        {
            if (ModelState.IsValid)
            {
                var model =  await _appCache.GetOrAddAsync("FuelTypesById.Get: "+id, () => _mediator.Send(new GetFuelTypeByIdQuery(id)));

                    if (model == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                return View(model);
            }
            return RedirectToAction("Error", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FuelTypeDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _mediator.Send(new EditFuelTypeCommand(model));
            if (result)
            {
                 _appCache.Remove("FuelTypes.Get");
                 _appCache.Remove("FuelTypesById.Get: "+model.FuelTypeId);

                    return RedirectToAction("Success", "Home");
            }

            return View(model);
        }
    }
}
