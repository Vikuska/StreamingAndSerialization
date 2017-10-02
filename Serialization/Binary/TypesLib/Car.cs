using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesLib
{
    [Serializable]
    public class Car : Automobile
    {
        public bool IsHatchBack;

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        //public decimal Price { get; set; }  // do not use automatic props
    }
}
