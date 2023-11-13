public readonly struct InteractionRequest<TRequestInfo> : IInteractionRequest<TRequestInfo>
{
    public TRequestInfo RequestInfo { get; }

    public InteractionRequest(TRequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
}