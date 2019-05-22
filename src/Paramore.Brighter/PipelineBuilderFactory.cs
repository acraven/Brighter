using System;

namespace Paramore.Brighter
{
    public class PipelineBuilderFactory : IAmAPipelineBuilderFactory
    {
        private readonly IAmASubscriberRegistry _subscriberRegistry;
        private readonly IAmAHandlerFactory _handlerFactory;
        private readonly IAmAHandlerFactoryAsync _asyncHandlerFactory;

        public PipelineBuilderFactory(
            IAmASubscriberRegistry subscriberRegistry,
            IAmAHandlerFactory handlerFactory,
            IAmAHandlerFactoryAsync asyncHandlerFactory)
        {
            _subscriberRegistry = subscriberRegistry;
            _handlerFactory = handlerFactory;
            _asyncHandlerFactory = asyncHandlerFactory;
        }

        public PipelineBuilderFactory(
            IAmASubscriberRegistry subscriberRegistry,
            IAmAHandlerFactory handlerFactory)
        {
            _subscriberRegistry = subscriberRegistry;
            _handlerFactory = handlerFactory;
        }

        public PipelineBuilderFactory(
            IAmASubscriberRegistry subscriberRegistry,
            IAmAHandlerFactoryAsync asyncHandlerFactory)
        {
            _subscriberRegistry = subscriberRegistry;
            _asyncHandlerFactory = asyncHandlerFactory;
        }

        public IAmAPipelineBuilder<TRequest> Create<TRequest>() where TRequest : class, IRequest
        {
            if (_handlerFactory == null)
                throw new InvalidOperationException("No handler factory defined.");

            return new PipelineBuilder<TRequest>(_subscriberRegistry, _handlerFactory);
        }

        public IAmAnAsyncPipelineBuilder<TRequest> CreateAsync<TRequest>() where TRequest : class, IRequest
        {
            if (_asyncHandlerFactory == null)
                throw new InvalidOperationException("No async handler factory defined.");

            return new PipelineBuilder<TRequest>(_subscriberRegistry, _asyncHandlerFactory);
        }
    }
}
