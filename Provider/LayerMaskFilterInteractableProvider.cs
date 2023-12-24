using InteractionSystem.Data.Response;
using InteractionSystem.Interactable;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InteractionSystem.Provider
{
    internal class LayerMaskFilterInteractableProvider : MonoBehaviour, IInteractableProvider
    {
        private IInteractableProvider _provider;

        [SerializeField]
        private LayerMask _layerMask;

        private void Start() => _provider = GetComponentsInChildren<IInteractableProvider>()
                                            .FirstOrDefault(i => i != (IInteractableProvider)this);

        public IEnumerable<IInteractable<TInteractionRequestInfo, TInteractionResponse>> GetInteractables<TInteractionRequestInfo, TInteractionResponse>() where TInteractionResponse : IInteractionResponse =>
            _provider.GetInteractables<TInteractionRequestInfo, TInteractionResponse>()
            .Where(i => i is not MonoBehaviour behaivour || _layerMask == (_layerMask | (1 << behaivour.gameObject.layer)));
    }
}