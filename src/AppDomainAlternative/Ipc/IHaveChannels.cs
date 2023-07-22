using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AppDomainAlternative.Serializer;

namespace AppDomainAlternative.Ipc;

/// <summary>
/// A collection of <inheritdoc cref="IChannel"/>s use for remoting between <see cref="Domains"/>.
/// </summary>
public interface IHaveChannels : IEnumerable<IChannel>, IResolveProxyIds
{
    /// <summary>
    /// An <see cref="IObservable{T}"/> stream of existing and new <see cref="IChannel"/>.
    /// </summary>
    IObservable<(Domains domain, IChannel channel)> AsObservable { get; }

    /// <summary>
    /// Gets the next instance of a shared instance.
    /// </summary>
    /// <param name="fetch">How the instance should be fetched.</param>
    /// <param name="filter">A filter for fetching the instance.</param>
    /// <param name="cancel">A <see cref="CancellationToken"/> to cancel the await.</param>
    Task<(bool IsHost, T Instance)> GetInstanceOf<T>(
        FetchInstanceBy fetch = FetchInstanceBy.Any,
        Func<bool, T, bool> filter = null,
        CancellationToken cancel = default(CancellationToken))
        where T : class;

    /// <summary>
    /// Creates a proxy instance from a ctor for a class.
    /// </summary>
    /// <param name="baseCtor">The constructor for the class to generate a proxy for.</param>
    /// <param name="hostInstance">If true, the object instance should exist within this process and all method calls from the child/parent process are proxied to this process.</param>
    /// <param name="arguments">The constructor arguments.</param>
    Task<object> CreateInstance(ConstructorInfo baseCtor, bool hostInstance, params object[] arguments);

    /// <summary>
    /// Host a proxy instance that has a default constructor.
    /// </summary>
    /// <param name="instance">The object instance to host.</param>
    Task HostInstance<T>(T instance)
        where T : class, new();

    /// <summary>
    /// Is invoked when a new <see cref="IChannel"/> is opened.
    /// </summary>
    event Action<Domains, IChannel> NewChannel;
}