namespace RossBoiler.Common
{
    public interface ICorrelationIdProvider
    {
        string CorrelationId { get; }
        void SetCorrelationId(string correlationId);
    }
}
