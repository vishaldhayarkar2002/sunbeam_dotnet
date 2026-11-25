using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// interface ISpellChecker
//      bool CheckSpelling(word);
// class EnglishSpellChecker
// class FrenchSpellChecker
// class SpanishSpellChecker
// class Editor
//      - _spellChecker
//      - Open()
//      - Validate()
//      - Save()

namespace _03_OopInheritance
{
    interface ISpellChecker
    {
        //int data = 10; //fields are not allowed inside the interface 
        bool CheckSpelling(string word); 
    }
    class EnglishSpellChecker : ISpellChecker
    {
        public bool CheckSpelling(string word)
        {
            Console.WriteLine($"English SpellChecker :{word}");
            return true; 
        }
    }
    class FrenchSpellChecker : ISpellChecker
    {
        public bool CheckSpelling(string word)
        {
            Console.WriteLine($"FrenchSpellChecker SpellChecker :{word}");
            return true;
        }
    }
    class SpanishSpellChecker : ISpellChecker
    {
        public bool CheckSpelling(string word)
        {
            Console.WriteLine($"SpanishSpellChecker SpellChecker :{word}");
            return true;
        }
    }
    class Editor
    {
        private ISpellChecker _spellchecker; 
        public Editor( ISpellChecker spellchecker )
        {
            this._spellchecker = spellchecker;
        }
        public void Open( )
        {
            Console.WriteLine("Document Opened");
        }
        public void Validate( )
        {
            Console.WriteLine("Validate The documenet");
            if( _spellchecker != null )
            {
                _spellchecker.CheckSpelling("word"); 
            }
        }
        public void Save( )
        {
            Console.WriteLine("Document Saved");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new Editor(new EnglishSpellChecker());
            editor.Open();
            editor.Validate();
            editor.Save();
            Console.WriteLine();
            editor = new Editor(new SpanishSpellChecker());
            editor.Open();
            editor.Validate();
            editor.Save();
            Console.WriteLine();
            editor = new Editor(new FrenchSpellChecker());
            editor.Open();
            editor.Validate();
            editor.Save();

        }
    }
}
