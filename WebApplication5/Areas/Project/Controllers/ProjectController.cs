using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.BL.helper;
using WebApplication5.BL.interfaces;
using WebApplication5.BL.Reposatory;
using WebApplication5.BL.VM;
using WebApplication5.DAL.Database;
using WebApplication5.DAL.Entity;
using Microsoft.Extensions.Localization;
using WebApplication5.language;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication5.Areas.Project.Controllers
{
    [Area("Project")]
    [Authorize]
    public class ProjectController :Controller
    {   // private to be hidden
        //readonly to assign value only in constructor for DI
        private readonly IDepartment dept;
        private readonly IProject pro;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResource> SharedLocalizer;


        //for dependency injection
        public ProjectController(IDepartment Dept,IProject pro,IMapper mapper, IStringLocalizer<SharedResource> SharedLocalizer)
        {
            dept = Dept;
            this.pro = pro;
            this.mapper = mapper;
            this.SharedLocalizer = SharedLocalizer;
        }



        // show data of projects in database
        public IActionResult Index()
        {//fill select list  with data where value =id and text =name
            ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
            var data = pro.get();
            var model = mapper.Map<IEnumerable<ProjectVM>>(data);

            return View(model);
        }
        //create project page
        public IActionResult Create()

        {
            //fill select list  with data where value =id and text =name
            ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");

            return View();
        }
        [HttpPost]
        //create project where data from object proj and save in database
        public IActionResult Create(ProjectVM proj)
        {
            try
            {//first validate that startDate less than finish date and then determine state of project
                if (ModelState.IsValid && DateVaildator.validate(proj.Startdate, proj.Finishdate))

                {
                    if (proj.Finishdate > DateTime.Now.Date && proj.Startdate > DateTime.Now.Date)
                    {
                        proj.state = SharedLocalizer["Not started Yet"];
                    }
                    else if (proj.Finishdate > DateTime.Now.Date && proj.Startdate < DateTime.Now.Date)
                    {

                        proj.state = SharedLocalizer["Running"];
                    }
                    else if (proj.Finishdate < DateTime.Now.Date)
                    {
                        proj.state = SharedLocalizer["Finished"];
                    }
                    var data = mapper.Map<WebApplication5.DAL.Entity.Project>(proj);
                    pro.create(data);
                    return RedirectToAction("Index");

                }


                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                ViewBag.valid = "Finish date must be greater than Start date";
                    return View(proj);
                
            }
            catch(Exception e)
            {
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                return View(proj);
            }
        }
        //show details of project based on id
        public IActionResult Details(int id)
        {
            ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
            var data = pro.getbyid(id);
            var model = mapper.Map<ProjectVM>(data);
            return View(model);
        }
        //show data of project to be updated based on id
        public IActionResult Update(int id)
        {
            ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
            var data = pro.getbyid(id);
            var model = mapper.Map<ProjectVM>(data);
            return View(model);
        }

        [HttpPost]
        //update project based on data of object proj and save in database
        public IActionResult Update(ProjectVM proj)
        {
            try
            {
                if (ModelState.IsValid&&DateVaildator.validate(proj.Startdate, proj.Finishdate))
                {
                    var data = mapper.Map<WebApplication5.DAL.Entity.Project>(proj);
                    pro.update(data);
                    return RedirectToAction("Index")
;                }
                ViewBag.valid = "Finish date must be greater than Start date";
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                return View(proj);
            }
            catch(Exception ee)
            {
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                return View(proj);
            }
        }

        // show data of project to be deleted based on id

        public IActionResult Delete(int id)
        {
            ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
            var data = pro.getbyid(id);
            var model = mapper.Map<ProjectVM>(data);
            return View(model);
        }

        [HttpPost]
        //delete proj from database
        public IActionResult Delete(ProjectVM proj)
        {
           
                    var data = mapper.Map<WebApplication5.DAL.Entity.Project>(proj);
                pro.delete(data);
                    return RedirectToAction("Index")
;
            
           
        }



    }
}
