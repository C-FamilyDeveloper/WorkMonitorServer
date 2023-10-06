namespace WorkMonitorServer.Models.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public override string Message => "Клиент не найден";
    }
}
