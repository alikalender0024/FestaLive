using Castle.DynamicProxy;
using FestaLive.Core.Utilities.Interceptors.Autofac;
using FestaLive.Core.Utilities.IoC;
using FestaLive.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestaLive.Core.Utilities.Messages;

namespace FestaLive.Business.BusinessAspect
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string role)
        {
            _roles=role.Split(',');
            _httpContextAccessor= ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimsRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }

            }
            throw new Exception(AspectMessages.AuthorazitonDenied);

        }
    }
}
