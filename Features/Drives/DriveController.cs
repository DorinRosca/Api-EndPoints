using ApiEndPoints.Features.Drives.Command.Create;
using ApiEndPoints.Features.Drives.Command.Delete;
using ApiEndPoints.Features.Drives.Command.Edit;
using ApiEndPoints.Features.Drives.Query.GetAll;
using ApiEndPoints.Features.Drives.Query.GetById;
using ApiEndPoints.Features.Drives.Dto;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiEndPoints.Features.Drives
{
    public class DriveController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAppCache _appCache;

          public DriveController(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }

        public async Task<ActionResult> Index()
        {
            var vehicles = await _appCache.GetOrAddAsync("Drives.Get", () => _mediator.Send(new GetAllDriveQuery()));

               return View(vehicles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DriveDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _mediator.Send(new CreateDriveCommand(model)).Result;
                if (result)
                {
                     _appCache.Remove("Drives.Get");
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
                var result = _mediator.Send(new DeleteDriveCommand(id)).Result;
                if (result)
                {
                     _appCache.Remove("Drives.Get");
                     _appCache.Remove("DrivesById.Get: "+id);

                         return RedirectToAction("Success","Home");
                }
            }
            return RedirectToAction("Error","Home");
        }

        public async Task<ActionResult> Edit(byte id)
        {
            if (ModelState.IsValid)
            {
                var model = await _appCache.GetOrAddAsync("DrivesById.Get: "+id, () => _mediator.Send(new GetDriveByIdQuery(id)));

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
        public async Task<IActionResult> Edit(DriveDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _mediator.Send(new EditDriveCommand(model));
            if (result)
            {
                 _appCache.Remove("Drives.Get");
                 _appCache.Remove("DrivesById.Get: "+model.DriveId);

                    return RedirectToAction("Success", "Home");
            }

            return View(model);
        }
    }
}
