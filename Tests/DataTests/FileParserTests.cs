using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Data;
using Logic.Models;

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

        [TestMethod]
        public void TestParseToText()
        {
            var list = new ParticipantList();
            list.Name = "ToText";

            list.Add(new Participant() {
                Name = "Tim",
                Email = "some@email.com"
            });
            list.Add(new Participant() {
                Name = "Tom",
                Email = "email@email.com"
            });

            string expected =
@"Name: ToText 
Tim <some@email.com> 
Tom <email@email.com> 
" ;

            Assert.AreEqual(expected,FileParser.ParseToText(list));
        }


    }
}
