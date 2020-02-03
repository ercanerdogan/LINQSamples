using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GroupByLINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var pairs = from a in numbersA
            //            from b in numbersB
            //            where a < b
            //            select (a, b);

            //Console.WriteLine("Pairs where a<b : ");
            //foreach (var pair in pairs)
            //{
            //    Console.WriteLine($"{pair.a} is less than {pair.b}");

            //}


            string jsonData = "[" +
                    "{\"Title\":\"Sphere\", \"Author\":\"Michael Crichton\", \"Genre\":\"ScienceFiction\", \"IsFiction\": true}," +
                    "{\"Title\":\"Jurassic Park\",\"Author\":\"Michael Crichton\", \"Genre\":\"ScienceFiction\",\"IsFiction\": true},"+
                    "{\"Title\":\"Working effectively with legacy code\", \"Author\":\"Michael Feathers\",\"Genre\":\"Techical\",\"IsFiction\": false},"+
                    "{\"Title\":\"Your code as a crime scene\",\"Author\":\"Adam Tornhill\",\"Genre\":\"Techical\",\"IsFiction\": false},"+
                    "{\"Title\":\"Software Design x-rays\", \"Author\":\"Adam Tornhill\", \"Genre\":\"Techical\",\"IsFiction\": false}"+
                "]";

            
            //dynamic obj = JsonConvert.DeserializeObject(jsonData);

            IEnumerable<Book> bookList = JsonConvert.DeserializeObject<IEnumerable<Book>>(jsonData);

            var result = bookList.GroupBy(b => b.Author);

            var grouped = bookList.GroupBy(b => b.Author, b => b.Title, (key, value) => new { Author = key, Books = value }, StringComparer.CurrentCultureIgnoreCase);

            //var people = bookList.SelectMany(b => b.Genre, (b,c)=> new { Book = b.Title, Genre=c});
            var people = bookList.SelectMany(b => b.Genre, (b, c) => $"{c} ({b.Title})");


            Console.ReadKey();




        }
    }

    public class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public bool IsFiction;
    }
}
