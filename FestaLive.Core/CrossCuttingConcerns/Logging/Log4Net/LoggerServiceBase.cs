using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FestaLive.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        ILog _logger;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead(path: "log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

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
            if (_logger.IsInfoEnabled)
            {
                _logger.Debug(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Warn(logMessage);
            }
        }
        public void Fatal(object logMessage)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Fatal(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Error(logMessage);
            }
        }
    }
}
