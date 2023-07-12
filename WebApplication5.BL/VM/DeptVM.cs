
namespace WebApplication5.BL.VM;

   public  class DeptVM
    {
       
        public int id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MinLength(2,ErrorMessage ="min length is 2")]
        public String name { get; set; }
        public IEnumerable<Employee>? employees { get; set; }
        public IEnumerable<Project>? projects { get; set; }
    }

