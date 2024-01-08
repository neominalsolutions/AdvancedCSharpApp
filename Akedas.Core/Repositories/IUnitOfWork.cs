using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Core
{
  public interface IUnitOfWork
  {

    void Commit(); // execute query sorgusunun çalıştığı yer, saveChanges();
  }
}
