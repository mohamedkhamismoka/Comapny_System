using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.BL.VM;
using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.interfaces
{
  public  interface IWorks_For
    {
        IEnumerable<Works_For> get();
        IEnumerable<Works_For> getFilter(Func<Works_For, bool> filter = null);
        void create(Works_For work);
        //void update(Works_For work, int id, int oldproject);
        void delete(Works_For work);
      
    }
}
