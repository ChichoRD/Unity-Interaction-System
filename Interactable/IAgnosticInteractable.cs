using InteractionSystem.Data.Request;
using InteractionSystem.Data.Response;

namespace InteractionSystem.Interactable
{
    public interface IAgnosticInteractable : IInteractable<object, IInteractionResponse>, IResponseOnlyInteractable<IInteractionResponse>, IRequestOnlyInteractable<object>
    {
        IInteractionResponse IInteractable<object, IInteractionResponse>.TryInteract(IInteractionRequest<object> interactionRequest) =>
            new InteractionResponse(TryInteract());

        IInteractionResponse IResponseOnlyInteractable<IInteractionResponse>.TryInteract() =>
            new InteractionResponse(TryInteract());

        bool IRequestOnlyInteractable<object>.TryInteract(IInteractionRequest<object> interactionRequest) =>
            TryInteract();

        new bool TryInteract();
    }
}