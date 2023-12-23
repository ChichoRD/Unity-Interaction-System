using InteractionSystem.Interactable;

namespace InteractionSystem.Data.Response
{
    public interface IInteractableResponse<in TInteractionRequestInfo, out TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        TInteractionResponse Response { get; }
        IInteractable<TInteractionRequestInfo, TInteractionResponse> Interactable { get; }
    }
}
