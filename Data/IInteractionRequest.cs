public interface IInteractionRequest<out TRequestInfo>
{
    TRequestInfo RequestInfo { get; }
}
