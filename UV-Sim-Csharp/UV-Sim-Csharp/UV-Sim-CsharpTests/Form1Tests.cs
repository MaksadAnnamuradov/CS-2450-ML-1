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
    }
}