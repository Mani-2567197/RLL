using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalTesting
{
    [TestFixture]
    public class TestCases
    {
        Testmethods t = new Testmethods();
        [TestCase]
        public void Admin_Test()
        {

            t.Admin_Check();
        }
        [TestCase]
        public void Doctor_Test()
        {

            t.Doctor_Check();
        }
        [TestCase]
        public void Frontofficer_Test()
        {

            t.Frontofficier_Check();
        }
        [TestCase]
        public void Pharmacist_Test()
        {

            t.Pharmacist_Check();
        }
        [TestCase]
        public void Patient_Test()
        {

            t.Patient_Check();
        }
    }
}
