// Copyright 2007-2008 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Services.HealthMonitoring.Server
{
    using System;
    using System.Collections.Generic;

    public interface IHealthCache
    {
        void Add(HealthInformation information);
        IList<HealthInformation> List();
        HealthInformation Get(Uri uri);
        void Update(HealthInformation information);

        event Action<HealthInformation> NewHealthInformation;
        event Action<HealthInformation> UpdatedHealthInformation;
    }
}