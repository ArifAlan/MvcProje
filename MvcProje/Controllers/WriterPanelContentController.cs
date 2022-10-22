﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
       
        public ActionResult MyContent(string parametre)
        {
            Context context = new Context();

            parametre = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == parametre).Select(y => y.WriterId).FirstOrDefault();
          
            var contentValues = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
        //[HttpGet]
        //public ActionResult AddContent()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddContent(Content parametre)
        //{
        //    //Context context = new Context();
        //    //string mail = (string)Session["WriterMail"];
        //    //var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
        //    parametre.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    //parametre.WriterId = writerIdInfo;
        //    contentManager.Add(parametre);
        //    parametre.ContentStatus = true;
        //    return RedirectToAction("MyContent");
        //}
    }
}