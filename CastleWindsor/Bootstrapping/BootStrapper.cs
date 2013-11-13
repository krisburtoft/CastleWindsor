using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor.Configuration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace CastleWindsor.Bootstrapping
{
	class BootStrapper
	{
		public static void Initialize()
		{
			Program.Container = new WindsorContainer(new XmlInterpreter());
			Program.Container.Resolve<IContainerBootstrapper>().BootStrap();
		}
	}
}
