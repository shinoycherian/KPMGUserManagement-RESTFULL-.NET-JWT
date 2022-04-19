﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.IO;
using System.Configuration;
using Unity;
using Unity.Resolution;
using Unity.Injection;
using Microsoft.Practices.Unity.Configuration;
using KPMG.UserManagement.Models;
namespace KPMG.UserManagement.DataAccessObjects
{
    public class ObjectFactory
    {

        private static IUnityContainer container;

        static ObjectFactory()
        {
         
                container = new UnityContainer();
                container.RegisterType<IUnitOfWork, EFUnitOfWork>();
                container.RegisterType<IObjectContext, ObjectContextAdapter>();
                container.RegisterType<DbContext, UserManagementDBContext>(new InjectionConstructor());
                container.RegisterType<IRepository<User>, EFRepository<User>>();
               // container.RegisterType<IRepository<UserRole>, EFRepository<UserRole>>();
                container.RegisterType<IRepository<Role>, EFRepository<Role>>();
        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetInstance<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="u">The u.</param>
        /// <returns></returns>
        public static T GetInstance<T, U>(U u)
        {
            return container.Resolve<T>(new DependencyOverride<U>(u));
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="u">The u.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public static T GetInstance<T, U, Y>(U u, Y y)
        {
            return container.Resolve<T>(new DependencyOverride<U>(u), new DependencyOverride<Y>(y));
        }
    }
}