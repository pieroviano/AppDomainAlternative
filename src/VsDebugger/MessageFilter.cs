using System;
using System.Runtime.InteropServices;

namespace VsDebugger;

public class MessageFilter : IOleMessageFilter
{
    private const int handled = 0, retryAllowed = 2, retry = 99, cancel = -1, waitAndDispatch = 2;

    int IOleMessageFilter.HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo) => handled;

    int IOleMessageFilter.RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType) => dwRejectType == retryAllowed ? retry : cancel;

    int IOleMessageFilter.MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType) => waitAndDispatch;

    public static void Register() => CoRegisterMessageFilter(new MessageFilter());

    public static void Revoke() => CoRegisterMessageFilter(null);

    public static void CoRegisterMessageFilter(IOleMessageFilter newFilter) => CoRegisterMessageFilter(newFilter, out _);

    [DllImport("Ole32.dll")]
    public static extern int CoRegisterMessageFilter(IOleMessageFilter newFilter, out IOleMessageFilter oldFilter);
}