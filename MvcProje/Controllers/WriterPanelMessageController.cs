using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
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
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = messageManager.GetListSendbox();
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
    }
}