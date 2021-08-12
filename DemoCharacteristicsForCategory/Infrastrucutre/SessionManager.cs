using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoCharacteristicsForCategory.Infrastrucutre
{
    public class SessionManager : ISessionManager
    {
        private readonly ISession _session;

        public List<string> Characteristics
        {
            get
            {
                return (!_session.Keys.Contains(nameof(Characteristics))) ? null : new List<string>(JsonSerializer.Deserialize<string[]>(_session.GetString(nameof(Characteristics))));
            }
            private set
            {
                _session.SetString(nameof(Characteristics), JsonSerializer.Serialize(value));
            }
        }

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public void Add(string characteristic)
        {
            List<string> characteristics = Characteristics ?? new List<string>();
            characteristics.Add(characteristic);
            Characteristics = characteristics;
        }

        public void Remove(int indice)
        {
            List<string> characteristics = Characteristics;

            if (characteristics is null || characteristics.Count() < indice)
                return;

            characteristics.RemoveAt(indice);
            Characteristics = characteristics;
        }

        public void ResetCharacteristics()
        {
            _session.Remove(nameof(Characteristics));
        }
    }
}
