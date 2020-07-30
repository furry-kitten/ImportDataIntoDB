using DevExpress.Mvvm.UI.Native;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportTODBFromYML.Models
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Shop
    {
        public int local_delivery_cost { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string url { get; set; }
        public List<Currency> currencies { get; set; }
        public List<Category> categories { get; set; }
        public List<Offer> offers { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class yml_catalogShop
    {

        private string nameField;

        private string companyField;

        private string urlField;

        private yml_catalogShopCurrencies currenciesField;

        private yml_catalogShopCategory[] categoriesField;

        private ushort local_delivery_costField;

        private yml_catalogShopOffer[] offersField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string company
        {
            get
            {
                return this.companyField;
            }
            set
            {
                this.companyField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public yml_catalogShopCurrencies currencies
        {
            get
            {
                return this.currenciesField;
            }
            set
            {
                this.currenciesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("category", IsNullable = false)]
        public yml_catalogShopCategory[] categories
        {
            get
            {
                return this.categoriesField;
            }
            set
            {
                this.categoriesField = value;
            }
        }

        /// <remarks/>
        public ushort local_delivery_cost
        {
            get
            {
                return this.local_delivery_costField;
            }
            set
            {
                this.local_delivery_costField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("offer", IsNullable = false)]
        public yml_catalogShopOffer[] offers
        {
            get
            {
                return this.offersField;
            }
            set
            {
                this.offersField = value;
            }
        }
    }
}
