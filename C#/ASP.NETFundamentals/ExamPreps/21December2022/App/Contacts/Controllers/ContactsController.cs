using System.Security.Claims;
using Contacts.Data.Models;
using Contacts.Data;
using Contacts.Models;
using Contacts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

namespace Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private ContactsDbContext context;

        public ContactsController(ContactsDbContext data)
        {
            context = data;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<IActionResult> All()
        {
            var models = await GetAllContacts();

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await AddContact(model);

            return RedirectToAction("All", "Contacts");
        }

        public async Task<IActionResult> Team()
        {
            var models = await GetAllMyTeamContacts();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int contactId)
        {
            var model = await FindEntityById(contactId);

            ViewBag.ContactId = contactId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel editedModel)
        {
            if (ModelState.IsValid)
            {
                await EditModel(editedModel);
            }

            return RedirectToAction("All", "Contacts");
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int contactId)
        {
            await AddToMyTeam(contactId, GetUserId());

            return RedirectToAction("All", "Contacts");
        }

        public async Task<IActionResult> RemoveFromTeam(int contactId)
        {
            await RemoveFromMyTeam(contactId, GetUserId());

            return RedirectToAction("Team", "Contacts");
        }

        public async Task<IEnumerable<AllViewModel>> GetAllContacts()
        {
            var models = await context.Contacts
                                      .Select(c => new AllViewModel()
                                       {
                                           ContactId = c.Id,
                                           FirstName = c.FirstName,
                                           LastName = c.LastName,
                                           Email = c.Email,
                                           PhoneNumber = c.PhoneNumber,
                                           Address = c.Address,
                                           Website = c.Website
                                       }).ToListAsync();

            return models;
        }

        public async Task<IEnumerable<AllViewModel>> GetAllMyTeamContacts()
        {
            var userId = GetUserId();

            var models = await context.ApplicationUsersContacts
                                      .Where(uc => uc.ApplicationUserId == userId)
                                      .Select(uc => new AllViewModel()
                                       {
                                           ContactId = uc.Contact.Id,
                                           FirstName = uc.Contact.FirstName,
                                           LastName = uc.Contact.LastName,
                                           Email = uc.Contact.Email,
                                           PhoneNumber = uc.Contact.PhoneNumber,
                                           Address = uc.Contact.Address,
                                           Website = uc.Contact.Website
                                       })
                                      .ToListAsync();

            return models;
        }

        public async Task AddContact(AddContactViewModel model)
        {
            var contact = new Contact()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            await context.Contacts
                         .AddAsync(contact);
            await context.SaveChangesAsync();
        }

        public async Task AddToMyTeam(int contactId, string userId)
        {
            var alreadyAdded =
                await context.ApplicationUsersContacts.AnyAsync(
                    uc => uc.ApplicationUserId == userId && uc.ContactId == contactId);

            if (!alreadyAdded)
            {
                var userContacts = new ApplicationUserContact()
                {
                    ApplicationUserId = userId,
                    ContactId = contactId
                };

                await context.ApplicationUsersContacts.AddAsync(userContacts);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromMyTeam(int contactId, string userId)
        {
            var UserContact =
                await context.ApplicationUsersContacts.FirstOrDefaultAsync(
                    uc => uc.ContactId == contactId && uc.ApplicationUserId == userId);
            if (UserContact != null)
            {
                context.ApplicationUsersContacts.Remove(UserContact);
                await context.SaveChangesAsync();

            }
        }

        public async Task<EditViewModel> FindEntityById(int contactId)
        {
            var modelToFind = await context.Contacts
                                     .FirstOrDefaultAsync(c => c.Id == contactId);

            var model = new EditViewModel()
            {
                FirstName = modelToFind.FirstName,
                LastName = modelToFind.LastName,
                Email = modelToFind.Email,
                PhoneNumber = modelToFind.PhoneNumber,
                Address = modelToFind.Address,
                Website = modelToFind.Website
            };

            return model;
        }

        public async Task EditModel(EditViewModel editedModel)
        {
            var modelToDelete = await context.Contacts
                                       .FirstOrDefaultAsync(c => c.Id == editedModel.Id);

            var editedContact = new Contact()
            {
                Id = editedModel.Id,
                FirstName = editedModel.FirstName,
                LastName = editedModel.LastName,
                Email = editedModel.Email,
                PhoneNumber = editedModel.PhoneNumber,
                Address = editedModel.Address,
                Website = editedModel.Website
            };

            if (modelToDelete != null)
            {
                context.Contacts.Remove(modelToDelete);
                await context.Contacts.AddAsync(editedContact);
                await context.SaveChangesAsync();
            }
        }
    }
}
