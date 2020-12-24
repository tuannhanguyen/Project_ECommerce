using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class ViewModel
    {

        private dbbookEntities _context;
        public ViewModel()
        {
            _context = new dbbookEntities();
        }
        public tbl_category category { get; set; }

        public tbl_book product { get; set; }
        public List<tbl_book> allBooks { get; set; }

        public List<tbl_category> allCatigories { get; set; }
       
    }
}