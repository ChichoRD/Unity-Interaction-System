using InteractionSystem.Data.Response;

namespace InteractionSystem.Handler.Observable
{
    public delegate void InteractionResponseHandler<out TInteractionRequestInfo, in TInteractionResponse>(IInteractableResponse<TInteractionRequestInfo, TInteractionResponse> interactionResponse)
        where TInteractionResponse : IInteractionResponse;

    public interface IObservableInteractionResponseHandler<in TInteractionRequestInfo, out TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        event InteractionResponseHandler<TInteractionRequestInfo, TInteractionResponse> InteractionResponseProcessed;
    }
}
