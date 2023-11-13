using InteractionSystem.Data;
using InteractionSystem.Interactable;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InteractionSystem.Provider.Physics
{
    public class RayInteractableProvider3D : MonoBehaviour, IInteractableProvider
    {
        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        [Min(0)]
        private float _maxDistance = 5.0f;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Vector3 _direction = Vector3.forward;

        [SerializeField]
        private Vector3 _offset = Vector3.zero;

        public IEnumerable<IInteractable<TInteractionRequestInfo, TInteractionResponse>> GetInteractables<TInteractionRequestInfo, TInteractionResponse>()
            where TInteractionResponse : IInteractionResponse
        {
            Vector3 origin = _transform.position + _offset;
            Vector3 direction = _transform.TransformDirection(_direction);

            if (!UnityEngine.Physics.Raycast(origin, direction, out RaycastHit hit, _maxDistance, _layerMask))
                return Enumerable.Empty<IInteractable<TInteractionRequestInfo, TInteractionResponse>>();

            return hit.collider.GetComponentsInChildren<IInteractable<TInteractionRequestInfo, TInteractionResponse>>();
        }

        private void OnDrawGizmosSelected()
        {
            if (_transform == null)
                return;

            Vector3 origin = _transform.position + _offset;
            Vector3 direction = _transform.TransformDirection(_direction);

            Gizmos.color = Color.red;
            Gizmos.DrawRay(origin, direction.normalized * _maxDistance);
        }
    }
}