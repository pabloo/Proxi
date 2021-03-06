/* 風覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧藍
   | Copyright ｩ Pablo Orozco (pablo@orozco.me).                              |
   | All rights reserved.                                                     |
   |                                                                          |
   | Licensed under the Apache License, Version 2.0 (the "License");          |
   | you may not use this file except in compliance with the License.         |
   | You may obtain a copy of the License at                                  |
   |                                                                          |
   | http://www.apache.org/licenses/LICENSE-2.0                               |
   |                                                                          |
   | Unless required by applicable law or agreed to in writing, software      |
   | distributed under the License is distributed on an "AS IS" BASIS,        |
   | WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. |
   | See the License for the specific language governing permissions and      |
   | limitations under the License.                                           |
   風覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧藍 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxi
{
 	public class ProxyFactory : ProxyFactoryBase
	{
        public ProxyFactory() 
        {
        }

        public ProxyFactory(ProxyBehavior behavior) : base(behavior)
        {
        }

        public virtual TProxy Create<TProxy>(Action<IMethodInvocation> action, params Type[] interfaces)
        {
            Require.ArgumentNotNull(action, "action");
            return behavior.Create<TProxy>(new FuncInterceptor(action), interfaces);
        }

        public virtual TProxy Create<TProxy>(TProxy target, Action<IMethodInvocation> action, params Type[] interfaces)
        {
            Require.ArgumentNotNull(action, "action");
            return behavior.Create<TProxy>(target, new FuncInterceptor(action), interfaces);
        }

        public virtual TProxy Create<TProxy>(Func<IMethodInvocation, object> action, params Type[] interfaces)
        {
            Require.ArgumentNotNull(action, "action");
            return behavior.Create<TProxy>(new FuncInterceptor(action), interfaces);
        }

		public virtual TProxy Create<TProxy>(TProxy target, Func<IMethodInvocation, object> action, params Type[] interfaces)
		{
            Require.ArgumentNotNull(action, "action");
			return behavior.Create<TProxy>(target, new FuncInterceptor(action), interfaces);
		}
	}
}