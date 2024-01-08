using AdvancedCSharpApp.SeedWork;
using Akedas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpApp.Entities
{
  public class Category:DeletableEntity<int>
  {
    public string Name { get; private set; } // required
    public string? Description { get; set; } // sonradan güncellenebilir bir alan iin contructor göndermedim, ve zorunlu değil opsiyonel bir alan
    public string? DeletedReason { get; private set; }


    public Category(string name)
    {
      Id = 1;
      Name = name.Trim().ToUpper();
    }

    public void SetDeleted(string reason, string deletedBy)
    {
      DeletedReason = reason;
      DeletedBy = deletedBy;
      DeletedAt = DateTime.Now;
      IsDeleted = true;
    }
  }
}
