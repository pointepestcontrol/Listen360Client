using Listen360Client.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Listen360Client.API
{
    public class Listen360Client
    {
        public string ApiKey { private get; set; }
        private Uri BaseAddress { get; } = new Uri($"https://app.listen360.com");
        public Listen360Client(string apiKey)
        {
            ApiKey = apiKey;
        }
        #region Organizations
        public IEnumerable<Organization> GetOrganizations()
        {
            long currentPage = 1;
            int itemCount = 0;
            do
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseAddress;
                    var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var result = client.GetAsync($"organizations.xml?page={currentPage}").Result;
                    using (var stream = result.Content.ReadAsStreamAsync().Result)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(OrganizationCollection));
                        //string resultContent = result.Content.ReadAsStringAsync().Result;
                        var orgs = (OrganizationCollection)serializer.Deserialize(stream);
                        itemCount = orgs.Organizations.Count;
                        foreach (Organization org in orgs.Organizations)
                        {
                            yield return org;
                        }
                        currentPage++;
                    }
                }
            }
            while (itemCount != 100 && itemCount != 0);
        }
        public IEnumerable<Child> GetChildren(Organization parent)
        {
            long currentPage = 1;
            int itemCount = 0;
            do
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseAddress;
                    var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var result = client.GetAsync($"/organizations/{parent.Id.Value}/children.xml?page={currentPage}").Result;
                    using (var stream = result.Content.ReadAsStreamAsync().Result)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ChildrenCollection));
                        // resultContent = result.Content.ReadAsStringAsync().Result;
                        var orgs = (ChildrenCollection)serializer.Deserialize(stream);
                        itemCount = orgs.Children.Count;
                        foreach (Child org in orgs.Children)
                        {
                            yield return org;
                        }
                        currentPage++;
                    }
                }
            }
            while (itemCount != 100 && itemCount != 0);
        }
        public IEnumerable<Descendent> GetDescendents(Organization parent)
        {
            long currentPage = 1;
            int itemCount = 0;
            do
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseAddress;
                    var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var result = client.GetAsync($"/organizations/{parent.Id.Value}/descendents.xml?page={currentPage}").Result;
                    using (var stream = result.Content.ReadAsStreamAsync().Result)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(DescendentCollection));
                        // resultContent = result.Content.ReadAsStringAsync().Result;
                        var orgs = (DescendentCollection)serializer.Deserialize(stream);
                        itemCount = orgs.Descendents.Count;
                        foreach (Descendent org in orgs.Descendents)
                        {
                            yield return org;
                        }
                        currentPage++;
                    }
                }
            }
            while (itemCount != 100 && itemCount != 0);
        }
        public Organization Get<T>(long orgId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var result = client.GetAsync($"/organizations/{orgId}.xml").Result;
                using (var stream = result.Content.ReadAsStreamAsync().Result)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    // resultContent = result.Content.ReadAsStringAsync().Result;
                    return (Organization)serializer.Deserialize(stream);
                }
            }
        }
        public Organization Get(Organization org)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var result = client.GetAsync($"/organizations/{org.Id.Value}.xml").Result;
                XmlSerializer serializer;
                using (var stream = result.Content.ReadAsStreamAsync().Result)
                {
                    switch (org.Type)
                    {
                        case "Division":
                            serializer = new XmlSerializer(typeof(Division));
                            break;
                        case "Franchise":
                            serializer = new XmlSerializer(typeof(Franchise));
                            break;
                        case "Franchisor":
                            serializer = new XmlSerializer(typeof(Franchisor));
                            break;
                        default:
                            throw new NotImplementedException($"The Entity {org.Type} is not supported");
                    }
                     
                    // resultContent = result.Content.ReadAsStringAsync().Result;
                    return (Organization)serializer.Deserialize(stream);
                }
            }
        }
        #endregion
        #region Customers
        public Customer GetCustomer(Customer c)
        {
            return GetCustomer(c.OrganizationId.Value, c.Id.Value);
        }

        public Customer GetCustomer(long orgID, long customerID)
        {
            return Get<Customer>($"/organizations/{orgID}/customers/{customerID}.xml");
        }

        public IEnumerable<Customer> GetCustomers(long orgId, DateTime? updatedBefore = null, DateTime? updatedAfter = null, UInt32 startPage = 1)
        {
            var currentPage = startPage;
            string dateFilter = "";
            int itemCount = 0;
            if (updatedBefore.HasValue)
            {
                dateFilter += $"&updated_before={updatedBefore?.ToString("yyyy-MM-ddThh:mm:sszzz")}";
            }
            if (updatedAfter.HasValue)
            {
                dateFilter += $"&updated_after={updatedAfter?.ToString("yyyy-MM-ddThh:mm:sszzz")}";
            }
            do
            {
                var customers = List<CustomerCollection>($"/organizations/{orgId}/customers.xml", $"page={currentPage}{dateFilter}", "customers");
                if (customers != null)
                {
                    itemCount = customers.Customers.Count;
                    foreach (Customer customer in customers.Customers)
                    {
                        yield return customer;
                    }
                }
                else
                {
                    itemCount = 0;
                }
                currentPage++;
            }
            while (itemCount != 0);
        }

        #endregion
        #region Jobs
        public Job GetJob(Organization org, Job job)
        {
            return GetJob(org.Id.Value, job.Id.Value);
        }
        public Job GetJob(long orgId, Job job)
        {
            return GetJob(orgId, job.Id.Value);
        }
        public Job GetJob(Organization org, long jobId)
        {
            return GetJob(org.Id.Value, jobId);
        }
        public Job GetJob(long orgId, long jobId)
        {
            return Get<Job>($"/organizations/{orgId}/jobs/{jobId}.xml");
        }
        public IEnumerable<Job> GetJobs(long orgId, DateTime? updatedBefore = null, DateTime? updatedAfter = null, UInt32 startPage = 1)
        {
            var currentPage = startPage;
            string dateFilter = "";
            int itemCount = 0;
            if (updatedBefore.HasValue)
            {
                dateFilter += $"&updated_before={updatedAfter?.ToString("yyyy-MM-ddThh:mm:sszzz")}";
            }
            if (updatedAfter.HasValue)
            {
                dateFilter += $"&updated_after={updatedAfter?.ToString("yyyy-MM-ddThh:mm:sszzz")}";
            }
            do
            {
                var jobs = List<JobCollection>($"/organizations/{orgId}/jobs.xml", $"page={currentPage}{dateFilter}", "jobs");
                if (jobs != null)
                {
                    itemCount = jobs.Jobs.Count;
                    foreach (Job job in jobs?.Jobs)
                    {
                        yield return job;
                    }
                }
                else
                {
                    itemCount = 0;
                }
                currentPage++;
            }
            while (itemCount != 0);
        }

        #endregion

        #region Internal Functions
        private T List<T>(string endpoint, string rootName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var result = client.GetAsync($"{endpoint}").Result;
                using (var stream = result.Content.ReadAsStreamAsync().Result)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    string resultContent = result.Content.ReadAsStringAsync().Result;
                    using (XmlReader xmlReader = XmlReader.Create(stream))
                    {
                        if (xmlReader.MoveToContent() == XmlNodeType.Element)
                        {
                            var rootNodeName = xmlReader.Name;
                            if (rootNodeName == rootName)
                            {
                                stream.Seek(0, SeekOrigin.Begin);
                                return (T)serializer.Deserialize(stream);
                            }
                            else
                            {
                                return default(T);
                            }
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
        }
        private T List<T>(string endpoint, string query, string rootName)
        {
            if (string.IsNullOrEmpty(query))
            {
                return List<T>(endpoint, rootName);
            }
            else
            {
                return List<T>($"{endpoint}?{query}", rootName);
            }
        }
        private T Get<T>(string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var result = client.GetAsync($"{endpoint}").Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = result.Content.ReadAsStreamAsync().Result)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return (T)serializer.Deserialize(stream);
                    }
                }
                else
                {
                    return default(T);
                }
            }
        }
        private T Get<T>(string endpoint, string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Get<T>(endpoint);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseAddress;
                    var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var result = client.GetAsync($"{endpoint}?{query}").Result;
                    using (var stream = result.Content.ReadAsStreamAsync().Result)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return (T)serializer.Deserialize(stream);
                    }
                }
            }
        }
        #endregion
    }
}
