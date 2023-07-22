using System;

namespace AppDomainAlternative.Ipc;

/// <summary>
/// When getting a shared instance between <see cref="Domains"/> how the get should fetch the instance.
/// </summary>
[Flags]
public enum FetchInstanceBy
{
    /// <summary>
    /// <see cref="Existing"/> or <see cref="Next"/>
    /// </summary>
    Any = Existing | Next,

    /// <summary>
    /// Only gets an instance if it was already created.
    /// </summary>
    Existing = 1,

    /// <summary>
    /// Only gets the next created instance.
    /// </summary>
    Next = 2
}