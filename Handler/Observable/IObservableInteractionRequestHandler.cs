using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;
using InteractionSystem.Interactor;

namespace InteractionSystem.Handler.Observable
{
    public delegate void InteractionRequestHandler<in TInteractionRequestInfo, out TInteractionResponse>(IInteractorRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse> interactionRequestInfo)
        where TInteractionResponse : IInteractionResponse;

    public interface IObservableInteractionRequestHandler<out TInetractionRequestInfo, in TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        event InteractionRequestHandler<TInetractionRequestInfo, TInteractionResponse> InteractionRequestProcessed;
    }
}
