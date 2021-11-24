using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beslissingen
{
    class BMICalculator : IBMICalculator
    {
        private double _weight;
        private double _height;

        public BMICalculator(double height, double weight)
        {
            _weight = weight;
            _height = height;
        }

        public void setWeight(double weight)
        {
            _weight = weight;
        }

        public void setHeight(double height)
        {
            _height = height;
        }

        public double CalculateBMI()
        {
            return Math.Round((_weight / Math.Pow(_height, 2)), 2);
        }

        public BMIType GetBMIType()
        {
            double bmi = this.CalculateBMI();

            if (bmi < 18.5)
            {
                return BMIType.ONDERGEWICHT;
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                return BMIType.NORMAAL;
            }
            else if (bmi >= 25 && bmi < 30)
            {
                return BMIType.OVERGEWICHT;
            }
            else if (bmi >= 30 && bmi < 40)
            {
                return BMIType.ZWAARLIJVIGHEID;
            }
            else
            {
                return BMIType.ERNSTIGE_ZWAARLIJVIGHEID;
            }

        }

        #region IDisposable Implementation

        private bool _disposed;

        ~BMICalculator()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
            {
                if (disposing)
                {
                    // managed objects
                }

                _disposed = true;
            }
        }
        #endregion
    }
}
