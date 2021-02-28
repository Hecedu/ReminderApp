using System;
using System.Collections.Generic;
using System.Text;
using hw_04.Services;

namespace hw_04.Tests
{
    class MockVibrationService : IVibrationService
    {
        public bool triedToVibrate { get; set; }
        public void Vibrate()
        {
            triedToVibrate = true;
        }
    }
}
