using InteractionSystem.Interactor;

namespace InteractionSystem.Data
{

    public interface IInteractorRequest<out TInteractor, in TInteractionResponse>
        where TInteractor : IInteractor<TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        TInteractor Interactor { get; }
    }
}