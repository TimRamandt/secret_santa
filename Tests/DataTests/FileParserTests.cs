using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Data;

namespace Tests.DataTests {
    [TestClass]
    public class FileParserTests {

        [TestMethod]
        public void TestCorrectInput()
        {
            string content = 
@"Name: My Test
Tim <someEmail@hotmail.com>
Tom <another@Email.com>
Bart <bartje@gmail.com>";

            var list = FileParser.ParseList(content);

            Assert.AreEqual("My Test", list.Name);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(list[1].Name, "Tom");
            Assert.AreEqual(list[1].Email, "another@Email.com");
            
        }


    }
}
