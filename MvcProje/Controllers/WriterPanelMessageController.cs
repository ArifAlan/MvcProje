using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        private MessageManager messageManager = new MessageManager(new EfMessageDal());
        private MessageValidator messageValidator = new MessageValidator();
       

        // GET: WriterPanelMessage
        public ActionResult Inbox( )
        {
            string parametre = (string)Session["WriterMail"];
            
            var messageList = messageManager.GetListInbox(parametre);
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            string parametre = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendbox(parametre);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.Add(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }


            return View();
        }
    }
}