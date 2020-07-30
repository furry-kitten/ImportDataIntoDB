using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(Tour))]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Tour : Product
    {
        private string sDate;
        private string eDate;

        public bool delivery { get; set; }
        public int local_delivery_cost { get; set; }
        public string worldRegion { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public int days { get; set; }
        public string sdataTour
        {
            get => sDate;
            set { sDate = value; }
        }
        public string edataTour
        {
            get => eDate;
            set { eDate = value; }
        }
        public string name { get; set; }
        public string hotel_stars { get; set; }
        public string room { get; set; }
        public string meal { get; set; }
        public string included { get; set; }
        public string transport { get; set; }
    }
}

[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType
{
    ISBN,
    artist,
    author,
    binding,
    categoryId,
    country,
    country_of_origin,
    currencyId,
    dataTour,
    date,
    days,
    delivery,
    description,
    director,
    downloadable,
    format,
    hall,
    hall_part,
    hotel_stars,
    included,
    is_kids,
    is_premiere,
    language,
    local_delivery_cost,
    manufacturer_warranty,
    meal,
    media,
    model,
    name,
    originalName,
    page_extent,
    part,
    performance_type,
    performed_by,
    picture,
    place,
    price,
    publisher,
    recording_length,
    region,
    room,
    series,
    starring,
    storage,
    title,
    transport,
    typePrefix,
    url,
    vendor,
    vendorCode,
    volume,
    worldRegion,
    year,
}

