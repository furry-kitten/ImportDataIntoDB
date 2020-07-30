using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(VendorModel))]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class VendorModel : Product
    {
        public bool delivery;
        public bool manufacturer_warranty;
        public int local_delivery_cost;
        public string typePrefix;
        public string vendor;
        public string vendorCode;
        public string model;
        public string country_of_origin;
    }
}
