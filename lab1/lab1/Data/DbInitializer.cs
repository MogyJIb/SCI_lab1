using lab1.Models;
using lab4.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ToursDbContext db)
        {
            db.Database.EnsureCreated();

            int clientsCount = 40;
            int toursCount = 40;
            int tourkindsCount = 100;

            InitializeTourkinds(db, tourkindsCount);
            InitializeClients(db, clientsCount);
            InitializeTours(db, toursCount, clientsCount, tourkindsCount);

        }

        private static void InitializeTours(ToursDbContext db, int toursCount, int clientsCount, int tourkindsCount)
        {
            db.Database.EnsureCreated();

            // Check if table Tours has elements
            if (db.Tours.Any())
            {
                return;   // Database was initialised
            }

            double price;
            int tourKindId;
            int clientId;
            DateTime startDate;
            DateTime endDate;
           
            Random randObj = new Random(1);
            for (int id = 1; id <= toursCount; id++)
            {
                startDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                endDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));

                tourKindId = randObj.Next(1, tourkindsCount - 1);
                clientId = randObj.Next(1, clientsCount - 1);
                price = randObj.NextDouble()*10;

                db.Tours.Add(new Tour
                {
                    ClientId = clientId,
                    TourKindId = tourKindId,
                    StartDate = startDate,
                    EndDate = endDate,
                    Price = price
                });           
            }

            //save changes in database
            db.SaveChanges();
        }

        private static void InitializeClients(ToursDbContext db, int clientsCount)
        {
            db.Database.EnsureCreated();

            // Check if table Clients has elements
            if (db.Clients.Any())
            {
                return;   // Database was initialised
            }

            string name;
            string phone;
            DateTime birthday;

            Random randObj = new Random(1);
            for (int id = 1; id <= clientsCount; id++)
            {
                birthday = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                
                phone =""+randObj.Next(1000000, 9999999);
                name = MyRandom.RandomString(randObj.Next(5, 10));         

                db.Clients.Add(new Client
                {
                    Name = name,
                    Birthday = birthday,
                    Phone = phone
                });
            }

            //save changes in database
            db.SaveChanges();
        }

        private static void InitializeTourkinds(ToursDbContext db, int tourkindsCount)
        {
            db.Database.EnsureCreated();

            // Check if table TourKinds has elements
            if (db.TourKinds.Any())
            {
                return;   // Database was initialised
            }

            string name;
            string description;
            string constraints;

            Random randObj = new Random(1);
            for (int id = 1; id <= tourkindsCount; id++)
            {
                name = MyRandom.RandomString(randObj.Next(5, 10));
                description = MyRandom.RandomString(randObj.Next(15, 40));
                constraints = MyRandom.RandomString(randObj.Next(5, 10));

                db.TourKinds.Add(new TourKind
                {
                    Name = name,
                    Description = description,
                    Constraints = constraints
                });
            }

            //save changes in database
            db.SaveChanges();
        }
    }

}
