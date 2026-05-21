using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Domain.Common.Exceptions
{
    public abstract class DomainExceptions : Exception
    {
        protected DomainExceptions(string message) : base(message) { }
    }
}
