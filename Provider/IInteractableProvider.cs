using System.Collections.Generic;

public interface IInteractableProvider
{
    IEnumerable<IInteractable<TInteractionRequestInfo, TInteractionResponse>> GetInteractables<TInteractionRequestInfo, TInteractionResponse>()
        where TInteractionResponse : IInteractionResponse;
}