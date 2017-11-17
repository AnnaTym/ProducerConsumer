namespace SysLogServer.Contracts
{
    public interface IHandler
    {
        void Handle(object obj);
    }
}
