using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using W3SchoolsFramework.UIMapAllPagesClasses;
//using W3SchoolsFramework.UIMapAllPagesClasses;
// UIMapAllPages.UIW3SchoolsOnlineWebTuWindow.UIW3SchoolsOnlineWebTuDocument.UISearchEdit

namespace Tests
{
    /// <summary>
    /// Summary description for VerifyThatThe_CellTableContainsValue
    /// </summary>
    [CodedUITest]
    public class TableCells
    {

        // private string valueToVerify = "CANADA";
        public TableCells()
        {
           
        }
        // C:\qwalisoft\DataSources\Data.csv
        // "|DataDirectory|\\data.csv"
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\qwalisoft\DataSources\Data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        public void VerifyThatTheCellTableContainsValue()
        {
            string nameToVerifyInTableCell = TestContext.DataRow["Name"].ToString();
            // (Current State) === Action ===> (Next State)
            //
            // 1.   From the "BrowserClosed" state, open an instance of the browser 
            //      (BrowserClosed)  === LaunchBrowser ===> (BrowserOpened)
            BrowserWindow ieBrowser = BrowserWindow.Launch();
            ieBrowser.Maximized = true;

            // 2.    From the the "BrowserOpened" state, enter the W3schools URL in the address bar
            //      (BrowserOpened) == NavigateToHomepage ==> (HomepageOpened)
            ieBrowser.NavigateToUrl(new Uri("https://www.w3schools.com/"));

            // 3.   From the "HomepageOpened" state, Click the search icon to open the search page
            //      (HomepageOpened) == ClickSearchIcontoOpenSearchBox ==> (SearchPageOpened)
            UIMapAllPages w3UiMap = new UIMapAllPages();
            w3UiMap.ClickSearchIconToOpenSearchBox();

            // 4.   From "SearchPageOpened" state, enter the term "HTML Tables" in the search box
            //      (SearchPageOpened) == EnterSearchTerm ==> (SearchPageOpened) 
            w3UiMap.EnterSearchTermInSeachBox();

            // 5.   From the "SearchPageOpened" state, Click the search icon to get search results
            //      (SearchPageOpened) == ClickSearchIconToGetSearchResults ==> (SearchResultsPageOpened) 
            w3UiMap.ClickSearchIconToGetSearchResults();

            // 6.   From the "SearchResultsPageOpened", click on the "HTML Tables" above ("https://www.w3schools.com/html/html_tables.asp")
            //      (SearchResultsPageOpened) == ClickFirstHtmlTablesLink ==> (HtmlTablesPageOpened) 
            w3UiMap.ClickFirstHtmlTablesLink();

            // 7. Verify that the fifth entry entry "Country" contains "CANADA"
            w3UiMap.VerifyThatCanadaExistsInTheFifthRowUnderCountryExpectedValues.UICanadaCellInnerText = nameToVerifyInTableCell;
            w3UiMap.VerifyThatCanadaExistsInTheFifthRowUnderCountry();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
