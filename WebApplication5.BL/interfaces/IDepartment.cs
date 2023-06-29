

namespace WebApplication5.BL.interfaces;

    public interface IDepartment
    {
        IEnumerable<Department> get();
        Department getbyid(int id);
        void create(Department dep);
        void update(Department dep);
        void delete(Department dep);



    }

