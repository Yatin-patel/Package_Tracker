using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;
using StructureMap.Graph;
using System.Threading;
using System.Reflection;

namespace Baps.Rbv.Core
{
    public static class Factory
    {
        // http://www.codeproject.com/Articles/135114/Dependency-Injection-with-StructureMap-in-ASP-NET
        // private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Lazy<Container> _containerBuilder = new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            return new Container(x => { });
        }

        private static void OnStart(IInitializationExpression init)
        {
            init.Scan(ScanAssemblies);
        }

        private static void ScanAssemblies(IAssemblyScanner scanner)
        {
            var assemblies = GetAssembliesToScan();
            foreach (Assembly assembly in assemblies)
                scanner.Assembly(assembly);
            scanner.WithDefaultConventions();
            scanner.LookForRegistries();
        }

        private static IEnumerable<Assembly> GetAssembliesToScan()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(IsFsaStoreAssembly);
        }

        private static bool IsFsaStoreAssembly(Assembly assembly)
        {
            return assembly.FullName.StartsWith("fsa", StringComparison.InvariantCultureIgnoreCase);
        }

        public static object Get(Type t)
        {
            return Container.GetInstance(t);
            // return ObjectFactory.GetInstance(t);
        }

        public static T Get<T>()
        {
            try
            {
                return Container.GetInstance<T>();
                // return ObjectFactory.GetInstance<T>();
            }
            catch (StructureMapException ex)
            {
                // log.Error("", ex);
                // throw new InvalidOperationException(ObjectFactory.WhatDoIHave(), ex);
                throw new InvalidOperationException(Container.WhatDoIHave(), ex);
            }
        }

        public static T Get<T, TParam>(TParam param)
        {
            try
            {
                // return ObjectFactory.With<TParam>(param).GetInstance<T>();
                return Container.With<TParam>(param).GetInstance<T>();
            }
            catch (StructureMapException ex)
            {
                // log.Error("", ex);
                throw new InvalidOperationException(Container.WhatDoIHave(), ex);
            }
        }

        public static T Get<T>(string input)
        {
            try
            {
                return Container.GetInstance<T>(input);
                // return ObjectFactory.GetNamedInstance<T>(input);
            }
            catch (StructureMapException ex)
            {
                // log.Error("", ex);
                throw new InvalidOperationException(Container.WhatDoIHave(), ex);
            }
        }

        public static void EjectObjects<T>()
        {
            EjectObjects(typeof(T));
        }
        public static void EjectObjects(Type type)
        {
            var list = Container.Model.For(type)
                .Instances;
            foreach (var i in list)
            {
                i.EjectObject();
            }
        }
    }
}
