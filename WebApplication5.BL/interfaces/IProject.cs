

namespace WebApplication5.BL.interfaces;

   public interface IProject
    {
        IEnumerable<Project> get();
        IEnumerable<Project> getFilter(Func<Project, bool> filter = null);
        Project getbyid(int id);
        void create(Project pro);
        void update(Project pro);
        void delete(Project pro);

    }

