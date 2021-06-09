using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependInjeUnity
{
    class BusinessLayer
    {
        private IProduct _product;
        public BusinessLayer(IProduct prodObj)
        {
            _product = prodObj;
        }

        public void Insert()
        {
            _product.InsertData();
        }
    }
}
