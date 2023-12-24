using InteractionSystem.Data.Response;
using InteractionSystem.Interactable;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem.Provider
{
    internal class HierarchySearchInteractableProvider : MonoBehaviour, IInteractableProvider
    {
        [SerializeField]
        private Transform _searchRoot;

        [SerializeField]
        private bool _includeInactive;

        public IEnumerable<IInteractable<TInteractionRequestInfo, TInteractionResponse>> GetInteractables<TInteractionRequestInfo, TInteractionResponse>() where TInteractionResponse : IInteractionResponse =>
            _searchRoot.GetComponentsInChildren<IInteractable<TInteractionRequestInfo, TInteractionResponse>>(_includeInactive);
            
    }
}