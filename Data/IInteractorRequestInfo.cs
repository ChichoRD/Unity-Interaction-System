public interface IInteractorRequestInfo<in TInteractionResponse>
    where TInteractionResponse : IInteractionResponse
{
    IInteractor<TInteractionResponse> Interactor { get; }
}