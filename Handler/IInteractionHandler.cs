using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;
using InteractionSystem.Interactable;
using InteractionSystem.Interactor;

namespace InteractionSystem.Handler
{
    public interface IInteractionHandler
    {
        bool HandleInteraction<TInteractionRequestInfo, TInteractionResponse>(IInteractor<TInteractionResponse> interactor, IInteractable<TInteractionRequestInfo, TInteractionResponse> interactable, in IInteractionRequest<TInteractionRequestInfo> request, out TInteractionResponse interactionResponse)
            where TInteractionResponse : IInteractionResponse;
    }

    public interface IInteractionHandler<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        bool HandleInteraction<UInteractor, UInteractable>(UInteractor interactor, UInteractable interactable, in IInteractionRequest<TInteractionRequestInfo> request, out TInteractionResponse interactionResponse)
            where UInteractor : IInteractor<TInteractionResponse>
            where UInteractable : IInteractable<TInteractionRequestInfo, TInteractionResponse>;
    }
}