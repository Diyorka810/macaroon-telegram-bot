using System.Collections.Concurrent;

namespace MacaroonBot.Model
{
    public class RegistrationStateStore
    {
        public ConcurrentDictionary<long, RegistrationState> States { get; } = new();
    }
}
