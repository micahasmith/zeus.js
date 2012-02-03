using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Domain;

namespace Zeus.Tests
{
    /// <summary>
    /// Summary description for ZeusParser_Tests
    /// </summary>
    [TestClass]
    public class ZeusParser_Tests
    {
    

        [TestMethod]
        public void Will_parse_a_single_command_without_arguments_correctly()
        {
            var cns=ZeusParser.ParseUrl("http://www.domain.com/index.aspx?add=0");

            var cnsf = cns.ToArray();
            Assert.AreEqual("add", cnsf[0].Name);
            Assert.AreEqual(0, cnsf[0].Arguments.Count);
        }

        [TestMethod]
        public void Will_parse_a_single_command_with_arguments_correctly()
        {
            var cns = ZeusParser.ParseUrl("http://www.domain.com/index.aspx?add=0&0_hi=there");

            var cnsf = cns.ToArray();
            Assert.AreEqual("add", cnsf[0].Name);
            Assert.AreEqual(1, cnsf[0].Arguments.Count);
            Assert.AreEqual("hi", cnsf[0].Arguments.Keys.First());
            Assert.AreEqual("there", cnsf[0].Arguments["hi"]);
        }

        [TestMethod]
        public void Will_parse_multiple_commands_without_arguments_correctly()
        {
            var cns = ZeusParser.ParseUrl("http://www.domain.com/index.aspx?command1=0&command2=1");

            var cnsf = cns.ToArray();
            Assert.AreEqual("command1", cnsf[0].Name);
            Assert.AreEqual(0, cnsf[0].Arguments.Count);

            Assert.AreEqual("command2", cnsf[1].Name);
            Assert.AreEqual(0, cnsf[1].Arguments.Count);
        }

        [TestMethod]
        public void Will_parse_multiple_commands_with_arguments_correctly()
        {
            var cns = ZeusParser.ParseUrl("http://www.domain.com/index.aspx?command1=0&command2=1&0_arg1=0&1_arg2=2");

            var cnsf = cns.ToArray();
            Assert.AreEqual("command1", cnsf[0].Name);
            Assert.AreEqual(1, cnsf[0].Arguments.Count);
            Assert.AreEqual("arg1", cnsf[0].Arguments.Keys.First());
            Assert.AreEqual("0", cnsf[0].Arguments["arg1"]);

            Assert.AreEqual("command2", cnsf[1].Name);
            Assert.AreEqual(1, cnsf[1].Arguments.Count);
            Assert.AreEqual("arg2", cnsf[1].Arguments.Keys.First());
            Assert.AreEqual("2", cnsf[1].Arguments["arg2"]);
        }
    }
}
