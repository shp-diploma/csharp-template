using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;


namespace Tests
{
    public class Tests
    {
        List<string> builtIn = new List<string>
        {
            "Boolean",
            "Byte",
            "SByte",
            "Char",
            "Decimal",
            "Double",
            "Single",
            "Int32",
            "UInt32",
            "Int64",
            "UInt64",
            "UInt16",
            "Int16"
        };

        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestVariables()
        {
            var props = typeof(Lab1.Lab1).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            //TestContext.Progress.WriteLine($"Field count: {props.Length}");

            var dict = builtIn.ToDictionary(x => $"System.{x}", x => false);

            foreach (var prop in props)
            {
                if (dict.ContainsKey(prop.FieldType.ToString()))
                {
                    dict[prop.FieldType.ToString()] = true;
                }

            }

            foreach (var val in dict.Values)
            {
                Assert.IsTrue(val);
                //TestContext.Progress.WriteLine(val);
            }
        }

        [Test]
        public void TestNullablePresent()
        {
            var props = typeof(Lab1.Lab1).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            //TestContext.Progress.WriteLine($"Field count: {props.Length}");

            foreach (var prop in props)
            {
                if(prop.FieldType.ToString().Contains("Nullable"))
                {
                    //TestContext.Progress.WriteLine(prop.FieldType);
                    StringAssert.Contains("Nullable", prop.FieldType.ToString());
                }
               
            }
        }
    }
}