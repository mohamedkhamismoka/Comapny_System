
namespace WebApplication5.BL.interfaces;

   public  interface IEmployee
    {
        IEnumerable<Employee> getbyfilter(Func<Employee, bool> filter = null);
        IEnumerable<Employee> search(Func<Employee, bool> filter);
        Employee getbyid(int id);
        void create(Employee emp);
        void update(Employee emp);
        void delete(Employee emp);

    }

