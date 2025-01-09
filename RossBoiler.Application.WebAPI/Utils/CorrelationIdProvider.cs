using RossBoiler.Common;

namespace RossBoiler.Application.WebAPI.Utils
{

    public class CorrelationIdProvider : ICorrelationIdProvider
    {
        private static AsyncLocal<string> _correlationId = new AsyncLocal<string>();

        public string CorrelationId => _correlationId.Value ?? GenerateNewCorrelationId();

        public void SetCorrelationId(string correlationId)
        {
            _correlationId.Value = correlationId;
        }

        private string GenerateNewCorrelationId()
        {
            var newId = Guid.NewGuid().ToString();
            _correlationId.Value = newId;
            return newId;
        }
    }

}
