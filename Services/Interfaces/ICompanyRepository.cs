using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICompanyRepository:BaseInterfaces<Guid,CreateCompanyViewModel>
    {
    }
}
