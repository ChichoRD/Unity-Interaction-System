using InteractionSystem.Data;

namespace InteractionSystem.Interactable
{
    public interface IRequestOnlyInteractable<in TInteractionRequestInfo> : IInteractable<TInteractionRequestInfo, IInteractionResponse>
    {
        IInteractionResponse IInteractable<TInteractionRequestInfo, IInteractionResponse>.TryInteract(IInteractionRequest<TInteractionRequestInfo> interactionRequest) =>
            TryInteract(interactionRequest);

        new IInteractionResponse TryInteract(IInteractionRequest<TInteractionRequestInfo> interactionRequestInfo);
    }
}