using ApiEndPoints.Features.Statuses.Command.Create;
using ApiEndPoints.Features.Statuses.Command.Delete;
using ApiEndPoints.Features.Statuses.Command.Edit;
using ApiEndPoints.Features.Statuses.Query.GetAll;
using ApiEndPoints.Features.Statuses.Query.GetById;
using ApiEndPoints.Features.Statuses.Dto;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Statuses
{
    public class StatusController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAppCache _appCache;

          public StatusController(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }
        public async Task<ActionResult> Index()
        {

            var result = await _appCache.GetOrAddAsync("Statuses.Get", () => _mediator.Send(new GetAllStatusQuery()));

               return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StatusDto model)
        {

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateStatusCommand(model));
                if (result)
                {
                     _appCache.Remove("Statuses.Get");
                     return RedirectToAction("Success", "Home");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(byte id)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new DeleteStatusCommand(id));
                if (result)
                {
                     _appCache.Remove("StatusById.Get: "+id);
                     _appCache.Remove("Statuses.Get");
                     return RedirectToAction("Success", "Home");
                }
            }

            return RedirectToAction("Error", "Home");
        }
        public async Task<ActionResult> Edit(byte id)
        {
            if (ModelState.IsValid)
            {
                var model = await _appCache.GetOrAddAsync("StatusById.Get: "+id, () => _mediator.Send(new GetStatusByIdQuery(id)));

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
        public async Task<IActionResult> Edit(StatusDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _mediator.Send(new EditStatusCommand(model));
            if (result)
            {
                 _appCache.Remove("Statuses.Get");
                 _appCache.Remove("StatusById.Get: "+model.StatusId);

                    return RedirectToAction("Success", "Home");
            }

            return View(model);
        }

    }
}
