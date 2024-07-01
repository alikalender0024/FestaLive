using log4net;
using log4net.Repository;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        ILog _logger;

        public LoggerServiceBase(string name)
        {
           
            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository);

            _logger = LogManager.GetLogger(loggerRepository.Name, name);
        }

        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsDebugEnabled => _logger.IsDebugEnabled;
        public bool IsWarnEnabled => _logger.IsWarnEnabled;
        public bool IsFatalEnabled => _logger.IsFatalEnabled;
        public bool IsErrorEnabled => _logger.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Info(logMessage);
            }
        }

        public void Debug(object logMessage)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(logMessage);
            }
        }

        public void Warn(object logMessage)
        {
            if (_logger.IsWarnEnabled)
            {
                _logger.Warn(logMessage);
            }
        }

        public void Fatal(object logMessage)
        {
            if (_logger.IsFatalEnabled)
            {
                _logger.Fatal(logMessage);
            }
        }

        public void Error(object logMessage)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(logMessage);
            }
        }
    }
}
