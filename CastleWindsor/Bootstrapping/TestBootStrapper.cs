using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CastleWindsor.Bootstrapping
{
	class TestBootStrapper : IContainerBootstrapper
	{
		IWindsorContainer Container { get { return Program.Container; } }
		public void BootStrap()
		{
			Console.WriteLine("Testing");
			Container.Register(Classes.FromThisAssembly()
					.InSameNamespaceAs<IThinger>()
					.WithService.DefaultInterfaces()
					.LifestyleTransient());
		}
	}
}
