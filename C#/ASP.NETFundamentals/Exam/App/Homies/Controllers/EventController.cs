using System.Security.Claims;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private HomiesDbContext context;

        public EventController(HomiesDbContext data)
        {
            context = data;
        }

        public async Task<IActionResult> All()
        {
            var models = await GetAllModelsAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var types = await GetAllTypesAsync();

            var model = new AddViewModel()
            {
                Types = types
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (ModelState.IsValid && model.Start < model.End)
            {
                await AddEventAsync(model);
                return RedirectToAction("All", "Event");
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await GetDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditViewModel model = await GetEventById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid && DateTime.Parse(model.Start) < DateTime.Parse(model.End))
            {
                await EditEventAsync(model);
                return RedirectToAction("All", "Event");
            }

            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            var joinedEvents = await GetAllJoinedEvents();

            return View(joinedEvents);
        }

        public async Task<IActionResult> Join(int id)
        {
           bool check = await JoinEvent(id);

           if (check)
           {
               return RedirectToAction("Joined", "Event");
           }
           else
           {
               return RedirectToAction("All", "Event");
           }
        }

        public async Task<IActionResult> Leave(int id)
        {
            await LeaveEvent(id);
            return RedirectToAction("All", "Event");
        }

        public string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<IEnumerable<AllViewModel>> GetAllModelsAsync()
        {
            var models = await context.Events
                                      .Select(e => new AllViewModel()
                                       {
                                           Id = e.Id,
                                           Name = e.Name,
                                           OrganiserId = e.OrganiserId,
                                           Start = e.Start,
                                           Type = e.Type.Name
                                       })
                                      .ToListAsync();

            return models;
        }

        public async Task<IEnumerable<TypeViewModel>> GetAllTypesAsync()
        {
            var types = await context.Types
                                     .Select(t => new TypeViewModel()
                                      {
                                          Id = t.Id,
                                          Name = t.Name
                                      })
                                     .ToListAsync();

            return types;
        }

        public async Task AddEventAsync(AddViewModel model)
        {
            var eventToAdd = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                Start = model.Start,
                End = model.End,
                OrganiserId = GetUserId(),
                TypeId = model.TypeId
            };

            await context.AddAsync(eventToAdd);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllViewModel>> GetAllJoinedEvents()
        {
            var userId = GetUserId();

            var events = await context.EventsParticipants
                                      .Where(ep => ep.HelperId == userId)
                                      .Select(ep => new AllViewModel()
                                       {
                                          Id = ep.Event.Id,
                                          Name = ep.Event.Name,
                                          OrganiserId = ep.Event.OrganiserId,
                                          Organiser = ep.Event.Organiser,
                                          Start = ep.Event.Start,
                                          Type = ep.Event.Type.Name
                                       })
                                      .ToListAsync();

            return events;
        }

        public async Task<EditViewModel> GetEventById(int id)
        {
            var model = await context.Events.FirstOrDefaultAsync(e => e.Id == id);

                var types = await GetAllTypesAsync();

                var modelToReturn = new EditViewModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Start = model.Start.ToString(),
                    End = model.End.ToString(),
                    TypeId = model.TypeId,
                    Types = types
                };

                return modelToReturn;
        }

        public async Task EditEventAsync(EditViewModel model)
        {
            var eventToEdit = await context.Events.FirstOrDefaultAsync(e => e.Id == model.Id);

            eventToEdit.Name = model.Name;
            eventToEdit.Description = model.Description;
            eventToEdit.Start = DateTime.Parse(model.Start);
            eventToEdit.End = DateTime.Parse(model.End);
            eventToEdit.TypeId = model.TypeId;

            await context.SaveChangesAsync();
        }

        public async Task<DetailsViewModel> GetDetailsAsync(int id)
        {
            var eventToFind = await context.Events
                                     .FirstOrDefaultAsync(e => e.Id == id);

            var typeOfEntity = await context.Types.FirstOrDefaultAsync(t => t.Id == eventToFind.TypeId);

            var model = new DetailsViewModel()
            {
                Id = eventToFind.Id,
                Name = eventToFind.Name,
                Description = eventToFind.Description,
                OrganiserId = eventToFind.OrganiserId,
                Organiser = eventToFind.Organiser,
                CreatedOn = eventToFind.CreatedOn,
                Start = eventToFind.Start,
                End = eventToFind.End,
                Type = typeOfEntity
            };

            return model;
        }

        public async Task<bool> JoinEvent(int id)
        {
            var userId = GetUserId();

            var alreadyJoined =
                await context.EventsParticipants
                             .FirstOrDefaultAsync(
                    ep => ep.HelperId == userId && ep.EventId == id);

            if (alreadyJoined == null)
            {
                var epToAdd = new EventParticipant()
                {
                    HelperId = userId,
                    EventId = id
                };

                await context.EventsParticipants.AddAsync(epToAdd);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task LeaveEvent(int id)
        {
            var userId = GetUserId();

            var epToRemove = await context.EventsParticipants
                                          .FirstOrDefaultAsync(ep => ep.HelperId == userId && ep.EventId == id);

            if (epToRemove != null)
            {
                context.Remove(epToRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}
