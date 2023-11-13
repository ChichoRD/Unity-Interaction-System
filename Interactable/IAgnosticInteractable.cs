using InteractionSystem.Data;

namespace InteractionSystem.Interactable
{
    public interface IAgnosticInteractable : IInteractable<object, IInteractionResponse>, IResponseOnlyInteractable<IInteractionResponse>, IRequestOnlyInteractable<object>
    {
        IInteractionResponse IInteractable<object, IInteractionResponse>.TryInteract(IInteractionRequest<object> interactionRequest) =>
            new InteractionResponse(TryInteract());

        IInteractionResponse IResponseOnlyInteractable<IInteractionResponse>.TryInteract() =>
            new InteractionResponse(TryInteract());

        IInteractionResponse IRequestOnlyInteractable<object>.TryInteract(IInteractionRequest<object> interactionRequest) =>
            new InteractionResponse(TryInteract());

        new bool TryInteract();
    }
}