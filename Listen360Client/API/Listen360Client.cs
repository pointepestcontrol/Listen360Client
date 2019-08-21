using Listen360Client.Model.Xml;
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
        public IEnumerable<Model.Organization> GetOrganizations()
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
                        foreach (var org in orgs.Organizations)
                        {
                            yield return new Model.Organization(org);
                        }
                        currentPage++;
                    }
                }
            }
            while (itemCount != 100 && itemCount != 0);
        }
        public IEnumerable<Model.Child> GetChildren(Model.Organization parent)
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

                    var result = client.GetAsync($"/organizations/{parent.Id}/children.xml?page={currentPage}").Result;
                    using (var stream = result.Content.ReadAsStreamAsync().Result)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ChildrenCollection));
                        // resultContent = result.Content.ReadAsStringAsync().Result;
                        var orgs = (ChildrenCollection)serializer.Deserialize(stream);
                        itemCount = orgs.Children.Count;
                        foreach (Child org in orgs.Children)
                        {
                            yield return new Model.Child(org);
                        }
                        currentPage++;
                    }
                }
            }
            while (itemCount != 100 && itemCount != 0);
        }
        public IEnumerable<Model.Descendent> GetDescendents(Model.Organization parent)
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

                    var result = client.GetAsync($"/organizations/{parent.Id}/descendents.xml?page={currentPage}").Result;
                    using (var stream = result.Content.ReadAsStreamAsync().Result)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(DescendentCollection));
                        // resultContent = result.Content.ReadAsStringAsync().Result;
                        var orgs = (DescendentCollection)serializer.Deserialize(stream);
                        itemCount = orgs.Descendents.Count;
                        foreach (var org in orgs.Descendents)
                        {
                            yield return new Model.Descendent(org);
                        }
                        currentPage++;
                    }
                }
            }
            while (itemCount != 100 && itemCount != 0);
        }
        internal Organization Get<T>(long orgId)
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
        public Model.Organization Get(Model.Organization org)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{ApiKey}:x");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var result = client.GetAsync($"/organizations/{org.Id}.xml").Result;
                using (var stream = result.Content.ReadAsStreamAsync().Result)
                {
                    XmlSerializer serializer;
                    Model.Organization returnVal;
                    switch (org.Type)
                    {
                        case Model.OrganizationType.Division:
                            serializer = new XmlSerializer(typeof(Division));
                            returnVal = new Model.Division((Division)serializer.Deserialize(stream));
                            break;
                        case Model.OrganizationType.Franchise:
                            serializer = new XmlSerializer(typeof(Franchise));
                            returnVal = new Model.Franchise((Franchise)serializer.Deserialize(stream));
                            break;
                        case Model.OrganizationType.Franchisor:
                            serializer = new XmlSerializer(typeof(Franchisor));
                            returnVal = new Model.Franchisor((Franchisor)serializer.Deserialize(stream));
                            break;
                        default:
                            throw new NotImplementedException($"The Entity {org.Type} is not supported");
                    }

                    // resultContent = result.Content.ReadAsStringAsync().Result;
                    return returnVal;
                }
            }
        }
        #endregion
        #region Customers
        public Model.Customer GetCustomer(Model.Customer c)
        {
            return GetCustomer(c.OrganizationId, c.Id);
        }

        public Model.Customer GetCustomer(long orgID, long customerID)
        {
            return new Model.Customer(Get<Customer>($"/organizations/{orgID}/customers/{customerID}.xml"));
        }

        public IEnumerable<Model.Customer> GetCustomers(long orgId, DateTime? updatedBefore = null, DateTime? updatedAfter = null, UInt32 startPage = 1)
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
                        yield return new Model.Customer(customer);
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
        public Model.Job GetJob(Model.Organization org, Model.Job job)
        {
            return GetJob(org.Id, job.Id);
        }
        public Model.Job GetJob(long orgId, Model.Job job)
        {
            return GetJob(orgId, job.Id);
        }
        public Model.Job GetJob(Model.Organization org, long jobId)
        {
            return GetJob(org.Id, jobId);
        }
        public Model.Job GetJob(long orgId, long jobId)
        {
            return new Model.Job(Get<Job>($"/organizations/{orgId}/jobs/{jobId}.xml"));
        }
        public IEnumerable<Model.Job> GetJobs(long orgId, DateTime? updatedBefore = null, DateTime? updatedAfter = null, UInt32 startPage = 1)
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
                        yield return new Model.Job(job);
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
        #region Technicians
        public Model.Technician GetTechnician(Model.Organization org, Model.Technician tech)
        {
            return GetTechnician(org.Id, tech.Id);
        }

        public Model.Technician GetTechnician(long orgId, Model.Technician tech)
        {
            return GetTechnician(orgId, tech.Id);
        }
        public Model.Technician GetTechnician(Model.Organization org, long techId)
        {
            return GetTechnician(org.Id, techId);
        }
        public Model.Technician GetTechnician(long orgId, long techId)
        {
            return new Model.Technician(Get<Technician>($"/organizations/{orgId}/technicians/{techId}.xml"));
        }
        public IEnumerable<Model.Technician> GetTechnicians(long orgId, UInt32 startPage = 1)
        {
            var currentPage = startPage;
            int itemCount = 0;
            do
            {
                var technicians = List<TechnicianCollection>($"/organizations/{orgId}/technicians.xml", $"page={currentPage}", "technician");
                if (technicians != null)
                {
                    itemCount = technicians.Technicians.Count;
                    foreach (Technician tech in technicians?.Technicians)
                    {
                        yield return new Model.Technician(tech);
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
