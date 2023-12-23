using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;
using InteractionSystem.Interactable;
using InteractionSystem.Interactor;

namespace InteractionSystem.Handler
{
    public static class InteractionHandlerExtensions
    {
        public static bool HandleInteraction<TInteractionResponse>(this IInteractionHandler handler, IInteractor<TInteractionResponse> interactor, IResponseOnlyInteractable<TInteractionResponse> interactable, out TInteractionResponse interactionResponse)
            where TInteractionResponse : IInteractionResponse =>
                handler.HandleInteraction(interactor, interactable, default, out interactionResponse);
        public static bool HandleInteraction<TInteractionResponse>(this IInteractionHandler handler, IInteractor<TInteractionResponse> interactor, IResponseOnlyInteractable<TInteractionResponse> interactable)
            where TInteractionResponse : IInteractionResponse =>
                handler.HandleInteraction(interactor, interactable, default, out _);


        public static bool HandleInteraction<TInteractionRequestInfo>(this IInteractionHandler handler, IRequestOnlyInteractable<TInteractionRequestInfo> interactable, in IInteractionRequest<TInteractionRequestInfo> request) =>
            handler.HandleInteraction(default, interactable, request, out _);


        public static bool HandleInteraction<TInteractionRequestInfo, TInteractionResponse>(this IInteractionHandler<TInteractionRequestInfo, TInteractionResponse> handler, IInteractor<TInteractionResponse> interactor, IResponseOnlyInteractable<TInteractionResponse> interactable, out TInteractionResponse interactionResponse)
            where TInteractionResponse : IInteractionResponse =>
            handler.HandleInteraction(interactor, (IInteractable<TInteractionRequestInfo, TInteractionResponse>)interactable, default, out interactionResponse);

        public static bool HandleInteraction<TInteractionRequestInfo, TInteractionResponse>(this IInteractionHandler<TInteractionRequestInfo, TInteractionResponse> handler, IInteractor<TInteractionResponse> interactor, IResponseOnlyInteractable<TInteractionResponse> interactable)
            where TInteractionResponse : IInteractionResponse =>
            handler.HandleInteraction(interactor, interactable, out _);
        

        public static bool HandleInteraction<TInteractionRequestInfo, TInteractionResponse>(this IInteractionHandler<TInteractionRequestInfo, TInteractionResponse> handler, IRequestOnlyInteractable<TInteractionRequestInfo> interactable, in IInteractionRequest<TInteractionRequestInfo> request)
            where TInteractionResponse : IInteractionResponse =>
            handler.HandleInteraction(default(IInteractor<TInteractionResponse>), (IInteractable<TInteractionRequestInfo, TInteractionResponse>)interactable, request, out _);

    }
}