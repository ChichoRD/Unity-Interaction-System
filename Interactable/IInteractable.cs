public interface IInteractable<in TInteractionRequestInfo, out TInteractionResponse>
    where TInteractionResponse : IInteractionResponse
{
    TInteractionResponse TryInteract(IInteractionRequest<TInteractionRequestInfo> interactionRequest);
}

public interface IResponseOnlyInteractable<out TInteractionResponse> : IInteractable<object, TInteractionResponse>
    where TInteractionResponse : IInteractionResponse
{
    TInteractionResponse IInteractable<object, TInteractionResponse>.TryInteract(IInteractionRequest<object> interactionRequest) =>
        TryInteract();
    TInteractionResponse TryInteract();
}
