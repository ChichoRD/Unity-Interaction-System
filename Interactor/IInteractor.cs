using InteractionSystem.Data;

namespace InteractionSystem.Interactor
{
    public interface IInteractor<in TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        bool TryInteract(TInteractionResponse interactionResponse);
    }
}