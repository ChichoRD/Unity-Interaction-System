namespace InteractionSystem.Data.Request
{
    public interface IInteractionRequest<out TRequestInfo>
    {
        TRequestInfo RequestInfo { get; }
    }
}