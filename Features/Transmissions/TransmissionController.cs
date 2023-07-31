using ApiEndPoints.Features.Transmissions.Command.Create;
using ApiEndPoints.Features.Transmissions.Command.Delete;
using ApiEndPoints.Features.Transmissions.Command.Edit;
using ApiEndPoints.Features.Transmissions.Query.GetAll;
using ApiEndPoints.Features.Transmissions.Query.GetById;
using ApiEndPoints.Features.Transmissions.Dto;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Transmissions
{
    public class TransmissionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAppCache _appCache;

          public TransmissionController(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }

        public async Task<ActionResult> Index()
        {
            var transmissions = await _appCache.GetOrAddAsync("Transmissions.Get", () => _mediator.Send(new GetAllTransmissionQuery()));

               return View(transmissions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransmissionDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _mediator.Send(new CreateTransmissionCommand(model)).Result;
                if (result)
                {
                     _appCache.Remove("Transmissions.Get");
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
                var result = _mediator.Send(new DeleteTransmissionCommand(id)).Result;
                if (result)
                {
                     _appCache.Remove("TransmissionById.Get: "+id);
                     _appCache.Remove("Transmissions.Get");
                     return RedirectToAction("Success", "Home");
                }
            }
            return RedirectToAction("Error", "Home");
        }

        public async Task<ActionResult> Edit(byte id)
        {
            if (ModelState.IsValid)
            {
                var model = await _appCache.GetOrAddAsync("TransmissionById.Get: "+id, () => _mediator.Send(new GetTransmissionByIdQuery(id)));

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
        public async Task<IActionResult> Edit(TransmissionDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _mediator.Send(new EditTransmissionCommand(model));
            if (result)
            {
                 _appCache.Remove("Transmissions.Get");
                 _appCache.Remove("TransmissionById.Get: "+model.TransmissionId);

                    return RedirectToAction("Success", "Home");
            }

            return View(model);
        }
    }
}
