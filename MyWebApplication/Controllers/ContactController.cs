using System;
using System.Collections.Generic;
using MyWebApplication.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebApplication.ViewModels;

namespace MyWebApplication.Controllers
{
    public class ContactController : Controller
    {

        private IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public ActionResult Index()
        {
            return View(contactService.GetContacts());
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactVM contact)
        {
            if(contactService.CreateContact(contact) <=0)
            {
                ViewBag.errorMsg = "Error in saving contact";
                return View(contact);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ContactVM contact)
        {
            if (contactService.CreateContact(contact) <= 0)
            {
                ViewBag.errorMsg = "Error in saving contact";
                return View(contact);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(contactService.GetContact(id));
        }
    }
}