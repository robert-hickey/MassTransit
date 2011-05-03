// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Saga
{
	using System;
	using System.Linq.Expressions;
	using log4net;

	public class ExistingOrIgnoreSagaPolicy<TSaga, TMessage> :
		ISagaPolicy<TSaga, TMessage>
		where TSaga : class, ISaga
	{
		static readonly ILog _log = LogManager.GetLogger("MassTransit.Saga.ExistingOrIgnoreSagaPolicy");

		private readonly Func<TSaga, bool> _shouldBeRemoved;

		public ExistingOrIgnoreSagaPolicy(Expression<Func<TSaga, bool>> shouldBeRemoved)
		{
			_shouldBeRemoved = shouldBeRemoved.Compile();
		}

		public bool CreateSagaWhenMissing(TMessage message, out TSaga saga)
		{
			saga = null;

			if(_log.IsDebugEnabled)
				_log.DebugFormat("Matching {0} not found, ignoring {1}", typeof(TSaga).Name, typeof (TMessage).Name);

			return false;
		}

		public void ForExistingSaga(TMessage message)
		{
		}

		public void ForMissingSaga(TMessage message)
		{
		}

		public bool ShouldSagaBeRemoved(TSaga saga)
		{
			return _shouldBeRemoved(saga);
		}
	}
}