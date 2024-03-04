using MassTransit;

namespace BetBoss.Statistics.Domain.SagaModels
{
    public class ItensRegister<T> : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public string TipoItem { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
