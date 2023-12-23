using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;

namespace InteractionSystem.Interactable
{
    public interface IInteractable<in TInteractionRequestInfo, out TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        TInteractionResponse TryInteract(IInteractionRequest<TInteractionRequestInfo> interactionRequest);
    }
}