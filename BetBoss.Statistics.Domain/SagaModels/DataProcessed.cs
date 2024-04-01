namespace BetBoss.Statistics.Domain.SagaModels
{
    public class DataProcessed
    {
        public Guid CorrelationId { get; set; }
        public bool Processed { get; set; }
    }
}
