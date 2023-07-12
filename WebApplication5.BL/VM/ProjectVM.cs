

namespace WebApplication5.BL.VM;

   public class ProjectVM
    {
    
        public int id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? name { get; set; }
        [Required(ErrorMessage = "location is required")]
        public string? location { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "please select valid Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "start date is required")]
        [DataType(DataType.Date)]

        public DateTime Startdate { get; set; }
        [Required(ErrorMessage = "Finish date is required")]
      
        [DataType(DataType.Date)]
        
        public DateTime Finishdate { get; set; }

      
        public Department? Department { get; set; }

        public string? state { get; set; }



}

