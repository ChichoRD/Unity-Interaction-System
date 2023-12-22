using InteractionSystem.Data;
using InteractionSystem.Interactable;
using InteractionSystem.Interactor;
using UnityEngine;

namespace InteractionSystem.Handler
{
    public class InteractionHandler : MonoBehaviour, IInteractionHandler
    {
        public bool HandleInteraction<TInteractionRequestInfo, TInteractionResponse>(
            IInteractor<TInteractionResponse> interactor,
            IInteractable<TInteractionRequestInfo, TInteractionResponse> interactable,
            in IInteractionRequest<TInteractionRequestInfo> request,
            out TInteractionResponse interactionResponse)
            where TInteractionResponse : IInteractionResponse
        {
            interactionResponse = interactable.TryInteract(request);
            return interactor?.TryInteract(interactionResponse) ?? true;
        }
    }
}