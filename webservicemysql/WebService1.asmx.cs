using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using webservice;

namespace webservicemysql
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]


    public class WebService1 : System.Web.Services.WebService
    {
        public class isilist
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailID { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
 

        }

        public class entity
        {
            public int id { get; set; }

            public List<isilist> Daleman { get; set; }


        }

        [WebMethod]
        public entity GetUser(int id)
        {
            entity Baxter = new entity();
            var entityboom = new EntityA();
            entityboom = new SelectUser().GetUser(id);
            Baxter.id = entityboom.id;
            Baxter.Daleman = new List<isilist>();
            Baxter.Daleman.Add(new isilist() { FirstName = entityboom.FirstName });
            Baxter.Daleman.Add(new isilist() { LastName = entityboom.LastName });
            Baxter.Daleman.Add(new isilist() { EmailID = entityboom.EmailID });
            Baxter.Daleman.Add(new isilist() { City = entityboom.City });
            Baxter.Daleman.Add(new isilist() { Country = entityboom.Country });
           


            return Baxter;
        }

    }
}
