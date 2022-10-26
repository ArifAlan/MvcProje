using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules.FluentValidation;

namespace MvcProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string parametre = (string)Session["WriterMail"];
         
            id = context.Writers.Where(x => x.WriterMail == parametre).Select(y => y.WriterId).FirstOrDefault();
            var writerValue = writerManager.GetById(id);
          
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("AllHeading","WriterPanel");
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

        public ActionResult MyHeading(string parametre)
        {
          
            parametre = (string)Session["WriterMail"];
            var writeridInfo = context.Writers.Where(x => x.WriterMail == parametre).Select(y => y.WriterId).FirstOrDefault();
            var values = headingManager.GetListByWriter(writeridInfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
           

            List<SelectListItem> valueCategory = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writeridInfo = context.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writeridInfo;
          
            heading.HeadingStatus = true;
            headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult HeadingDelete(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1)
        {
            var headings = headingManager.GetAll().ToPagedList(p,4);
            return View(headings);
        }
    }
}