namespace MessageReciverService.Contracts
{
    public interface IHandler
    {
        void Handle(object obj);
    }
}
