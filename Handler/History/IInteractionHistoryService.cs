using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;
using InteractionSystem.Interactor;
using System.Collections.Generic;

namespace InteractionSystem.Handler.History
{
    public interface IInteractionHistoryService<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        IReadOnlyCollection<
            KeyValuePair<
                IInteractorRequest<TInteractionRequestInfo, IInteractor<TInteractionResponse>, TInteractionResponse>,
                IList<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>>>
            InteractionHistory { get; }
    }
}