using InteractionSystem.Data;
using InteractionSystem.Interactable;
using InteractionSystem.Interactor;
using UnityEngine;

namespace InteractionSystem.Handler
{
    public class InteractionHandler : MonoBehaviour, IInteractionHandler
    {
        public void HandleInteraction<TInteractionRequestInfo, TInteractionResponse>(IInteractor<TInteractionResponse> interactor, IInteractable<TInteractionRequestInfo, TInteractionResponse> interactable, in IInteractionRequest<TInteractionRequestInfo> request)
            where TInteractionResponse : IInteractionResponse
        {
            TInteractionResponse response = interactable.TryInteract(request);
            interactor?.TryInteract(response);
        }
    }
}