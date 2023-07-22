using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AppDomainAlternative.Serializer;

namespace AppDomainAlternative.Ipc;

internal interface IConnection : IDisposable, IEnumerable<IInternalChannel>, IResolveProxyIds
{
    Task<object> CreateInstance(ConstructorInfo ctor, bool hostInstance, params object[] arguments);
    event Action<Domains, IChannel> NewChannel;
    void Terminate(IInternalChannel channel);
    void Write(long channelId, Stream stream);
}