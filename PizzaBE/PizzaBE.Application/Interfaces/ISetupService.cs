using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Interfaces
{
    public interface ISetupService
    {

        Task CreateWorkerLoginAndRolesAsync();
    }
}
