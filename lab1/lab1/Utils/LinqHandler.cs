using lab1.Data;
using lab1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1.Utils
{
    class LinqHandler
    {
        private const int selectCount=5;
        private ToursDbContext _db;
        private static LinqHandler instance;

        public LinqHandler()
        {
            _db = new ToursDbContext();
            DbInitializer.Initialize(_db);
        }

        public static LinqHandler GetInstance()
        {
            if (instance == null)
                instance = new LinqHandler();
            return instance;
        }

        public ToursDbContext DbContext { get { return _db; } }

        public static void Print(string caption, IEnumerable items)
        {
            Console.WriteLine(caption);
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }


        public ICollection SelectTourKinds()
        {
            var tourKinds = _db.TourKinds
                .OrderBy(tourKind => tourKind.Name);
            return tourKinds.Take(selectCount).ToList();
        }

        public ICollection SelectClients()
        {
            var clients = _db.Clients
                .OrderBy(client => client.Name);
            return clients.Take(selectCount).ToList();
        }

        public ICollection SelectClientsByName(string name)
        {
            var clients = _db.Clients
                .Where(client => client.Name.Contains(name))
                .OrderBy(client => client.Name);
            return clients.Take(selectCount).ToList();
        }

        public ICollection SelectTourkindSumByName()
        {
            var tours = _db.Tours
                .Include(t => t.TourKind)
                .Include(t => t.Client)
                .GroupBy(t => t.TourKind.Name, t => t.Price)
                .Select(gr => new
                {
                    TourKindName = gr.Key,
                    Summ = gr.Sum()
                })
                .OrderBy(t => t.TourKindName);
            return tours.Take(selectCount).ToList();
        }

        public ICollection SelectJoinedTours()
        {
            var tours = _db.Tours
                .Include(t => t.TourKind)
                .Include(t => t.Client)
                .Select(tour => new
                {
                    Id = tour.Id,
                    Price = tour.Price,
                    StartDate = tour.StartDate,
                    EndDate = tour.EndDate,
                    TourKind = tour.TourKind.Name,
                    Client = tour.Client.Name,
                })
                .OrderBy(t => t.Price);
            return tours.Take(selectCount).ToList();
        }

        public ICollection SelectToursByKindName(string name)
        {
            var tours = _db.Tours
                .Include(t => t.TourKind)
                .Include(t => t.Client)
                .Where(tour => tour.TourKind.Name.Contains(name))
                .OrderBy(tour => tour.Price);
            return tours.Take(selectCount).ToList();
        }

        public void InsertTourKind(TourKind tourKind)
        {
            _db.TourKinds.Add(tourKind);
            _db.SaveChanges();
        }

        public void InsertTour(Tour tour)
        {           
            _db.Clients.Add(tour.Client);
            _db.TourKinds.Add(tour.TourKind);

            _db.SaveChanges();

            tour.TourKindId = tour.TourKind.Id;
            tour.ClientId = tour.Client.Id;
            _db.Tours.Add(tour);
            _db.SaveChanges();
        }

        public void DeleteTourKindByName(string tourKindName)
        {
            var tourKinds = _db.TourKinds
                .Where(tourKind => tourKind.Name.Equals(tourKindName));
            var tours = _db.Tours
                .Include(tour => tour.TourKind)
                .Where(tour => tour.TourKind.Name.Equals(tourKindName));

            _db.Tours.RemoveRange(tours);
            _db.SaveChanges();

            _db.TourKinds.RemoveRange(tourKinds);
            _db.SaveChanges();
        }

        public void DeleteTourById(int tourId)
        {
            var tours = _db.Tours
               .Where(tour => tour.Id == tourId);

            _db.Tours.RemoveRange(tours);
            _db.SaveChanges();
        }

        public void UpdateClient(Client newClient)
        {
            var oldClient = _db.Clients
                .Where(c => c.Id == newClient.Id)
                .FirstOrDefault();

            if (oldClient != null)
            {
                oldClient.Name = newClient.Name;
                oldClient.Birthday = newClient.Birthday;
                oldClient.Phone = newClient.Phone;
            };
            
            _db.SaveChanges();
        }

    }
}
