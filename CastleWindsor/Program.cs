using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Facilities.WcfIntegration;
using System.ServiceModel;
using System.Reflection;
using System.ServiceModel.Discovery;

namespace CastleWindsor
{
	class Program
	{
		public static IWindsorContainer Container { get; set; }
		static void Main(string[] args)
		{
			var item = new DefaultServiceModel();
			Bootstrapping.BootStrapper.Initialize();
			
			ConsoleKey key;
			do
			{
				key = Answer();

			} while (key != ConsoleKey.Escape);
			}

		private static ConsoleKey Answer() {
				var answer = Container.Resolve<IThinger>().DoSomething();
				Console.WriteLine(answer);
				return Console.ReadKey().Key;
		}


		

		
	}
}
