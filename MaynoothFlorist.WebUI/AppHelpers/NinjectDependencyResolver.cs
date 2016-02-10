using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Syntax;
using BusinessLogicLayer;
using DataAccessLayer;

namespace MaynoothFlorist.WebUI.AppHelpers
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist)
    /// Date    : February 9, 2016
    /// 
    /// Project wide Dependency Injection
    /// 
    /// When the MVC Framework needs to create an instance of a class, it calls the static methods of the System.Web.Mvc.IDependency 
    /// Resolver class.
    /// 
    /// We can add DI throughout an MVC application by implementing the IDependencyResolver interface and registering our implementation 
    /// with DepedencyResolver.
    /// 
    /// That way, whenever the framework needs to create an instance of a class, it will call our class, and we can Ninject to create the 
    /// object
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return _kernel.Bind<T>();
        }

        #region MVC IDependencyResolver member
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        #endregion

        private void AddBindings()
        {
            //put additional binding here
            Bind<IRepository>().To<MFRepository>();
        }
    }
}