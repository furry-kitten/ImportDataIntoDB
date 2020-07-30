using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(Offer))]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Offer
    {
        //[System.Xml.Serialization.XmlTextAttribute()]
        public Product product { get; set; }
        [XmlAttributeAttribute]
        public string type { get; set; }
        //public T item;
        [XmlAttributeAttribute]
        public int id { get; set; }
        [XmlAttributeAttribute]
        public int bid { get; set; }
        [XmlAttributeAttribute]
        public int cbid { get; set; }
        [XmlAttributeAttribute]
        public bool available { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class yml_catalogShopOffer
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        private ushort idField;

        private string typeField;

        private byte bidField;

        private byte cbidField;

        private bool cbidFieldSpecified;

        private bool availableField;

        /// <remarks/>
        [XmlElementAttribute("ISBN", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("artist", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("author", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("binding", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("categoryId", typeof(yml_catalogShopOfferCategoryId))]
        [System.Xml.Serialization.XmlElementAttribute("country", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("country_of_origin", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("currencyId", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("dataTour", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("date", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("days", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("delivery", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("description", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("director", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("downloadable", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("format", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("hall", typeof(yml_catalogShopOfferHall))]
        [System.Xml.Serialization.XmlElementAttribute("hall_part", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("hotel_stars", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("included", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("is_kids", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("is_premiere", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("language", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("local_delivery_cost", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("manufacturer_warranty", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("meal", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("media", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("model", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("originalName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("page_extent", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("part", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("performance_type", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("performed_by", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("picture", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("place", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("price", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("publisher", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("recording_length", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("region", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("room", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("series", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("starring", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("storage", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("title", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("transport", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("typePrefix", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("url", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("vendor", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("vendorCode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("volume", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("worldRegion", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("year", typeof(ushort))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort id
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
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte bid
        {
            get
            {
                return this.bidField;
            }
            set
            {
                this.bidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte cbid
        {
            get
            {
                return this.cbidField;
            }
            set
            {
                this.cbidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool cbidSpecified
        {
            get
            {
                return this.cbidFieldSpecified;
            }
            set
            {
                this.cbidFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool available
        {
            get
            {
                return this.availableField;
            }
            set
            {
                this.availableField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class yml_catalogShopOfferHall
    {

        private string planField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string plan
        {
            get
            {
                return this.planField;
            }
            set
            {
                this.planField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}
