using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.BL.Reposatory;
using WebApplication5.DAL.Database;
using WebApplication5.DAL.Entity;
using WebApplication5.BL.interfaces;
using AutoMapper;
using WebApplication5.BL.VM;
using WebApplication5.BL.helper;

namespace WebApplication5.Areas.De.Controllers
{
    [Area("Department")]
    public class DepartmentController : Controller
    { // private to be hidden
        //readonly to assign value only in constructor for DI
        readonly private IDepartment dept;
        readonly private IMapper mapper;
        readonly private IEmployee emp;

        //for dependency injection
        public DepartmentController(IDepartment dept, IMapper mapper,IEmployee emp)
        {
            this.mapper = mapper;
            this.dept = dept;
            this.emp = emp;
        }
      
        // show data of Departments from database
        public IActionResult Index()
        {
            var data = dept.get();
            //mapping 
            var model = mapper.Map<IEnumerable<DeptVM>>(data);
            return View(model);

        }
        //create department
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
       //create department and with values from DEP and save in database
        public IActionResult Create(DeptVM dep)

        {
            try
            {
                if (ModelState.IsValid)
                {
                 
                    var data = mapper.Map<Department>(dep);
                    dept.create(data);
                    return RedirectToAction("Index");
                }
              
                    return View(dep);
                
            }
            catch(Exception e)
            {
                return View(dep);
            }
        }
      //show data of department which need to be updated based on id
        public IActionResult update(int id)
        {
            var data = dept.getbyid(id);
            var model = mapper.Map<DeptVM>(data);
            return View(model);
        }

        [HttpPost]
        //update department which need to be updated and new values comes from object dep
        public IActionResult update(DeptVM dep)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(dep);
                    dept.update(data);
                    return RedirectToAction("Index");
                }
               return View(dep);
                
            }
            catch (Exception e)
            {
                return View(dep);
            }
        }
        //delete department which need to be deleted based on id
        public IActionResult Delete(int id)
        {
            var data = dept.getbyid(id);
            var model = mapper.Map<DeptVM>(data);
            return View(model);
        }



        [HttpPost]
        //delete department which need to be deleted 
        public IActionResult Delete(DeptVM dep)
        {//check first that no employees in thid=s department
            if (emp.getbyfilter(a=>a.departmentid==dep.id).Count()==0)
            {

                var data = mapper.Map<Department>(dep);
                dept.delete(data);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.x = "can not delete department have employees";
                return View(dep);
            }
            
    
}



    }
}
