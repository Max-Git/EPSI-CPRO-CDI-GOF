using System;
using System.Collections.Generic;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sans decorator!");

            Book book = new Book("J. K. Rowling", "Harry Potter IV", 10);
            book.Display();
        
            Video video = new Video("Peter Jackson", "Seigneur des anneaux II", 20, 135);
            video.Display();

            Borrowable borrowable = new Borrowable(video);

            borrowable.Borrow("Elias");

            borrowable.Display();

          
        }
    }

    class Decorator : LibraryItem
    {
        
        LibraryItem Item;
        public Decorator(LibraryItem item)
        {
            Item = item;
        }
        public override void Display()
        {
            Item.Display();
        }
    }

    class Borrowable : Decorator
    {
        LibraryItem Item;
        List<string> borrowers = new List<string>();

        public Borrowable(LibraryItem item) : base(item)
        {
            Item = item;  
        }

        public void Borrow(string borrower)
        {
            borrowers.Add(borrower);
            Item.NumCopies--;
        }
        public override void Display(){

            base.Display();
            foreach (string item in borrowers)
            {
                Console.WriteLine("borrower :"+ item);
            }
        } 
    }
    abstract class LibraryItem
    {
        private int _numCopies;
    
        public int NumCopies
        {
        get { return _numCopies; }
        set { _numCopies = value; }
        }
    
        public abstract void Display();
    }
 
    class Book : LibraryItem
    {
        private string _author;
        private string _title;
        public Book(string author, string title, int numCopies)
        {
        this._author = author;
        this._title = title;
        this.NumCopies = numCopies;
        }
    
        public override void Display()
        {
        Console.WriteLine("\nBook ------ ");
        Console.WriteLine(" Author: {0}", _author);
        Console.WriteLine(" Title: {0}", _title);
        Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    

    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;
    
        public Video(string director, string title,
        int numCopies, int playTime)
        {
        this._director = director;
        this._title = title;
        this.NumCopies = numCopies;
        this._playTime = playTime;
        }
    
        public override void Display()
        {
        Console.WriteLine("\nVideo ----- ");
        Console.WriteLine(" Director: {0}", _director);
        Console.WriteLine(" Title: {0}", _title);
        Console.WriteLine(" # Copies: {0}", NumCopies);
        Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }
}
