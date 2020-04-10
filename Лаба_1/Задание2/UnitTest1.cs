using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2;

namespace UnitTestProject1
{

    [TestClass]
    public class UnitTestTask2
    {
        [TestMethod]
        public void TestCorrect()
        {
            string test = "http://google.com";
            StringFormatter stringGormatter = new StringFormatter();
            Assert.AreEqual(test, stringGormatter.WebString(test));
            test = "https://google.com";
            Assert.AreEqual(test, stringGormatter.WebString(test));
        }        

        [TestMethod]
        public void TestGit()
        {
            string test = "github.com:Anastasiya/Laba.git";
            StringFormatter stringGormatter = new StringFormatter();
            Assert.AreEqual("git://" + test, stringGormatter.WebString(test));
            test = "git://github.com:Anastasiya/Laba.git";
            Assert.AreEqual(test, stringGormatter.WebString(test));           
            test = "github.git.com:Anastasiya/Laba.git";
            Assert.AreEqual("git://" + test, stringGormatter.WebString(test));
        }                
        
        [TestMethod]
        public void TestAddProtocol()
        {
            string test = "lalalala";
            StringFormatter stringGormatter = new StringFormatter();
            Assert.AreEqual("http://" + test, stringGormatter.WebString(test));
            test = "lalalala.http.com";
            Assert.AreEqual("http://" + test, stringGormatter.WebString(test));
            
            test = "lalalala.com/http/https";
            Assert.AreEqual("http://" + test, stringGormatter.WebString(test));
        }        
        
        [TestMethod]
        public void TestEmpty()
        {
            string test = "";
            StringFormatter stringGormatter = new StringFormatter();
            Assert.AreEqual(stringGormatter.WebString(test), test);

            test = "   ";
            Assert.AreEqual(stringGormatter.WebString(test), "");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestException()
        {
            string test = null;
            StringFormatter stringGormatter = new StringFormatter();
            stringGormatter.WebString(test);
        }
    }
}
