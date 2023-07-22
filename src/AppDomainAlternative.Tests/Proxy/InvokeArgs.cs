using System;

namespace AppDomainAlternative.Proxy;

public class InvokeArgs
{
    public Tuple<Type, object>[] Args { get; set; }
    public Type ReturnType { get; set; }
    public bool FireAndForget { get; set; }
    public string MethodName { get; set; }
}