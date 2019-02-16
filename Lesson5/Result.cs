using System.Collections.Generic;

namespace Lesson5
{
    public class Result
    {
        public int page;
        public int per_page;
        public int total;
        public int total_pages;
        public List<Data> data;
    }

    public class Data
    {
        public int id;
        public string first_name;
        public string last_name;
        public string avatar;
    }
}