using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using FestaLive.Core.CrossCuttingConcerns.Logging.Log4Net;
using FestaLive.Core.Logging;
using FestaLive.Core.Utilities.Interceptors.Autofac;
using FestaLive.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType!=typeof(LoggerServiceBase))
            {
                throw new Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = invocation.Arguments.Select(x => new LogParameter
            {
                Value=x,
                Type=x.GetType().Name,
            }).ToList();
            var logDetail = new LogDetail()
            {
                MethodName=invocation.Method.Name,
                LogParameters=logParameters
            };

            return logDetail;
        }
    }
}
