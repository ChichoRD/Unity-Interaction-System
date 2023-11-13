using InteractionSystem.Interactor;

namespace InteractionSystem.Data
{
    public readonly struct InteractorInteractionRequest<TInteractionResponse> : IInteractionRequest<IInteractorRequestInfo<TInteractionResponse>>
        where TInteractionResponse : IInteractionResponse
    {
        public IInteractorRequestInfo<TInteractionResponse> RequestInfo { get; }

        public InteractorInteractionRequest(IInteractor<TInteractionResponse> interactor)
        {
            RequestInfo = new InteractorInfo(interactor);
        }

        private readonly struct InteractorInfo : IInteractorRequestInfo<TInteractionResponse>
        {
            public IInteractor<TInteractionResponse> Interactor { get; }

            public InteractorInfo(IInteractor<TInteractionResponse> interactor)
            {
                Interactor = interactor;
            }
        }
    }
}