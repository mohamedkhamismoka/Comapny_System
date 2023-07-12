
namespace WebApplication5.BL.VM;

    public class Works_ForVM
    {



      
        [Required(ErrorMessage = "hours Required")]
        [Range(0, 100, ErrorMessage = "Value out of range")]
        public int hours { get; set; }


   
        public Employee? Employee { get; set; }



        [Range(1, long.MaxValue, ErrorMessage = "please select valid Employee")]
        public int EmployeeId { get; set; }


    
        public Project? Project { get; set; }


        [Required(ErrorMessage = " Choose Project ")]
        [Range(1,long.MaxValue,ErrorMessage ="please select valid project")]
        public int ProjectId { get; set; }



        public Department? department { get; set; }


        [Required(ErrorMessage = "Choose Department")]
        [Range(1, long.MaxValue, ErrorMessage = "please select valid Department")]
        public int DepartmentId { get; set; }



    }

