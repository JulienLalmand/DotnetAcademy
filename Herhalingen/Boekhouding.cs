using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhalingen
{
    class Boekhouding
    {
        List<double> _getallen;

        public Boekhouding()
        {
            _getallen = new List<double>();
        }

        public void Add(double getal)
        {
            _getallen.Add(getal);
        }

        public double GetSum()
        {
            return _getallen.Sum();
        }

        public double GetSumOfNegatives()
        {
            return _getallen.Where(g => g < 0).Sum();
        }

        public double GetSumOfPositives()
        {
            return _getallen.Where(g => g > 0).Sum();
        }

        public double GetAverage()
        {
            return Math.Round(_getallen.Average(), 2);
        }
    }
}
