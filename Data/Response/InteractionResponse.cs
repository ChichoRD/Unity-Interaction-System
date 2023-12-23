using InteractionSystem.Interactable;

namespace InteractionSystem.Data.Response
{
    public readonly struct InteractionResponse : IInteractionResponse
    {
        public bool Success { get; }

        public InteractionResponse(bool success)
        {
            Success = success;
        }
    }

    public readonly struct InteractionResponse<TInteractionRequestInfo, TInteractionResponse> :
        IInteractionResponse,
        IInteractableResponse<TInteractionRequestInfo, TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        public IInteractable<TInteractionRequestInfo, TInteractionResponse> Interactable { get; }
        public TInteractionResponse Response { get; }
        public bool Success => Response.Success;

        public InteractionResponse(IInteractable<TInteractionRequestInfo, TInteractionResponse> interactable, TInteractionResponse response)
        {
            Interactable = interactable;
            Response = response;
        }
    }
}
