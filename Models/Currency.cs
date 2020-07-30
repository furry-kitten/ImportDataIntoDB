using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(Currency))]
    [SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Currency
    {
        [XmlAttributeAttribute]
        public string id { get; set; }
        [XmlAttributeAttribute]
        public int rate { get; set; }
        [XmlAttributeAttribute]
        public int plus { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class yml_catalogShopCurrencies
    {

        private yml_catalogShopCurrenciesCurrency currencyField;

        /// <remarks/>
        public yml_catalogShopCurrenciesCurrency currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class yml_catalogShopCurrenciesCurrency
    {

        private string idField;

        private byte rateField;

        private byte plusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte rate
        {
            get
            {
                return this.rateField;
            }
            set
            {
                this.rateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte plus
        {
            get
            {
                return this.plusField;
            }
            set
            {
                this.plusField = value;
            }
        }
    }
}
