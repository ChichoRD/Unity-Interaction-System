using InteractionSystem.Data;
using InteractionSystem.Interactable;
using System.Collections.Generic;
using System.Linq;

namespace InteractionSystem.Provider
{
    public static class InteractableProviderExtensions
    {
        public static IEnumerable<IResponseOnlyInteractable<TInteractionResponse>> GetResponseOnlyInteractables<TInteractionResponse>(this IInteractableProvider provider)
            where TInteractionResponse : IInteractionResponse =>
            provider.GetInteractables<object, TInteractionResponse>().OfType<IResponseOnlyInteractable<TInteractionResponse>>();

        public static IEnumerable<IRequestOnlyInteractable<TInteractionRequestInfo>> GetRequestOnlyInteractables<TInteractionRequestInfo>(this IInteractableProvider provider) =>
            provider.GetInteractables<TInteractionRequestInfo, IInteractionResponse>().OfType<IRequestOnlyInteractable<TInteractionRequestInfo>>();
    }
}