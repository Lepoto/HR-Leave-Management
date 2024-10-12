using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class NotFoundException(string name, object key) : Exception($"{name} ({key}) was not found!")
    {
    }
}
