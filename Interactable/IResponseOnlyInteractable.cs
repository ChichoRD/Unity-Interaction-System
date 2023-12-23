using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;

namespace InteractionSystem.Interactable
{
    public interface IResponseOnlyInteractable<out TInteractionResponse> : IInteractable<object, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        TInteractionResponse IInteractable<object, TInteractionResponse>.TryInteract(IInteractionRequest<object> interactionRequest) =>
            TryInteract();
        TInteractionResponse TryInteract();
    }
}