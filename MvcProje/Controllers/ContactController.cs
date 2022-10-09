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
        //private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private ContactManager _contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var result = _contactManager.GetAll();
            return View(result);
        }
    }
}