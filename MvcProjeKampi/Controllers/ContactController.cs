using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult ContactSideBarPartial()
        {
            var contactList = cm.GetList();
            ViewBag.contactCount = contactList.Count();
            var listResult = mm.GetListSendbox();
            var sendList = listResult.FindAll(x => x.isDraft== false);
            ViewBag.sendCount = sendList.Count();
            var listResult2 = mm.GetListInbox();
            ViewBag.inboxCount = listResult2.Count();

            var drafList = listResult.FindAll(x => x.isDraft == true);
            ViewBag.draftCount = drafList.Count();
            return PartialView();
        }
    }
}