using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Test;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public static Zanroo test = new Zanroo();
        [TestMethod]
        public void TestAssigment1()
        {
            var text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry";
            //var mock = new Mock<Zanroo>();
            //mock.Setup(x => x.Test(new string[] { "simply" }, text)).Returns("Lorem Ipsum is <strong>simply</strong> dummy text of the printing and typesetting industry");
            //mock.Verify()
            //Assert.AreEqual()
            string result = "Lorem Ipsum is <strong>simply</strong> dummy text of the printing and typesetting industry";

            Assert.AreEqual(test.Test(new string[] { "simply" }, text), result);
            Assert.AreEqual(test.Test(new string[] { "Ipsum","printing" }, text), "Lorem <strong>Ipsum</strong> is simply dummy text of the <strong>printing</strong> and typesetting industry");
            Assert.AreEqual(test.Test(new string[] { "simply dummy text","text of the printing" }, text), "Lorem Ipsum is <strong>simply dummy <strong>text</strong> of the printing</strong> and typesetting industry");
            Assert.AreEqual(test.Test(new string[] { "dummy text of the printing", "text of the" }, text), "Lorem Ipsum is simply <strong>dummy <strong>text of the</strong> printing</strong> and typesetting industry");
            Assert.AreEqual(test.Test(new string[] { "dummy text of the printing", "ting and typesetting" }, text), "Lorem Ipsum is simply <strong>dummy text of the prin<strong>ting</strong> and typesetting</strong> industry");
            Assert.AreEqual(test.Test(new string[] { "dummy", "taxi" }, text), text);
            Assert.AreEqual(test.Test(new string[] { "simpy", "dummu" }, text), text);

        }
    }
}
