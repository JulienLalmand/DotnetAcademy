using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GewichtInSpace
{
    public class PlanetWeightCalculator : IPlanetWeightCalculator
    {

        private IDictionary<string, double> _planets;
        
        public PlanetWeightCalculator(Dictionary<string, double> Planets)
        {
            _planets = Planets;
        }

        public List<string> GetCurrentlyKnownPlanets()
        {
            return _planets.Keys.ToList();
        }

        public bool TryCalculate(string planetName, double weight, out double result)
        {
            try
            {
                result = 0;
                
                double requestedPlanetWeight;
                if (!_planets.TryGetValue(planetName, out requestedPlanetWeight))
                {
                    return false;
                }

                result = requestedPlanetWeight * weight;

                return true;

            }
            catch(Exception)
            {
                result = 0;
                return false;
            }
        }

        public bool TryCalculateAll(double weight, out Dictionary<string, double> result, bool sortResult = false)
        {
            try
            {
                Dictionary<string, double> toReturn = new Dictionary<string, double>();

                foreach(KeyValuePair<string, double> planets in _planets)
                {
                    double calculationResult = 0;
                    if(this.TryCalculate(planets.Key, weight, out calculationResult))
                    {
                        toReturn.Add(planets.Key, calculationResult);
                    }
                }

                if (sortResult)
                {
                    toReturn = toReturn.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                }            

                result = toReturn;
                return true;
            }
            catch(Exception)
            {
                result = null;
                return false;
            }
        }
    }
}
