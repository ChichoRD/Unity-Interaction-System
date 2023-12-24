using System;

namespace InteractionSystem.Interactable
{
    [Serializable]
    [Flags]
    public enum InteractableLayer
    {
        InteractableLayer0 = 1 << 0,
        InteractableLayer1 = 1 << 1,
        InteractableLayer2 = 1 << 2,
        InteractableLayer3 = 1 << 3,
        InteractableLayer4 = 1 << 4,
        InteractableLayer5 = 1 << 5,
        InteractableLayer6 = 1 << 6,
        InteractableLayer7 = 1 << 7,
        InteractableLayer8 = 1 << 8,
        InteractableLayer9 = 1 << 9,
        InteractableLayer10 = 1 << 10,
        InteractableLayer11 = 1 << 11,
        InteractableLayer12 = 1 << 12,
        InteractableLayer13 = 1 << 13,
        InteractableLayer14 = 1 << 14,
        InteractableLayer15 = 1 << 15,
    }
}
