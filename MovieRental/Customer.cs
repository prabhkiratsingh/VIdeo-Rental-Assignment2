using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental2
{
    public class Customer
    {
        public int CustID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public double Phone { get; set; }
    }


    public class Movies
    {
        public int MovieID { get; set; }
        public string Rating{ get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public double Rental_Cost { get; set; }
        public string copies { get; set; }
        public double Genre { get; set; }

    }


    public class RentedMovies
    {
        public int RMID { get; set; }
        public string MovieIDFK { get; set; }
        public string CustIDFK { get; set; }
        public string DateRented { get; set; }
        public double DateReturned { get; set; }
    }  
}
