using CalculatorSelenium.Specs.PageObjects;
using CanvasReplyTestTask.Drivers;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Hooks
{
    /// <summary>
    /// Calculator related hooks
    /// </summary>
    [Binding]
    public class CalculatorHooks
    {
        ///<summary>
        ///  Reset the calculator before each scenario tagged with "Calculator"
        /// </summary>
        [BeforeScenario("Calculator")]
        public static void BeforeScenario(Driver driver)
        {
            var calculatorPageObject = new CalculatorPageObject(driver.Current);
            calculatorPageObject.EnsureCalculatorIsOpenAndReset();
        }
    }
}