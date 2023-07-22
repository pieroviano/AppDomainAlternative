using System;

namespace AppDomainAlternative.Ipc;

/// <summary>
/// An IPC channel for sharing an instance across domains.
/// </summary>
public interface IChannel : IDisposable
{
    /// <summary>
    /// If the instance is hosted from this domain.
    /// </summary>
    bool IsHost { get; }

    /// <summary>
    /// The id for the channel.
    /// </summary>
    long Id { get; }

    /// <summary>
    /// The shared instance between domains.
    /// </summary>
    object Instance { get; }
}