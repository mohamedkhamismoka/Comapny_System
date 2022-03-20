using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.BL.interfaces;
using WebApplication5.BL.VM;
using WebApplication5.DAL.Entity;

namespace WebApplication5.API.Controllers
{
    [Route("~/Employee/Getdata")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee emp;
        private readonly IMapper mapper;
        public EmployeeController(IEmployee emp,IMapper mapper)
        {
            this.emp = emp;
            this.mapper = mapper;
        }

      [HttpGet]
      [Route("~/Api/Employee/getemployees")]
      public IActionResult getemployees()
        {
            try
            {
                var data = emp.get();
                var model = mapper.Map<IEnumerable<EmpVM>>(data);
                return Ok(new ApiResponse<IEnumerable<EmpVM>>()
                {
                    code = "200",
                    status = "OK",
                    message = "data rertrived successfully",
                    Response = model

                });
            }catch(Exception e)
            {
                return NotFound(new ApiResponse<string>()
                {
                    code = "404",
                    status = "NotFound",
                    message = "data not found",
                    Response = e.Message
                });
            }
        }
        [HttpGet]
        [Route("~/Api/Employee/getemployeesbyid/{id}")]
        public IActionResult getemployeesbyid(int id)
        {
            try
            {
                var data = emp.getbyid(id);
                var model = mapper.Map<EmpVM>(data);
                return Ok(new ApiResponse<EmpVM>()
                {
                    code = "200",
                    status = "OK",
                    message = "data rertrived successfully",
                    Response = model

                });
            }
            catch (Exception e)
            {
                return NotFound(new ApiResponse<string>()
                {
                    code = "404",
                    status = "NotFound",
                    message = "data not found",
                    Response = e.Message
                });
            }
        }
        [HttpPost]
        [Route("~/Api/Employee/CreateEmployee")]
        public IActionResult CreateEmployee(EmpVM empo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(empo);
                    emp.create(data);
                    return Ok(new ApiResponse<EmpVM>()
                    {
                        code = "201",
                        status = "Created",
                        message = "data Added",
                        Response=empo

                    });
                }
                return BadRequest(new ApiResponse<string>()
                {
                    code = "400",
                    status = "Bad Request",
                    message = "Validation Error",
                  
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    code = "400",
                    status = "Bad Request",
                    message = "The server could not understand the request due to invalid syntax.",
                    Response = e.Message
                });
            }
        }


        [HttpPut]
        [Route("~/Api/Employee/EditEmployee")]
        public IActionResult EditEmployee(EmpVM empo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(empo);
                    emp.update(data);
                    return Ok(new ApiResponse<EmpVM>()
                    {
                        code = "200",
                        status = "updated",
                        message = "data updated",


                    });
                }
                return BadRequest(new ApiResponse<string>()
                {
                    code = "400",
                    status = "Bad Request",
                    message = "Validation Error",

                });
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    code = "400",
                    status = "Bad Request",
                    message = "Data not updated",
                    Response = e.Message
                });
            }
        }





        [HttpDelete]
        [Route("~/Api/Employee/DeleteEmployee")]
        public IActionResult DeleteEmployee(EmpVM empo)
        {
            try
            {
              
                    var data = mapper.Map<Employee>(empo);
                    emp.delete(data);
                    return Ok(new ApiResponse<EmpVM>()
                    {
                        code = "200",
                        status = "Deleted",
                        message = "Deleted",


                    });
                
              
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    code = "400",
                    status = "Bad Request",
                    message = "Data not Deleted",
                    Response = e.Message
                });
            }
        }
    }
}
