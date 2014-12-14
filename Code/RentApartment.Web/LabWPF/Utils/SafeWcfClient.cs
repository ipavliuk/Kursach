using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LabWPF.Utils
{
	public sealed class SafeWcfClient<T, TChannel> : IDisposable
		where T : ClientBase<TChannel>, IDisposable, new()
		where TChannel : class
	{
		T _ProxyClient = default(T);

		public SafeWcfClient()
		{
			_ProxyClient = new T() { };
		}

		public SafeWcfClient(string serviceName, string serviceAddress)
			: this()
		{
			_ProxyClient.ChannelFactory.Endpoint.Name = serviceName;
			_ProxyClient.ChannelFactory.Endpoint.Address = new EndpointAddress(serviceAddress);
		}

		public T Client
		{
			get { return _ProxyClient; }
		}

		public void Dispose()
		{
			try
			{
				if (_ProxyClient != null)
				{
					if (_ProxyClient.State != CommunicationState.Faulted)
					{
						_ProxyClient.Close();
					}
					else
					{
						_ProxyClient.Abort();
					}
				}
			}
			catch (Exception)
			{
				try
				{
					_ProxyClient.Abort();
				}
				catch (Exception) { }
			}
		}
	}
}
