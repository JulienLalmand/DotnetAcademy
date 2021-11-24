using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GewichtInSpace
{
    interface IPlanetWeightCalculator
    {
        /// <summary>
        /// Returns a list of all known planets.
        /// </summary>
        /// <returns></returns>
        List<string> GetCurrentlyKnownPlanets();

        /// <summary>
        /// Attempts to calculate the given weight in KG (Kilogram) on a specified planet.
        /// </summary>
        /// <param name="planetName">The name of the planet.</param>
        /// <param name="weight">The weight in KG to calculate.</param>
        /// <param name="result">The variable in which the result should be put into.</param>
        /// <returns>True if the calculation succeeded, false otherwise.</returns>
        bool TryCalculate(string planetName, double weight, out double result);

        /// <summary>
        /// Attempts to calculate the given weight using all known planets.
        /// </summary>
        /// <param name="weight">The weight in KG to calculate.</param>
        /// <param name="sortResult">Weither or not the result should be sorted. Defaults to false.</param>
        /// <param name="result">The variable in which the result should be put into.</param>
        /// <returns>True if the calculation succeeded, false otherwise.</returns>
        bool TryCalculateAll(double weight, out Dictionary<string, double> result, bool sortResult = false);
    }
}
