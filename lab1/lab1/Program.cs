using lab1.Utils;
using System;
using lab1.Models;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqHandler linqHandler = LinqHandler.GetInstance();
            string message = "";

            message = "Select all clients";
            LinqHandler.Print(message, linqHandler.SelectClients());
            Console.WriteLine("");


            Client client = new Client
            {
                Name = "aann",
                Birthday = new DateTime(2000, 10, 10),
                Phone = "123555223"
            };
            linqHandler.UpdateClient(client);
            message = "Update client:";
            Console.WriteLine(message+"\n"+client+ "\nAll successfully\n\n");


            message = "Select clients by name: mo";
            LinqHandler.Print(message, linqHandler.SelectClientsByName("mo"));
            Console.WriteLine("");


            Tour tour = new Tour
            {
                Price = 0.0001,
                StartDate = new DateTime(2017,2,2),
                EndDate = new DateTime(2017, 10, 10),
                TourKind = new TourKind
                {
                    Description = "some description",
                    Name = "active",
                    Constraints = "consfa asd"
                },
                Client = new Client
                {
                    Name = "aann",
                    Birthday = new DateTime(2000, 10, 10),
                    Phone = "123555223"
                }
            };
            linqHandler.InsertTour(tour);
            message = "Insert tour:";
            Console.WriteLine( message + "\n" + tour + "\nAll successfully\n\n");


            message = "Delete tour with id:  1";
            Console.WriteLine(message + "\nAll successfully\n\n");
            linqHandler.DeleteTourById(1);


            message = "Select tours";
            LinqHandler.Print(message, linqHandler.SelectJoinedTours());
            Console.WriteLine("");


            message = "Delete tour kind with name:  active";
            Console.WriteLine(message + "\nAll successfully\n\n");
            linqHandler.DeleteTourKindByName("active");


            TourKind tourKind = new TourKind
            {
                Description = "some description",
                Name = "active",
                Constraints = "consfa asd"
            };
            linqHandler.InsertTourKind(tourKind);
            message = "Insert tourKind:";
            Console.WriteLine(message + "\n" + tourKind + "\nAll successfully\n\n");


            message = "Select tour kinds";
            LinqHandler.Print(message, linqHandler.SelectTourKinds());
            Console.WriteLine("");



            message = "Select tours by kind name:  a";
            LinqHandler.Print(message, linqHandler.SelectToursByKindName("a"));
            Console.WriteLine("");


            message = "Select group sum of tour kind";
            LinqHandler.Print(message, linqHandler.SelectTourkindSumByName());
            Console.WriteLine("\n\n");


            Console.ReadKey();
        }
    }
}
