

using log4net.Core;

namespace FestaLive.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent=loggingEvent;
        }

        public object Message => _loggingEvent.MessageObject;
    }
}
