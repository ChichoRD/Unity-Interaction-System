using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;
using InteractionSystem.Handler.Observable;
using InteractionSystem.Interactable;
using InteractionSystem.Interactor;
using System.Collections.Generic;

namespace InteractionSystem.Handler.History
{
    public class HistoricalInteractionHandler<TInteractionHandler, TInteractionRequestInfo, TInteractionResponse> :
        IInteractionHandler<TInteractionRequestInfo, TInteractionResponse>,
        IInteractionHistoryService<TInteractionRequestInfo, TInteractionResponse>,
        IObservableInteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionHandler : IInteractionHandler<TInteractionRequestInfo, TInteractionResponse>, IObservableInteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        private readonly TInteractionHandler _interactionHandler;

        private readonly Dictionary<
            IInteractorRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse>,
            IList<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>> _interactionHistory;

        public IReadOnlyCollection<
            KeyValuePair<
                IInteractorRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse>,
                IList<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>>>
            InteractionHistory => _interactionHistory; 

        public event InteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse> InteractionRequestResponseProcessed
        {
            add => _interactionHandler.InteractionRequestResponseProcessed += value;
            remove => _interactionHandler.InteractionRequestResponseProcessed -= value;
        }

        public HistoricalInteractionHandler(TInteractionHandler interactionHandler)
        {
            _interactionHandler = interactionHandler;
            _interactionHistory = new Dictionary<
                IInteractorRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse>,
                IList<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>>();

            InteractionRequestResponseProcessed += OnInteractionRequestResponseProcessed;
        }

        ~HistoricalInteractionHandler()
        {
            InteractionRequestResponseProcessed -= OnInteractionRequestResponseProcessed;
        }

        public bool HandleInteraction<UInteractor, UInteractable>(
            UInteractor interactor,
            UInteractable interactable,
            in IInteractionRequest<TInteractionRequestInfo> request,
            out TInteractionResponse interactionResponse)
            where UInteractor : IInteractor<TInteractionResponse>
            where UInteractable : IInteractable<TInteractionRequestInfo, TInteractionResponse> =>
            _interactionHandler.HandleInteraction(interactor, interactable, request, out interactionResponse);

        private void OnInteractionRequestResponseProcessed(IInteractorRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse> interactionRequest, IInteractableResponse<TInteractionRequestInfo, TInteractionResponse> interactionResponse)
        {
            if (!_interactionHistory.ContainsKey(interactionRequest))
                _interactionHistory.Add(
                    interactionRequest,
                    new List<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>());

            _interactionHistory[interactionRequest].Add(interactionResponse);
        }
    }
}