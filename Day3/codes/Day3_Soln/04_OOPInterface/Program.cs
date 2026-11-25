using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// interface IBackendDeveloper
//      void Develop(); , DbCoding() 
// interface IFrontendDeveloper
//      void Develop(); , UiCoding() 
// class FresherFullStackDeveloper
//      void Develop() -- Develops both
namespace _04_OOPInterface
{
    interface IBackendDeveloper
    {
        void Develop();
        void DbCoding(); 
    }
    interface IFrontendDeveloper
    {
        void Develop();
        void UiCoding(); 
    }
    class FresherFullStackDeveloper : IFrontendDeveloper, IBackendDeveloper
    {
        public void DbCoding()
        {
            Console.WriteLine("Fresher FullStackDeveloper :DbCoding");
        }

        public void Develop()
        {
            Console.WriteLine("Fresher FullStackDeveloper :Develop");
        }

        public void UiCoding()
        {
            Console.WriteLine("Fresher FullStackDeveloper :UiCoding");
        }
    }
    class ExperiencedFullStackDeveloper : IFrontendDeveloper, IBackendDeveloper
    {
        public void DbCoding()
        {
            Console.WriteLine("Experienced : DbCoding");
        }
        void IFrontendDeveloper.Develop()
        {
            Console.WriteLine("Experienced Dev : IFrontEnd.Develop");      
        }
        void IBackendDeveloper.Develop()
        {
            Console.WriteLine("Experienced Dev : IBackendDeveloper.Develop");
        }
        
        public void UiCoding()
        {
            Console.WriteLine("Experienced Dev : UiCoding");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            FresherFullStackDeveloper fresher = new FresherFullStackDeveloper();
            //fresher.DbCoding();
            //fresher.UiCoding();
            //fresher.Develop(); 
            IBackendDeveloper fresher2 = fresher;
            //fresher2.Develop();
            //fresher2.DbCoding();
            IFrontendDeveloper fresher3 = fresher;
            //fresher3.Develop();
            //fresher3.UiCoding(); 
        }

        static void Main(string[] args)
        {
            ExperiencedFullStackDeveloper expert = new ExperiencedFullStackDeveloper();
            IFrontendDeveloper expert2 = expert;
            //expert2.Develop();
            //expert2.UiCoding();
            IBackendDeveloper expert3 = expert; 
            expert3.Develop();
            expert3.DbCoding(); 
            
        }
    }
}
