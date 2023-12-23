using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;
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

    public class InteractionHandler<TInteractionRequestInfo, TInteractionResponse> : IInteractionHandler<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        private readonly IInteractionHandler _interactionHandler;

        public InteractionHandler(IInteractionHandler interactionHandler)
        {
            _interactionHandler = interactionHandler;
        }

        public bool HandleInteraction<UInteractor, UInteractable>(
            UInteractor interactor,
            UInteractable interactable,
            in IInteractionRequest<TInteractionRequestInfo> request,
            out TInteractionResponse interactionResponse)
            where UInteractor : IInteractor<TInteractionResponse>
            where UInteractable : IInteractable<TInteractionRequestInfo, TInteractionResponse> =>
            _interactionHandler.HandleInteraction(interactor, interactable, request, out interactionResponse);
    }
}