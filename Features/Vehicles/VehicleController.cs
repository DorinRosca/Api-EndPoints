using ApiEndPoints.Features.Vehicles.Command.Create;
using ApiEndPoints.Features.Vehicles.Command.Delete;
using ApiEndPoints.Features.Vehicles.Command.Edit;
using ApiEndPoints.Features.Vehicles.Query.GetAll;
using ApiEndPoints.Features.Vehicles.Query.GetById;
using ApiEndPoints.Features.Vehicles.Dto;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Vehicles
{
    public class VehicleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAppCache _appCache;

          public VehicleController(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }

        public async Task<ActionResult> Index()
        {
             var vehicles = await _appCache.GetOrAddAsync("Vehicles.Get", () => _mediator.Send(new GetAllVehicleQuery()));

            return View(vehicles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _mediator.Send(new CreateVehicleCommand(model)).Result;
                if (result)
                {
                     _appCache.Remove("Vehicles.Get");
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
                var result = _mediator.Send(new DeleteVehicleCommand(id)).Result;
                if (result)
                {
                     _appCache.Remove("VehicleById.Get: "+id);
                     _appCache.Remove("Vehicles.Get");
                     return RedirectToAction("Success", "Home");
                }
            }
            return RedirectToAction("Error", "Home");
        }

        public async Task<ActionResult> Edit(byte id)
        {
            if (ModelState.IsValid)
            {
                 var model = await _appCache.GetOrAddAsync("VehicleById.Get: "+id, () => _mediator.Send(new GetVehicleByIdQuery(id)));
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
        public async Task<IActionResult> Edit(VehicleDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _mediator.Send(new EditVehicleCommand(model));
            if (result)
            {
                 _appCache.Remove("Vehicles.Get");
                 _appCache.Remove("VehicleById.Get: "+model.VehicleId);

                    return RedirectToAction("Success", "Home");
            }

            return View(model);
        }
    }
}
