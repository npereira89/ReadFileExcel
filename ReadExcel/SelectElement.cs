using OpenQA.Selenium;
using System;

namespace ToolsQA
{
    internal class SelectElement
    {
        private IWebElement comboBox;

        public SelectElement(IWebElement comboBox)
        {
            this.comboBox = comboBox;
        }

        internal void SelectByValue(string v)
        {
            throw new NotImplementedException();
        }
    }
}