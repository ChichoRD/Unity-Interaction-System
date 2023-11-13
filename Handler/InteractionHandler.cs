﻿using UnityEngine;

public class InteractionHandler : MonoBehaviour, IInteractionHandler
{
    public void HandleInteraction<TInteractionRequestInfo, TInteractionResponse>(IInteractor<TInteractionResponse> interactor, IInteractable<TInteractionRequestInfo, TInteractionResponse> interactable, in IInteractionRequest<TInteractionRequestInfo> request)
        where TInteractionResponse : IInteractionResponse => interactor.TryInteract(interactable.TryInteract(request));
}