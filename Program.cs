using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestEng testEng = new TestEng();
            TestIta testIta = new TestIta();

            testIta.applicationName = "test.exe";
            testEng.applicationName = "debug.exe";

            ApplicationClass a = new ApplicationClass(testEng); 

            //a.testType = testEng;
            a.Test();
 

            Console.Write("Press <RETURN>...");
            Console.ReadLine();
        }
    }


    public class ApplicationClass
    {
        private ITestClass _testClass;

        public ApplicationClass()
        { 
        }

        public ApplicationClass(ITestClass testClass)
        { 
            _testClass = testClass;
        }

        public ITestClass testType
        {
            set
            {
                _testClass=value;
            }
        }

        public void Test()
        {
            _testClass.Test();
        }
    }

    public interface ITestClass
    {
       void Test();
    }

    public class TestIta : ITestClass
    {
      private string appName;

        public string applicationName
        {
            get
            {
                return appName;
            }

            set
            {
                appName = value;
            }
        }

        public void Test()
        { 
            Console.WriteLine ("*** Test dell'applicazion ***");
            Console.WriteLine (appName);
        }
    }

    public class TestEng : ITestClass
    {
         private string appName;

        public string applicationName
        {
            get
            {
                return appName;
            }

            set
            {
                appName = value;
            }
        }

        public void Test()
        {            
             Console.WriteLine ("*** Application Test ***");
             Console.WriteLine (appName);
        }
    }
}
