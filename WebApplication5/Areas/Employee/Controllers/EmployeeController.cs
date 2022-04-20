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

namespace WebApplication5.Areas.De.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        // private to be hidden
        //readonly to assign value only in constructor for DI

        private readonly IEmployee emp;
        private readonly IMapper mapper;
        private readonly IDepartment dept;
        private readonly IProject pro;
        private readonly IWorks_For work;

        //for dependency injection
        public EmployeeController(IEmployee emp, IMapper mapper, IDepartment dept,IProject pro,IWorks_For work)
        {
            this.mapper = mapper;
            this.emp = emp;
            this.dept = dept;
            this.pro = pro;
            this.work = work;
        }
        //public Employee employee { get; set; }
        //[BindProperty]
        //public IFormFile image { get; set; }
        //[Area("Employee")]


        //take state and search from select list to filter data
        public IActionResult Index(string state)
        {
            if (state == null || state=="All")
            {
                var data = emp.getbyfilter();
                var res = mapper.Map<IEnumerable<EmpVM>>(data);
                    return View(res);
            }
            else
            {

                var data = emp.getbyfilter(a=>a.isActive==true);
                var res = mapper.Map<IEnumerable<EmpVM>>(data);
                return View(res);
            }
          
         
          
        }




    
   //craete Employee
    public IActionResult create()
    {
            //fill select with data where value=id and text=name
        ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
        return View();
    }

    [HttpPost]
        //craete Employee
        public IActionResult create(EmpVM model)
    {
        try
        {
            if (ModelState.IsValid)
            {//check first that cv and image not null 
                    if (model.cv != null && model.img != null)
                    {
                        var cvname = Fileuploader.uploader("docs", model.cv);
                        var imgname = Fileuploader.uploader("images", model.img);
                        model.cvname = cvname;
                        model.imgname = imgname;
                        var data = mapper.Map<Employee>(model);
                        emp.create(data);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.warn = "Enter valid cv and image";
                        return View(model);
                    }
            }
              ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                
                return View(model);
            
        }
        catch (Exception e)
        {
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");

                return View(model);
        }

    }
   //view to update employee and take id to show sdata of employee to update
    public IActionResult update(int id)
    {
        ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
        var data = emp.getbyid(id);
          
        var model = mapper.Map<EmpVM>(data);


            
            
            return View(model);
    }
   
    [HttpPost]
       //update employee and empo reperesnt new values 
        public IActionResult update(EmpVM empo,string img,string cv)
    {
        try
        {
            if (ModelState.IsValid)
            {
                    if (empo.cv != null && empo.img!=null)
                    {
                        var cvname = Fileuploader.uploader("docs", empo.cv);
                        var imgname = Fileuploader.uploader("images", empo.img);
                        empo.cvname = cvname;
                        empo.imgname = imgname;
                        var data = mapper.Map<Employee>(empo);
                        emp.update(data);
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        var data = mapper.Map<Employee>(empo);
                        data.imgname = img;
                        data.cvname = cv;
                        emp.update(data);
                        return RedirectToAction("Index");
                    }
                
                  
                }
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");

                return View(empo);
            
        }
        catch (Exception e)
            {
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");

                return View(empo);
        }
    }
  // show employee data  that be deleted  by id
    public IActionResult Delete(int id)
    {
        ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
        var data = emp.getbyid(id);
        var model = mapper.Map<EmpVM>(data);
        return View(model);


    }

    [HttpPost]
    [ActionName("Delete")]
    //delete employee
    public IActionResult ConfirmDelete(EmpVM empo)
    {

        var data = mapper.Map<Employee>(empo);
        emp.delete(data);
            Fileuploader.delete("docs", empo.cvname);
            Fileuploader.delete("images", empo.imgname);
            return RedirectToAction("Index");



    }

 //show details of Employee depending on id
    public IActionResult Details(int id)
    {
        ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
        var data = emp.getbyid(id);
        var model = mapper.Map<EmpVM>(data);

            ViewBag.ex = work.getFilter(a => a.Employee_id == model.id);
            return View(model);

    }



      
        [HttpPost]
       
        public JsonResult GetData(string state)
        {
            if(state=="all")
            {
                var data = emp.getbyfilter();
                var model = mapper.Map<IEnumerable<EmpVM>>(data);
        
                return Json(model);
            }
            else
            {
                var data = emp.getbyfilter(a=>a.isActive == true);
                var model = mapper.Map<IEnumerable<EmpVM>>(data);
    
                return Json(model);
            }

        }

    



        }

    }
