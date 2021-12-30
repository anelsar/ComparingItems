using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services
{
    public interface IRandomValueGenerate
    {
         List<int> GenerateValues(int lowerLimit, int uperLimit);
    }
}
