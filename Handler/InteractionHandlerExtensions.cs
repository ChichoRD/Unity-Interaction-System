using InteractionSystem.Data;
using InteractionSystem.Interactable;
using InteractionSystem.Interactor;

namespace InteractionSystem.Handler
{
    public static class InteractionHandlerExtensions
    {
        public static void HandleInteraction<TInteractionResponse>(this IInteractionHandler handler, IInteractor<TInteractionResponse> interactor, IResponseOnlyInteractable<TInteractionResponse> interactable)
            where TInteractionResponse : IInteractionResponse =>
                handler.HandleInteraction(interactor, interactable, default);

        public static void HandleInteraction<TInteractionRequestInfo>(this IInteractionHandler handler, IRequestOnlyInteractable<TInteractionRequestInfo> interactable, in IInteractionRequest<TInteractionRequestInfo> request) =>
            handler.HandleInteraction(default, interactable, request);
    }
}