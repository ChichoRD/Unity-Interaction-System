using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;
using InteractionSystem.Interactor;

namespace InteractionSystem.Handler.Observable
{
    public delegate void InteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse>(IInteractorRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse> interactionRequest, IInteractableResponse<TInteractionRequestInfo, TInteractionResponse> interactionResponse)
        where TInteractionResponse : IInteractionResponse;

    public interface IObservableInteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse> :
        IObservableInteractionRequestHandler<TInteractionRequestInfo, TInteractionResponse>,
        IObservableInteractionResponseHandler<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        event InteractionRequestHandler<TInteractionRequestInfo, TInteractionResponse> IObservableInteractionRequestHandler<TInteractionRequestInfo, TInteractionResponse>.InteractionRequestProcessed
        {
            add => InteractionRequestResponseProcessed += value.FromInteractionRequestHandler();
            remove => InteractionRequestResponseProcessed -= value.FromInteractionRequestHandler();
        }
        
        event InteractionResponseHandler<TInteractionRequestInfo, TInteractionResponse> IObservableInteractionResponseHandler<TInteractionRequestInfo, TInteractionResponse>.InteractionResponseProcessed
        {
            add => InteractionRequestResponseProcessed += value.FromInteractionResponseHandler();
            remove => InteractionRequestResponseProcessed -= value.FromInteractionResponseHandler();
        }

        event InteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse> InteractionRequestResponseProcessed;
    }
}
