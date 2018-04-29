using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Orbitz_UI_Test.PageObject;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Orbitz_UI_Test.StepDefinitions
{
    [Binding]
    public class TestSteps
    {
        static Home hp = new Home(ObjectRepository.Driver);
        static VacationRentals vr = new VacationRentals(ObjectRepository.Driver);
        static Cars cars = new Cars(ObjectRepository.Driver);
        string baseUrl = "https://www.orbitz.com/";
        #region Given
        [Given(@"I am at the Home page")]
        public void GivenIAmAtTheHomePage()
        {
            NavigationHelper.NavigateToUrl(baseUrl);
            Assert.AreEqual("Orbitz Travel: Vacations, Cheap Flights, Airline Tickets & Airfares", WindowHelper.GetPageTitle());
        }


        #endregion Given

        #region When
        [When(@"I navigate to Vacation Rental")]
        public void WhenINavigateToVacationRental()
        {
            vr = hp.NavigateToVacationRentals();
        }

        [When(@"I Provide ""(.*)"",  ""(.*)"", ""(.*)"", ""(.*)"" and Click on Search button")]
        public void WhenIProvideAndClickOnSearchButton(string destination, string checkIn, string checkOut, int guest)
        {
            vr.SearchVacationRentals(destination, checkIn, checkOut, guest);
        }

        [When(@"I navigate to Cars page")]
        public void WhenINavigateToCarsPage()
        {
            cars = hp.NavigateToCars();
        }

        [When(@"I provide ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" and Click on Advanced options")]
        public void WhenIProvideAndClickOnAdvancedOptions(string pickupLocation, string pickupDate, int pickupTime, 
                                                                                 string dropoffDate, int dropoffTime)
        {
            cars.SearchForRentalCarWithAdvancedOptions(pickupLocation, pickupDate, pickupTime, dropoffDate, dropoffTime);
            Thread.Sleep(2000);
        }

        [When(@"I check on Infant seat, Toddler seat, Navigation system options")]
        public void WhenICheckOnInfantSeatToddlerSeatNavigationSystemOptions()
        {
            CheckBoxHelper.CheckOnCheckBox(cars.InfantSeatChbx);
            CheckBoxHelper.CheckOnCheckBox(cars.ToddlerSeatChbx);
            CheckBoxHelper.CheckOnCheckBox(cars.NavigationSystemChbx);
        }

        #endregion When

        #region Then
        [Then(@"I am at the Vacation Rental page")]
        public void ThenIAmAtTheVacationRentalPage()
        {
            Assert.AreEqual("Vacation Rentals for Cabins, Villas, Condos, Apartments, Cottages - Orbitz.com", WindowHelper.GetPageTitle());
        }

        [Then(@"Result page is displayed with ""(.*)""")]
        public void ThenResultPageIsDisplayedWith(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, WindowHelper.GetPageTitle());
        }


        [Then(@"I am at the Car page")]
        public void ThenIAmAtTheCarPage()
        {
            Assert.AreEqual("Discount Rental Cars & Cheap Airport Car Rental | Orbitz", WindowHelper.GetPageTitle());
        }

        [Then(@"Car type label is shown")]
        public void ThenCarTypeLabelIsShown()
        {            
            Assert.IsTrue(WaitHelper.IsWaitForElement(By.CssSelector("a.toggle-trigger.secondary.gcw-show-adv-options.open"), 45, 250));
            
        }

        #endregion Then

        #region And
        [When(@"Click on Search button")]
        public void WhenClickOnSearchButton()
        {
            ButtonHelper.ClickButton(cars.SearchCarBtn);
        }
        

        #endregion And
    }
}
