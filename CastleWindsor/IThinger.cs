using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace CastleWindsor
{
	[ServiceContract]
	interface IThinger
	{
		[OperationContract]
		object DoSomething();
	}

	public class Thinger : IThinger
	{
		public object DoSomething()
		{
			return "Hello World";
		}
	}

	public class SOtherThinger : IThinger {
		public object DoSomething() {
			return 1;
		}
	}

}
