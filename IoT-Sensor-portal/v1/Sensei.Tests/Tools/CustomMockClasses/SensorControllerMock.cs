﻿using Sensei.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensei.Data.DbService;
using Sensei.Services;

namespace Sensei.Tests.Tools.CustomMockClasses
{
    public class SensorControllerMock : SensorController
    {
        private string username;

        public SensorControllerMock(string username, ISensorDbService sensorDbService, ISensorApiService sensorApiService) 
            : base(sensorDbService, sensorApiService)
        {
            this.username = username;
        }

        protected override string GetLoggedUsername()
        {
            return this.username;
        }
    }
}
