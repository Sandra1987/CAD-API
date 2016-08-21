using DataAccess.DBServices;
using DataAccess.DBServices.Interfaces;
using Resolver;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IDBBusinessUnitService, DBBusinessUnitService>();
            registerComponent.RegisterType<IDBUserService, DBUserService>();            
        }
    }
}
