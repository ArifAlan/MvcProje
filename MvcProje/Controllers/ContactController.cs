using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        //private MessageManager messageManager = new MessageManager(new EfMessageDal());
        private ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var result = contactManager.GetAll();
            return View(result);
        }
        public ActionResult GetContactDetails(int id)
        {
            var result = contactManager.GetById(id);
            return View(result);
        }
        public PartialViewResult MessageListMenu()
        {
            var contactList = contactManager.GetAll();
            ViewBag.contactCount = contactList.Count();
        

            return PartialView();
        }
    }
}