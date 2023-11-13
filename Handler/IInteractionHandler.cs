public interface IInteractionHandler
{
    void HandleInteraction<TInteractionRequestInfo, TInteractionResponse>(IInteractor<TInteractionResponse> interactor, IInteractable<TInteractionRequestInfo, TInteractionResponse> interactable, in IInteractionRequest<TInteractionRequestInfo> request)
        where TInteractionResponse : IInteractionResponse;
}