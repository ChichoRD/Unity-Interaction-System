using InteractionSystem.Data;
using InteractionSystem.Interactable;
using InteractionSystem.Interactor;
using System.Collections.Generic;

namespace InteractionSystem.Handler
{
    public class HistoricalInteractionHandler<TInteractionRequestInfo, TInteractionResponse> :
        IInteractionHandler<TInteractionRequestInfo, TInteractionResponse>,
        IInteractionHistoryService<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        private readonly IInteractionHandler _interactionHandler;
        private readonly Dictionary<
            IInteractorRequest<IInteractor<TInteractionResponse>, TInteractionResponse>,
            IList<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>> _interactionHistory;

        public IReadOnlyCollection<
            KeyValuePair<
                IInteractorRequest<IInteractor<TInteractionResponse>, TInteractionResponse>,
                IList<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>>>
            InteractionHistory => _interactionHistory; 

        public HistoricalInteractionHandler(IInteractionHandler interactionHandler)
        {
            _interactionHandler = interactionHandler;
            _interactionHistory = new Dictionary<
                IInteractorRequest<IInteractor<TInteractionResponse>, TInteractionResponse>,
                IList<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>>();
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

                if (!_interactionHistory.ContainsKey(interactionRequest))
                    _interactionHistory[interactionRequest] = new List<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>();

                _interactionHistory[interactionRequest].Add(interactableResponse);
            }

            return handled;
        }
    }
}