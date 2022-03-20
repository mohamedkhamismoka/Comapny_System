using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.BL.VM;
using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.Automapper
{
  public  class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, EmpVM>();
            CreateMap<EmpVM, Employee>();
            CreateMap<Department, DeptVM>();
            CreateMap<DeptVM,Department>();
            CreateMap<Project, ProjectVM>();
            CreateMap<ProjectVM, Project>();
            CreateMap<Works_For, Works_ForVM>();
            CreateMap<Works_ForVM, Works_For>();
        }
       
    }
}
