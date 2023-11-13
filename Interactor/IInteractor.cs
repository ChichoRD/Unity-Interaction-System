public interface IInteractor<in TInteractionResponse>
    where TInteractionResponse : IInteractionResponse
{
    bool TryInteract(TInteractionResponse interactionResponse);
}