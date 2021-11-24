using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beslissingen
{
    interface IBMICalculator : IDisposable
    {
        /// <summary>
        /// Calculates a person's BMI.
        /// </summary>
        /// <returns>The body mass index.</returns>
        double CalculateBMI();

        /// <summary>
        /// Determines the category of this BMI.
        /// </summary>
        /// <returns>The category as Enum.</returns>
        BMIType GetBMIType();
    }
}
