using InteractionSystem.Data.Response;
using InteractionSystem.Interactor;

namespace InteractionSystem.Data.Request
{

    public interface IInteractorRequest<out TRequestInfo, out TInteractor, in TInteractionResponse>
        where TInteractor : IInteractor<TInteractionResponse>
        where TInteractionResponse : IInteractionResponse
    {
        TRequestInfo RequestInfo { get; }
        TInteractor Interactor { get; }
    }
}