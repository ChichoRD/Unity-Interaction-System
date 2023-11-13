using InteractionSystem.Data;
using InteractionSystem.Interactable;
using System.Collections.Generic;

namespace InteractionSystem.Provider
{
    public interface IInteractableProvider
    {
        IEnumerable<IInteractable<TInteractionRequestInfo, TInteractionResponse>> GetInteractables<TInteractionRequestInfo, TInteractionResponse>()
            where TInteractionResponse : IInteractionResponse;
    }
}