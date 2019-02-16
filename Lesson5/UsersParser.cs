using System.Collections.Generic;
using System.Net;

namespace Lesson5
{
    public class UsersParser
    {
        private static int sleep = 0;
        private static int per_page = 3;
        private static string url = $@"https://reqres.in/api/users?delay={sleep}&per_page={per_page}";
        private static DelegateEditStatus _status;

        public UsersParser(DelegateEditStatus status)
        {
            _status = status;
        }

        public Result GetUsers(int page)
        {
            try
            {
                _status(Status.DOWNLOADING);
                WebClient web = new WebClient();
                string json = web.DownloadString(url + "&page=" + page);

                _status(Status.GOOD);
                return (Result)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(Result));
            }
            catch
            {
                _status(Status.ERROR);
                return null;
            }
        }
    }
}