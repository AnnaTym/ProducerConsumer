using System;

namespace SysLogServer.Listeners
{
    public interface IListener
    {
        Action<byte[]> MessageRecivedAction { get; set; }
        void StartAsync();
        void Stop();
    }
}
