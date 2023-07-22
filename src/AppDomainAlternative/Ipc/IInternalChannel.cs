using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AppDomainAlternative.Proxy;

namespace AppDomainAlternative.Ipc;

internal interface IInternalChannel : IChannel, IInterceptor
{
    BinaryReader Reader { get; }
    IConnection Connection { get; }
    ReadWriteBuffer Buffer { get; }
    Task LocalStart(IGenerateProxies proxyGenerator, ConstructorInfo ctor, bool hostInstance, params object[] arguments);
    Task LocalStart<T>(T instance)
        where T : class, new();
    Task RemoteStart(IGenerateProxies proxyGenerator);
    bool IsDisposed { get; }
}