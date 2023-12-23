using InteractionSystem.Data.Response;

namespace InteractionSystem.Handler.Observable
{
    internal static class ObservableInteractionHandlerExtensions
    {
        public static InteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse> FromInteractionRequestHandler<TInteractionRequestInfo, TInteractionResponse>(this InteractionRequestHandler<TInteractionRequestInfo, TInteractionResponse> interactionRequestHandler)
            where TInteractionResponse : IInteractionResponse =>
            (interactionRequest, _) => interactionRequestHandler(interactionRequest);

        public static InteractionRequestResponseHandler<TInteractionRequestInfo, TInteractionResponse> FromInteractionResponseHandler<TInteractionRequestInfo, TInteractionResponse>(this InteractionResponseHandler<TInteractionRequestInfo, TInteractionResponse> interactionResponseHandler)
            where TInteractionResponse : IInteractionResponse =>
            (_, interactionResponse) => interactionResponseHandler(interactionResponse);
    }
}
