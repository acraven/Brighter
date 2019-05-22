namespace Paramore.Brighter
{
    public interface IAmAPipelineBuilderFactory
    {
        IAmAPipelineBuilder<TRequest> Create<TRequest>() where TRequest : class, IRequest;

        IAmAnAsyncPipelineBuilder<TRequest> CreateAsync<TRequest>() where TRequest : class, IRequest;
    }
}