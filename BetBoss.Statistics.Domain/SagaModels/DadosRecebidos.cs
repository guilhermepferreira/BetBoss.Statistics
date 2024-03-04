using BetBoss.Statistics.Domain.Models;

namespace BetBoss.Statistics.Domain.SagaModels
{
    public class DadosRecebidos<T>
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public string TipoItem { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
