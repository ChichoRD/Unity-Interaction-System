using InteractionSystem.Interactable;

namespace InteractionSystem.Data
{
    public interface IInteractableResponse<in TInteractionRequestInfo, out TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        IInteractable<TInteractionRequestInfo, TInteractionResponse> Interactable { get; }
    }
}
