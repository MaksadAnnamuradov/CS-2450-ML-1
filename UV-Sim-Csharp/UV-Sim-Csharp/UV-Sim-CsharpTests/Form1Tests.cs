using Microsoft.VisualStudio.TestTools.UnitTesting;
using UV_Sim_Csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UV_Sim_Csharp.Tests
{
    [TestClass]
    public class Form1Tests
    {
        [TestMethod]
        public void TestGUI()
        {
            Form1 _Form1 = new Form1();
            var temp = _Form1.Memory;
            int[] Compare = new int[1000];
            Assert.AreEqual(temp.GetType(), Compare.GetType());
        }
        [TestMethod]
        public void TestConvertBinary()
        {
            Form1 _Form1 = new Form1();
            string a = _Form1.ConvertBinary(201);
            string answer = "11001001";
            Assert.AreEqual(a, answer);
        }
        [TestMethod]
        public void TestBinaryAdd()
        {
            Form1 _Form1 = new Form1();
            string a = _Form1.ConvertBinary(1001);
            string b = _Form1.ConvertBinary(1005);
            string c = _Form1.BinaryAdd(a, b);
            string answer = "0101010110";
            Assert.AreEqual(c, answer);
        }
        [TestMethod]
        public void TestBinarySubtract()
        {
            Form1 _Form1 = new Form1();
            string a = _Form1.ConvertBinary(1001);
            string b = _Form1.ConvertBinary(1005);
            string c = _Form1.BinarySub(a, b);
            string answer = "11111111";
            Assert.AreEqual(c, answer);
        }
        [TestMethod]
        public void TestBinaryMultiply()
        {
            Form1 _Form1 = new Form1();
            int a = 1001;
            int b = 1005;
            int c = _Form1.BinaryMulti(a, b);
            int answer = 466;
            Assert.AreEqual(c, answer);
        }
        [TestMethod]
        public void TestBinaryDivide()
        {
            Form1 _Form1 = new Form1();
            int a = 1001;
            int b = 1005;
            int c = _Form1.BinaryDivide(a, b);
            int answer = 1;
            Assert.AreEqual(c, answer);
        }
        [TestMethod]
        public void TestBinaryMod()
        {
            Form1 _Form1 = new Form1();
            int a = 1001;
            int b = 1005;
            int c = _Form1.BinaryMod(a, b);
            int answer = -4;
            Assert.AreEqual(c, answer);
        }
    }
}