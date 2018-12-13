using System;
using System.Collections.Generic;
using BelmanFordRouting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Path
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] vertices = { "S", "A", "B", "C", "D" };

            for (int i = 0; i < vertices.Length; i++)
            {
                if (!Program.Iterate())
                    break;
            }

            Dictionary<string, int> list = new Dictionary<string, int>();

            foreach (var keyValue in Program.memo)
            {
                list.Add(keyValue.Key, keyValue.Value);
            }

            Dictionary<string, int> list1 = new Dictionary<string, int>
            {
                { "S", 0 },
                { "A", 1 },
                { "B", 5 },
                { "C", 4 },
                { "D", 4 },
                { "E", 2 }
            };

            CollectionAssert.AreEqual(Program.memo, list1);
        }
    }
}