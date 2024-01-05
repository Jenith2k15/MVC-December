using FamilyExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.Controllers
{
    public class FamilyMemberController : Controller
    {
        // GET: FamilyMember
        public ActionResult GetFamilyMembers()
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            List<FamilyMember> familyMembers = familyMemberModelManager.GetFamilyMembers();

            return View(familyMembers);
        }

        // GET: Empty form to add family member
        [HttpGet]
        public ActionResult AddFamilyMember()
        {
            return View();
        }

        // POST: Save family member to db
        [HttpPost]
        public ActionResult AddFamilyMember(FamilyMember familyMember)
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            bool isAdded = familyMemberModelManager.AddFamilyMember(familyMember);
            if (isAdded)
            {
                //Redirect to GetFamilyMembers() action method
                return RedirectToAction("GetFamilyMembers");
            }
            return View();
        }

        // GET: Form to edit family member
        [HttpGet]
        public ActionResult EditFamilyMember(int id)
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            List<FamilyMember> familyMembers = familyMemberModelManager.GetFamilyMembers();
            FamilyMember fm = new FamilyMember();
            foreach (var familyMember in familyMembers)
            {
                if (familyMember.FamilyMemberId == id)
                {
                    fm = familyMember;
                    break;
                }
            }
            return View(fm);
        }

        // POST: Save edited family member to db
        [HttpPost]
        public ActionResult EditFamilyMember(FamilyMember familyMember)
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            bool isEdited = familyMemberModelManager.EditFamilyMember(familyMember);
            if (isEdited)
            {
                return RedirectToAction("GetFamilyMembers");
            }
            return View();
        }

        // GET: Form to delete family member
        [HttpGet]
        public ActionResult DeleteFamilyMember(int id)
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            List<FamilyMember> familyMembers = familyMemberModelManager.GetFamilyMembers();
            FamilyMember fm = new FamilyMember();
            foreach (var familyMember in familyMembers)
            {
                if (familyMember.FamilyMemberId == id)
                {
                    fm = familyMember;
                    break;
                }
            }
            return View(fm);
        }

        // POST: Delete family member from db
        [HttpPost]
        public ActionResult DeleteFamilyMember(FamilyMember familyMember)
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            bool isDeleted = familyMemberModelManager.DeleteFamilyMember(familyMember);
            if (isDeleted)
            {
                return RedirectToAction("GetFamilyMembers");
            }
            return View();
        }
    }
}