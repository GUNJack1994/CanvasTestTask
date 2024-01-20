using CanvasReplyTestTask.Drivers;
using CanvasReplyTestTask.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace CanvasReplyTestTask.PageObjects.SalesAndMarketingPages
{
    public class CreateContactPage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _wait;

        public CreateContactPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        }

        public IWebElement FirstName => _webDriver.FindElement(By.Name("first_name"));
        public IWebElement LastName => _webDriver.FindElement(By.Name("last_name"));
        public IWebElement Category => _webDriver.FindElement(By.XPath("//div[@id='DetailFormcategories-input-body']/parent::div"));
        public IWebElement SearchToolBar => _webDriver.FindElement(By.XPath("//div[@id='DetailFormcategories-input-search-text']/input"));
        public string ElementIntoCategorySelector => ".menu-option.single";
        public IWebElement Role => _webDriver.FindElement(By.Id("DetailFormbusiness_role-input-label"));
        public IWebElement SaveButton => _webDriver.FindElement(By.Id("DetailForm_save-label"));
        public IWebElement NameFiled => _webDriver.FindElement(By.XPath("//div[@id='_form_header']/h3"));
        public IWebElement Categories => _webDriver.FindElement(By.XPath("//p[text()='Category']/parent::li"));
        public IWebElement BusinessRole => _webDriver.FindElement(By.XPath("//p[text()='Business Role']/parent::div/div"));
        public IWebElement DeleteButton => _webDriver.FindElement(By.Id("DetailForm_delete-label"));
        public string FirstNameAfterCreate { get; set; }
        public string LastNameAfterCreate { get; set; }
        public string FirstCategoryAfterCreate { get; set; }
        public string SecondCategoryAfterCreate { get; set; }
        public string BusinessRoleAfterCreate { get; set; }

        public void CreateContact()
        {
            // Wprowadź dane testowe
            FirstName.SendKeys(SharedBrowserHooks.AppConfig.TestFirstName);
            LastName.SendKeys(SharedBrowserHooks.AppConfig.TestLastName);

            Thread.Sleep(2000);
            // Wybierz pierwszą kategorię
            SelectCategoryOption(SharedBrowserHooks.AppConfig.FirstCategory);

            Thread.Sleep(2000);
            // Wybierz drugą kategorię
            SelectCategoryOption(SharedBrowserHooks.AppConfig.SecondCategory);

            // Wybierz rolę
            Thread.Sleep(2000);
            SelectRoleOption(SharedBrowserHooks.AppConfig.Role);

            // Kliknij przycisk Zapisz
            SaveButton.Click();
        }

        private void SelectCategoryOption(string optionText)
        {
            // Oczekaj na widoczność kategorii
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Category)).Click();

            // Wyszukaj i wybierz kategorię
            SearchAndSelectOption(ElementIntoCategorySelector, optionText, SearchToolBar);
        }

        private void SelectRoleOption(string optionText)
        {
            // Oczekaj na widoczność roli
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Role)).Click();

            SearchAndSelectOption(ElementIntoCategorySelector, optionText);    
        }

        private void SearchAndSelectOption(string optionSelector, string optionText, [Optional]IWebElement searchInput)
        {
            // Wprowadź tekst do wyszukiwania
            if (optionText != SharedBrowserHooks.AppConfig.Role)
            {
                searchInput.SendKeys(optionText);
            }
            // Oczekaj na widoczność opcji
            IList<IWebElement> menuOptions = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(
                By.CssSelector(optionSelector)));

            // Wybierz opcję na podstawie tekstu
            SelectMenuOption(menuOptions, optionText);
        }

        private void SelectMenuOption(IList<IWebElement> menuOptions, string optionText)
        {
            IWebElement option = menuOptions.FirstOrDefault(e => e.Text.Contains(optionText));
            option?.Click();
        }

        public void GetDataFromContact() 
        {
            GetFirstNameAndLastName();
            GetCategories();
            BusinessRoleAfterCreate = BusinessRole.Text;
        }

        public void GetFirstNameAndLastName()
        {
            var splitNameAndLastName = NameFiled.Text.Split(' ').ToList();
            FirstNameAfterCreate = splitNameAndLastName[0];
            LastNameAfterCreate = splitNameAndLastName[1];
        }

        public void GetCategories() 
        {
            var lines = Categories.Text.Split('\n');
            var categoryLine = lines[1].Trim();
            var splitCategories = categoryLine.Split(',').Select(c => c.Trim()).ToList();
            FirstCategoryAfterCreate = splitCategories[0];
            SecondCategoryAfterCreate = splitCategories[1];
        }

        public void DeleteContact() 
        {
            DeleteButton.Click();

            _webDriver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
        }
    }
}