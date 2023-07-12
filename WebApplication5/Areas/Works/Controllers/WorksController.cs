

namespace WebApplication5.Areas.Works.Controllers
{
    [Area("Works")]
   [Authorize]
    public class WorksController : Controller
    {// private to be hidden
        //readonly to assign value only in constructor for DI
        private readonly IEmployee emp;
        private readonly IProject pro;
        private readonly IMapper mapper;
        private readonly IDepartment dept;
        private readonly IWorks_For work;
        

        //for dependency injection

        public WorksController(IEmployee emp, IProject pro, IMapper mapper,IDepartment dept,IWorks_For work)
        {
            this.emp = emp;
            this.pro = pro;
            this.mapper = mapper;
            this.dept = dept;
            this.work = work;
          
        }
        // show all records of entity works_for
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(int Employeeid)
        {
          
           
            ViewBag.data = Employeeid;
            ViewBag.disabled = true;

            ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
            ViewBag.projectlist = new SelectList(pro.get(), "id", "name");
            return View();
        }
        [HttpPost]
        //add new record in works for entity
        public IActionResult Create(Works_ForVM wf)
        {
            try {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Works_For>(wf);
                    work.create(data);
                    
                    return RedirectToAction("Index", "Employee", new { area = "Employee" });
                }

                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                ViewBag.projectlist = new SelectList(pro.get(), "id", "name");
                wf.DepartmentId = 0;
                ViewBag.disabled = true;
                return View(wf);
            }catch(Exception ee)
            {
                var data = mapper.Map<Works_For>(wf);
                ViewBag.depn = 0;
                var model= mapper.Map<Works_ForVM>(data);
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                ViewBag.projectlist = new SelectList(pro.get(), "id", "name");
                ViewBag.disabled = true;
                return View(model);
            }
    
          
        }
        
        //Delete data from database
        public IActionResult Delete(int empid, int proid)
        {
            ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
            var data = work.getFilter(a => a.ProjectId == proid && a.EmployeeId == empid).FirstOrDefault();
            var model = mapper.Map<Works_ForVM>(data);
            return View(model);
        }

        [HttpPost]
        //Delete data from database
        public IActionResult Delete(Works_ForVM w)
        {
            var data = mapper.Map<Works_For>(w);
            work.delete(data);
            return RedirectToAction("Index", "Employee", new { area = "Employee" });
        }
        [HttpPost]
        //get data from database by filter and send data to ajax
        //all this is used to filter showing of data
        public IActionResult GetData(int state,int empid)
        {
            var data = dept.getbyid(state);
          if( data==null)
            {
                return Json(null);
            }
            else
            {
              
                var res=work.getFilter(a => a.EmployeeId != empid);
                var projects = pro.getFilter(a => a.DepartmentId==state&& !res.Select(b=>b.ProjectId).Contains(a.id));
                return Json(projects);
            }

            
        }

    }
}
