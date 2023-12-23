using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;
using InteractionSystem.Handler.Observable;
using InteractionSystem.Interactable;
using InteractionSystem.Interactor;

namespace InteractionSystem.Handler
{
    public class InteractionNotifierHandler<TInteractionRequestInfo, TInteractionResponse> :
        IInteractionHandler<TInteractionRequestInfo, TInteractionResponse>,
        IObservableInteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        private readonly IInteractionHandler _interactionHandler;

        public event InteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse> InteractionRequestResponseProcessed;

        public InteractionNotifierHandler(IInteractionHandler interactionHandler)
        {
            _interactionHandler = interactionHandler;
        }

        public bool HandleInteraction<UInteractor, UInteractable>(
            UInteractor interactor,
            UInteractable interactable,
            in IInteractionRequest<TInteractionRequestInfo> request,
            out TInteractionResponse interactionResponse)
            where UInteractor : IInteractor<TInteractionResponse>
            where UInteractable : IInteractable<TInteractionRequestInfo, TInteractionResponse>
        {
            bool handled = _interactionHandler.HandleInteraction(interactor, interactable, request, out interactionResponse);
            if (handled)
            {
                InteractionRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse> interactionRequest = new InteractionRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse>(request.RequestInfo, interactor);
                InteractionResponse<TInteractionRequestInfo, TInteractionResponse> interactableResponse = new InteractionResponse<TInteractionRequestInfo, TInteractionResponse>(interactable, interactionResponse);

                InteractionRequestResponseProcessed?.Invoke(interactionRequest, interactableResponse);
            }

            return handled;
        }
    }
}