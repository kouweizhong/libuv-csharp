using System;
using System.Runtime.InteropServices;

namespace Libuv {
	public struct uv_handle_t {
		public uv_handle_type type;
		public IntPtr close_cb;
		public IntPtr data;
	}
	public struct uv_req_t {
		public uv_req_type type;
		public IntPtr data;
	}
	public struct uv_connect_t {
		public uv_req_type type;
		public IntPtr data;
		public IntPtr cb;
		public IntPtr handle;
	}
	public struct uv_err_t
	{
		public uv_err_code code;
		int sys_errno_;
	}
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void uv_close_cb(IntPtr handle);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void uv_connect_cb(IntPtr conn, int status);
	public enum uv_err_code
	{
		UV_UNKNOWN = -1,
		UV_OK = 0,
		UV_EOF,
		UV_EACCESS,
		UV_EAGAIN,
		UV_EADDRINUSE,
		UV_EADDRNOTAVAIL,
		UV_EAFNOSUPPORT,
		UV_EALREADY,
		UV_EBADF,
		UV_EBUSY,
		UV_ECONNABORTED,
		UV_ECONNREFUSED,
		UV_ECONNRESET,
		UV_EDESTADDRREQ,
		UV_EFAULT,
		UV_EHOSTUNREACH,
		UV_EINTR,
		UV_EINVAL,
		UV_EISCONN,
		UV_EMFILE,
		UV_ENETDOWN,
		UV_ENETUNREACH,
		UV_ENFILE,
		UV_ENOBUFS,
		UV_ENOMEM,
		UV_ENONET,
		UV_ENOPROTOOPT,
		UV_ENOTCONN,
		UV_ENOTSOCK,
		UV_ENOTSUP,
		UV_EPROTO,
		UV_EPROTONOSUPPORT,
		UV_EPROTOTYPE,
		UV_ETIMEDOUT,
		UV_ECHARSET,
		UV_EAIFAMNOSUPPORT,
		UV_EAINONAME,
		UV_EAISERVICE,
		UV_EAISOCKTYPE,
		UV_ESHUTDOWN
	}
	public enum uv_handle_type {
		UV_UNKNOWN_HANDLE = 0,
		UV_TCP,
		UV_NAMED_PIPE,
		UV_TTY,
		UV_FILE,
		UV_TIMER,
		UV_PREPARE,
		UV_CHECK,
		UV_IDLE,
		UV_ASYNC,
		UV_ARES_TASK,
		UV_ARES_EVENT,
		UV_GETADDRINFO,
		UV_PROCESS
	}
	public enum uv_req_type {
		UV_UNKNOWN_REQ = 0,
		UV_CONNECT,
		UV_ACCEPT,
		UV_READ,
		UV_WRITE,
		UV_SHUTDOWN,
		UV_WAKEUP,
		UV_REQ_TYPE_PRIVATE
	}
	public static class Sizes {
		public static readonly int PrepareWatcherSize = 64;
		public static readonly int IdleWatcherSize = 64;
		public static readonly int CheckWatcherSize = 64;
		public static readonly int TimerWatcherSize = 80;
		public static readonly int TcpTSize = 152;
		public static readonly int ShutdownTSize = 16;
		public static readonly int ConnectTSize = 24;
	}
	#if __MonoCS__
	public struct uv_buf_t
	{
		public IntPtr data;
		public IntPtr len;
	}
	#else
	public struct uv_buf_t
	{
		public ulong len;
		public IntPtr data;
	}
	#endif
	// From: http://www.elitepvpers.com/forum/co2-programming/159327-advanced-winsock-c.html
	[StructLayout(LayoutKind.Sequential, Size=16)]
	public struct sockaddr_in
	{
		public const int Size = 16;

		public short sin_family;
		public ushort sin_port;
		public struct in_addr
		{
			public uint S_addr;
			public struct _S_un_b
			{
				public byte s_b1, s_b2, s_b3, s_b4;
			}
			public _S_un_b S_un_b;
			public struct _S_un_w
			{
				public ushort s_w1, s_w2;
			}
			public _S_un_w S_un_w;
		}
		public in_addr sin_addr;
	}
}