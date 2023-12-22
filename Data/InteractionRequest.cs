
using InteractionSystem.Interactor;

namespace InteractionSystem.Data
{
    public readonly struct InteractionRequest<TRequestInfo> : IInteractionRequest<TRequestInfo>
    {
        public TRequestInfo RequestInfo { get; }

        public InteractionRequest(TRequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }
    }

    public readonly struct InteractionRequest<TRequestInfo, TInteractor, TInteractionResponse> :
        IInteractionRequest<TRequestInfo>,
        IInteractorRequest<TInteractor, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
        where TInteractor : IInteractor<TInteractionResponse>
    {
        public TRequestInfo RequestInfo { get; }
        public TInteractor Interactor { get; }

        public InteractionRequest(TRequestInfo requestInfo, TInteractor interactor)
        {
            RequestInfo = requestInfo;
            Interactor = interactor;
        }
    }
}