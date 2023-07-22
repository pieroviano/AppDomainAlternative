using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AppDomainAlternative.Serializer;

namespace AppDomainAlternative.Ipc.Channels;

internal class MockConnection : IConnection
{
    IEnumerator<IInternalChannel> IEnumerable<IInternalChannel>.GetEnumerator() => throw new NotSupportedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
    Task<object> IConnection.CreateInstance(ConstructorInfo ctor, bool hostInstance, params object[] arguments) => throw new NotSupportedException();
    bool IResolveProxyIds.TryToGetInstanceId(object instance, out long id)
    {
        id = 0;
        return false;
    }
    bool IResolveProxyIds.TryToGetInstance(long id, out object instance)
    {
        instance = null;
        return false;
    }
    public event Action<Domains, IChannel> NewChannel;

    public event Action Terminations;
    public virtual void Terminate(IInternalChannel channel) => Terminations?.Invoke();

    public event Action<long, Stream> Writes;
    public virtual void Write(long channelId, Stream stream) => Writes?.Invoke(channelId, stream);

    public virtual void Dispose()
    {
    }
}