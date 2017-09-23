using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fast_Food_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Food_Menu.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1_LoadTest()  //This tests ensures that all the payment 
                                      //options were added to the dropdown menu  
        {
            string[] payment = { " ", "Cash", "Master Card", "Visa", "Debit" } ; //Will go through array of expected options

            foreach (string payOption in payment)
            {
                Assert.AreEqual(pay);
            }
            
        }
    }
}