
namespace WebApplication5.BL.VM;

   public class EmpVM
    {
  
    public EmpVM()
    {
        isActive = false;
        isDeleted = false;

        Creationdate = DateTime.Now;

    }

    public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "min length is 3")]
        public string? name { get; set; }
        [Required(ErrorMessage ="Address required")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}", ErrorMessage = "address must like 12-Streetname-cityname-countryname")]
        public string? address { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public int salary { get; set; }
        [Required(ErrorMessage ="hiredate is required")]
        [DataType(DataType.Date)]
        public DateTime? Hiredate { get; set; }
        public DateTime? Creationdate { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
    [Required(ErrorMessage = "Enter valid phone number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter valid phone number")]
        public long? phone { get; set; }

      

        [Range(1, long.MaxValue, ErrorMessage = "please select valid Department")]
        public int ?departmentid { get; set; }

   
        public Department? Department { get; set; }

        public string ?cvname { get; set; }
        public string? imgname { get; set; }

    [Required(ErrorMessage = "CV is required")]
    public IFormFile? cv { get; set; }
    [Required(ErrorMessage = "Image is required")]
    public IFormFile? img { get; set; }
      

     
    }

