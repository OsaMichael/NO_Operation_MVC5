
using Ninject.Modules;
using Ninject.Web.Common;
using NoOperation_MVC.Interface;
using NoOperation_MVC.Manager;
using NoOperation_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NoOperation_MVC
{
    public class Binders : NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind<DbContext>().ToSelf().InRequestScope();
            Kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();
          
            Bind<IEmployeeManager>().To<EmployeeManager>().InRequestScope();
        }
    }
}