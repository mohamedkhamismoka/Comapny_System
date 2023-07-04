



namespace WebApplication5.Areas.De.Controllers
{
    [Area("Employee")]
    [Authorize]
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
        public EmployeeController(IEmployee emp, IMapper mapper, IDepartment dept, IProject pro, IWorks_For work)
        {
            this.mapper = mapper;
            this.emp = emp;
            this.dept = dept;
            this.pro = pro;
            this.work = work;
        }
        public IActionResult Index()
        {


            var data = emp.getbyfilter();
            var res = mapper.Map<IEnumerable<EmpVM>>(data);
            return View(res);



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
                {
                        var cvname = Fileuploader.uploader("docs", model.cv);
                        var imgname = Fileuploader.uploader("images", model.img);
                        model.cvname = cvname;
                        model.imgname = imgname;
                        var data = mapper.Map<Employee>(model);
                        emp.create(data);
                        return RedirectToAction("Index");
                    
                 
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
        public IActionResult update(EmpVM empo, IFormFile? empnewimg, IFormFile? empnewcv)
        {
            try
            {
                
                if (empnewimg != null)
                {
                    var imgname = Fileuploader.uploader("images", empnewimg);
                    empo.img= empnewimg;
                    empo.imgname = imgname;
                }
                if (empnewcv != null)
                {
                    var cvname = Fileuploader.uploader("images", empnewcv);
                    empo.cv = empnewcv;
                    empo.cvname = cvname;
                }
                if (!ModelState.IsValid )
                {
                    int j = 0 ;
                    int y = 0;
                    for (int i = 0; i < ModelState.Root.Children.Count; i++)
                    {
                        if ((ModelState.Root.Children[i].ValidationState == ModelValidationState.Invalid && i==0)||( ModelState.Root.Children[i].ValidationState == ModelValidationState.Invalid&&i==2))
                        {
                            j++;
                        }
                        else
                        {
                            if(ModelState.Root.Children[i].ValidationState == ModelValidationState.Invalid)
                            {
                                y++;
                            }
                        }
                     
                    }

                    if (y == 0 && j > 0)
                    {
                        var data = mapper.Map<Employee>(empo);
                        data.imgname = empo.imgname;
                        data.cvname = empo.cvname;


                        emp.update(data);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");

                        return View(empo);
                    }
                




                }
              else
                {
                    var data = mapper.Map<Employee>(empo);
                    data.imgname = empo.imgname;
                    data.cvname = empo.cvname;


                    emp.update(data);
                    return RedirectToAction("Index");
                }
               

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
            work.deleteEmployee(empo.id);

            var data = mapper.Map<Employee>(empo);
            emp.delete(data);
            Fileuploader.delete("docs", empo.cvname);
            Fileuploader.delete("images", empo.imgname);
            return RedirectToAction("Index");



        }

        //show details of Employee depending on id
        public IActionResult Details(int id)
        {
            int count = 0;
            ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
            var data = emp.getbyid(id);
            var model = mapper.Map<EmpVM>(data);

            ViewBag.ex = work.getFilter(a => a.employeeId == model.id);
            foreach (var item in ViewBag.ex)
            {
                count++;
            }
            ViewBag.counter = count;
            return View(model);

        }




        [HttpPost]

        public JsonResult GetData(string state)
        {
            if (state == "all")
            {
                var data = emp.getbyfilter();
                var model = mapper.Map<IEnumerable<EmpVM>>(data);

                return Json(model);
            }
            else
            {
                var data = emp.getbyfilter(a => a.isActive == true);
                var model = mapper.Map<IEnumerable<EmpVM>>(data);

                return Json(model);
            }

        }

        public IActionResult download(string cvname)
        {
            var path = Path.Combine(
               Directory.GetCurrentDirectory(), "wwwroot/files/docs/", cvname);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application/x-msdownload", cvname);
        }





    }

}
