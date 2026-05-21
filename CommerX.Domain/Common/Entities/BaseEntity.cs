using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Domain.Common.Entities;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public Guid createdBy { get; protected set; }
    public DateTime createdOn { get; protected set; }
    protected BaseEntity(Guid id =default, 
        Guid createBy = default,
        DateTime createOn = default)
    {
       Id= id == default ? Guid.NewGuid() : id;
        createBy = createBy == default ? Guid.Empty : createBy;
        createOn = createOn == default ? DateTime.UtcNow : createOn;

    }
}
// if(id = default)
//{
//    Id = Guid.NewGuid();
//}
// else
//{