using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Facilities.WcfIntegration;
using System.ServiceModel;
using System.Reflection;
using System.ServiceModel.Discovery;

namespace CastleWindsor.Bootstrapping
{
	class ServiceBootstrapper : IContainerBootstrapper
	{
		static IWindsorContainer Container { get { return Program.Container; } }
		public void BootStrap()
		{
			AddHosts();
			CreateClient();
		}
		private static void AddHosts()
		{
			Container.AddFacility<WcfFacility>(
				f => f.CloseTimeout = TimeSpan.Zero);
			Container
				.Register(
					Classes
						.FromThisAssembly()
						.InSameNamespaceAs<IThinger>()
						.WithServiceDefaultInterfaces()
						.Configure(c =>
								   c.Named(c.Implementation.Name)
									   .AsWcfService(
										   new DefaultServiceModel()
											   .AddEndpoints(WcfEndpoint
																 .BoundTo(CreateNetTcpBinding())
																 .At(string.Format(
																	 "net.tcp://localhost:9000/{0}",
																	 c.Implementation.Name)
																 )))));
		}
		static void CreateClient()
		{
			Container
					.Register(
						Classes
							.FromThisAssembly()
							.InSameNamespaceAs<Thinger>()
							.WithServiceDefaultInterfaces()
							.Configure(c =>
									   c.Named(c.Implementation.Name)
										   .AsWcfClient(
											   new DefaultClientModel
											   {
												   Endpoint = WcfEndpoint
																	 .BoundTo(CreateNetTcpBinding())
																	 .At(string.Format(
																		 "net.tcp://localhost:9000/{0}",
																		 c.Implementation.Name)
																	 )
											   })));
		}

		private static System.ServiceModel.Channels.Binding CreateNetTcpBinding()
		{
			return new NetTcpBinding
			{
				TransferMode = TransferMode.Streamed,
				OpenTimeout = new TimeSpan(5, 0, 0),
				CloseTimeout = new TimeSpan(5, 0, 0)
			};
		}
	}
}
