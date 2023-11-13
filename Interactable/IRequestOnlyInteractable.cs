using InteractionSystem.Data;

namespace InteractionSystem.Interactable
{
    public interface IRequestOnlyInteractable<in TInteractionRequestInfo> : IInteractable<TInteractionRequestInfo, IInteractionResponse>
    {
        IInteractionResponse IInteractable<TInteractionRequestInfo, IInteractionResponse>.TryInteract(IInteractionRequest<TInteractionRequestInfo> interactionRequest) =>
            new InteractionResponse(TryInteract(interactionRequest));

        new bool TryInteract(IInteractionRequest<TInteractionRequestInfo> interactionRequestInfo);
    }
}