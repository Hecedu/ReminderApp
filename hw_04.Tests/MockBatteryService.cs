using System;
using System.Collections.Generic;
using System.Text;
using hw_04.Services;

namespace hw_04.Tests
{
    class MockBatteryService : IBatteryService
    {
        public bool triedToGetBattery { get; set; }
        public double getBatteryLevel()
        {
            triedToGetBattery = true;
            return 1.0;
        }
    }
}
