using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCharacteristicsForCategory.Infrastrucutre
{
    public interface ISessionManager
    {
        List<string> Characteristics { get; }

        void Add(string characteristic);
        void Remove(int indice);
        void ResetCharacteristics();
    }
}
