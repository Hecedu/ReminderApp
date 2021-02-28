using System;
using System.Collections.Generic;
using System.Text;
using hw_04.Services;

namespace hw_04.Tests
{
    class MockHapticsService : IHapticsService
    {
        public bool triedToPerformHaptics { get; set; }
        public void performHapticFeedback()
        {
            triedToPerformHaptics = true;
        }
    }
}
