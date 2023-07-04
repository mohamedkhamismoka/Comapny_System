

namespace WebApplication5.BL.interfaces;

  public  interface IWorks_For
    {
        IEnumerable<Works_For> get();
        IEnumerable<Works_For> getFilter(Func<Works_For, bool> filter = null);
        void create(Works_For work);
        //void update(Works_For work, int id, int oldproject);
        void delete(Works_For work);
    void deleteEmployee(int id);
    void deleteProject(int id);
      
    }

