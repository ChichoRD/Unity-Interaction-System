using InteractionSystem.Data;
using InteractionSystem.Interactor;
using System;
using System.Collections.Generic;

namespace InteractionSystem.Handler
{
    public interface IInteractionHistoryService<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        IReadOnlyCollection<
            KeyValuePair<
                IInteractorRequest<IInteractor<TInteractionResponse>, TInteractionResponse>,
                IList<IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>>>>
            InteractionHistory { get; }
    }
}