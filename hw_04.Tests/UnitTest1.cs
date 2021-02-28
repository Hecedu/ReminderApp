using NUnit.Framework;
using hw_04.ViewModels;

namespace hw_04.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            mockNavService = new MockNavService();
            mockVibrationService = new MockVibrationService();
            mockDataStore = new MockDataStore();
            mockHapticsService = new MockHapticsService();
            mockBatteryService = new MockBatteryService();

        }
        MockNavService mockNavService;
        MockVibrationService mockVibrationService;
        MockDataStore mockDataStore;
        MockHapticsService mockHapticsService;
        MockBatteryService mockBatteryService;

        [Test]
        public void TriesToChangePage()
        {
            var contactsVM = new RemindersViewModel(mockNavService, mockDataStore);
            contactsVM.AddCommand.Execute(this);
            Assert.IsTrue(mockNavService.triedToChangePage);
        }
        [Test]
        public void TriesToGoBack()
        {
            var newContactVM = new NewReminderViewModel(mockNavService, mockDataStore, mockVibrationService,mockHapticsService,mockBatteryService);
            newContactVM.CancelCommand.Execute(this);
            Assert.IsTrue(mockNavService.triedToGoBack);
        }
        [Test]
        public void TriesToVibrate()
        {
            var newContactVM = new NewReminderViewModel(mockNavService, mockDataStore, mockVibrationService, mockHapticsService, mockBatteryService);
            newContactVM.CancelCommand.Execute(this);
            Assert.IsTrue(mockVibrationService.triedToVibrate);
        }
        [Test]
        public void TriesToGetBattery()
        {
            var newContactVM = new NewReminderViewModel(mockNavService, mockDataStore, mockVibrationService, mockHapticsService, mockBatteryService);
            newContactVM.SaveCommand.Execute(this);
            Assert.IsTrue(mockBatteryService.triedToGetBattery);
        }
        [Test]
        public void TriesToPerformHaptics()
        {
            var newContactVM = new NewReminderViewModel(mockNavService, mockDataStore, mockVibrationService, mockHapticsService, mockBatteryService);
            newContactVM.SaveCommand.Execute(this);
            Assert.IsTrue(mockHapticsService.triedToPerformHaptics);
        }
    }
}