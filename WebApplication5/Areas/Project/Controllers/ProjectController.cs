



namespace WebApplication5.Areas.Project.Controllers
{
    [Area("Project")]
    [Authorize]
    public class ProjectController : Controller
    {   // private to be hidden
        //readonly to assign value only in constructor for DI
        private readonly IDepartment dept;
        private readonly IProject pro;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResource> SharedLocalizer;
        private readonly IWorks_For work;


        //for dependency injection
        public ProjectController(IDepartment Dept, IProject pro, IMapper mapper, IStringLocalizer<SharedResource> SharedLocalizer, IWorks_For work)
        {
            dept = Dept;
            this.pro = pro;
            this.mapper = mapper;
            this.SharedLocalizer = SharedLocalizer;
            this.work = work;
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
        public IActionResult Create(ProjectVM project)
        {
            try
            {//first validate that startDate less than finish date and then determine state of project
                if (ModelState.IsValid && DateVaildator.validate(project.Startdate, project.Finishdate))

                {
                    if (project.Finishdate > DateTime.Now.Date && project.Startdate > DateTime.Now.Date)
                    {
                        project.state = "Not started Yet";
                    }
                    else if (project.Finishdate > DateTime.Now.Date && project.Startdate <= DateTime.Now.Date)
                    {

                        project.state = "Running";
                    }
                    else if (project.Finishdate < DateTime.Now.Date)
                    {
                        project.state = "Finished";
                    }
                    var data = mapper.Map<WebApplication5.DAL.Entity.Project>(project);
                    pro.create(data);
                    return RedirectToAction("Index");

                }


                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                if (!DateVaildator.validate(project.Startdate, project.Finishdate))
                {
                    ViewBag.valid = SharedLocalizer["Finish date must be greater than Start date"];
                }

                return View(project);

            }
            catch (Exception e)
            {
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                return View(project);
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
        public IActionResult Update(ProjectVM project)
        {
            try
            {
                if (ModelState.IsValid && DateVaildator.validate(project.Startdate, project.Finishdate))
                {
                    var data = mapper.Map<WebApplication5.DAL.Entity.Project>(project);
                    pro.update(data);
                    return RedirectToAction("Index")
;
                }
                ViewBag.valid = SharedLocalizer["Finish date must be greater than Start date"];
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                return View(project);
            }
            catch (Exception ee)
            {
                ViewBag.departmentlist = new SelectList(dept.get(), "id", "name");
                return View(project);
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
            work.deleteProject(proj.id);
            var data = mapper.Map<WebApplication5.DAL.Entity.Project>(proj);
            pro.delete(data);
            return RedirectToAction("Index")
;


        }



    }
}
