namespace InteractionSystem.Data
{
    public readonly struct InteractionResponse : IInteractionResponse
    {
        public bool Success { get; }

        public InteractionResponse(bool success)
        {
            Success = success;
        }
    }
}
