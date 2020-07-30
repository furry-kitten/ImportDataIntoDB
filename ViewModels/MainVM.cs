using DevExpress.Mvvm;
using YamlDotNet.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Windows;
using YamlDotNet.Core;
using ImportTODBFromYML.Models;
using System.Xml.Serialization;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Office.CustomUI;
using System.Linq.Expressions;
using System.ComponentModel;
using DevExpress.Mvvm.Native;
using DocumentFormat.OpenXml.Presentation;
using System.Windows.Forms;

namespace ImportTODBFromYML.ViewModels
{
    class MainVM : BaseVM
    {
        private string path = string.Empty;

        public ICommand trydeserialize => new DelegateCommand(() =>
        {
            var allCategories = new List<Category>();
            var offers = new List<Offer>();
            var currencies = new List<Currency>();
            allCategories.AddRange(
                from cat in XDocument.Load(path).Descendants("category")
                where cat.Attribute("parentId") != null
                select new Category
                {
                    id = (byte)(int)cat.Attribute("id"),
                    parentId = (byte)(int)cat.Attribute("parentId"),
                    name = (string)cat.Value
                });
            allCategories.AddRange(
                from cat in XDocument.Load(path).Descendants("category")
                where cat.Attribute("parentId") == null
                select new Category
                {
                    id = (byte)(int)cat.Attribute("id"),
                    name = (string)cat.Value
                });

            currencies.AddRange(
                from cur in XDocument.Load(path).Descendants("currency")
                select new Currency
                {
                    id = (string)cur.Attribute("id"),
                    plus = (byte)(int)cur.Attribute("plus"),
                    rate = (byte)(int)cur.Attribute("rate")
                });

            offers.AddRange(
                from offer in XDocument.Load(path).Descendants("offer")
                select new Offer
                {
                    id = (int)offer.Attribute("id"),
                    bid = (int)offer.Attribute("bid"),
                    available = (bool)offer.Attribute("available"),
                    type = (string)offer.Attribute("type"),
                    product = GetProduct((string)offer.Attribute("type"), (int)offer.Attribute("id"), path)
                });

            var shop = from yshop in XDocument.Load(path).Descendants("shop")
                       select new Shop
                       {
                           company = (string)yshop.Element("company"),
                           local_delivery_cost = (ushort)(int)yshop.Element("local_delivery_cost"),
                           name = (string)yshop.Element("name"),
                           url = (string)yshop.Element("url"),
                           categories = allCategories,
                           currencies = currencies,
                           offers = offers
                       };

            SQLCommands.SendFullData(shop.First());

            using (var file = new FileStream("yaml.xml", FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shop));
                xmlSerializer.Serialize(file, shop.ToArray()[0]);
            }
        });
        public ICommand SearchFile => new DelegateCommand(() =>
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                path = fileDialog.FileName;
            }
        });

        private Product GetProduct(string name, int id, string path) 
        {
            switch (name)
            {
                case "vendor.model":
                    return vendor(path, id);
                case "book":
                    return book(path, id);
                case "audiobook":
                    return audioBook(path, id);
                case "artist.title":
                    return artistTitle(path, id);
                case "tour":
                    return tour(path, id);
                case "event-ticket":
                    return eventTicket(path, id);

                default: return null;
            }
        }
        [XmlInclude(typeof(VendorModel))]
        private VendorModel vendor(string path, int id)
        {
            var item = from pr in XDocument.Load(path).Descendants("offer")
                         where (int)pr.Attribute($"id") == id
                         select new VendorModel
                         {
                             categoryId = (int)pr.Element("categoryId"),
                             currencyId = (string)pr.Element("currencyId"),
                             desctription = (string)pr.Element("description"),
                             picture = (string)pr.Element("picture"),
                             price = (double)pr.Element("price"),
                             url = (string)pr.Element("url"),
                             country_of_origin = (string)pr.Element("country_of_origin"),
                             delivery = (bool)pr.Element("delivery"),
                             local_delivery_cost = (int)pr.Element("local_delivery_cost"),
                             manufacturer_warranty = (bool)pr.Element("manufacturer_warranty"),
                             model = (string)pr.Element("model"),
                             typePrefix = (string)pr.Element("typePrefix"),
                             vendor = (string)pr.Element("vendor"),
                             vendorCode = (string)pr.Element("vendorCode")
                         };
            return item.First();
        }
        [XmlInclude(typeof(Book))]
        private Book book(string path, int id)
        {
            var item = from el in XDocument.Load(path).Descendants("offer")
                       where (int)el.Attribute($"id") == id
                       select new Book
                       {
                           price = (double)el.Element("price"),
                           url = (string)el.Element("url"),
                           picture = (string)el.Element("picture"),
                           desctription = (string)el.Element("description"),
                           currencyId = (string)el.Element("currencyId"),
                           categoryId = (int)el.Element("categoryId"),
                           author = (string)el.Element("author"),
                           binding = (string)el.Element("binding"),
                           delivery = (bool)el.Element("delivery"),
                           downloadable = (bool)el.Element("downloadable"),
                           ISBN = (string)el.Element("ISBN"),
                           language = (string)el.Element("language"),
                           local_delivery_cost = (int)el.Element("local_delivery_cost"),
                           name = (string)el.Element("name"),
                           page_extent = (int)el.Element("page_extent"),
                           part = (int)el.Element("part"),
                           publisher = (string)el.Element("publisher"),
                           series = (string)el.Element("series"),
                           volume = (int)el.Element("volume"),
                           year = (int)el.Element("year"),
                       };
            return item.ToArray().First();
            /*
            return XDocument.Load(path).Element("offers").Elements("offer").Select(el => new Book
            {
                price = (double)el.Element("price"),
                url = (string)el.Element("url"),
                picture = (string)el.Element("picture"),
                desctription = (string)el.Element("desctription"),
                currencyId = (string)el.Element("currencyId"),
                categoryId = (int)el.Element("categoryId"),
                author = (string)el.Element("author"),
                binding = (string)el.Element("binding"),
                delivery = (bool)el.Element("delivery"),
                downloadable = (bool)el.Element("downloadable"),
                ISBN = (string)el.Element("ISBN"),
                language = (string)el.Element("language"),
                local_delivery_cost = (int)el.Element("local_delivery_cost"),
                name = (string)el.Element("name"),
                page_extent = (int)el.Element("page_extent"),
                part = (int)el.Element("part"),
                publisher = (string)el.Element("publisher"),
                series = (string)el.Element("series"),
                volume = (int)el.Element("volume"),
                year = (int)el.Element("year"),
            }).First();
            */
        }
        [XmlInclude(typeof(AudioBook))]
        private AudioBook audioBook(string path, int id)
        {
            var item = from el in XDocument.Load(path).Descendants("offer")
                       where (int)el.Attribute($"id") == id
                       select new AudioBook
                       {
                           price = (double)el.Element("price"),
                           url = (string)el.Element("url"),
                           picture = (string)el.Element("picture"),
                           desctription = (string)el.Element("description"),
                           currencyId = (string)el.Element("currencyId"),
                           categoryId = (int)el.Element("categoryId"),
                           author = (string)el.Element("author"),
                           format = (string)el.Element("format"),
                           performance_type = (string)el.Element("performance_type"),
                           downloadable = (bool)el.Element("downloadable"),
                           ISBN = (string)el.Element("ISBN"),
                           language = (string)el.Element("language"),
                           performed_by = (string)el.Element("performed_by"),
                           name = (string)el.Element("name"),
                           recording_length = (string)el.Element("recording_length"),
                           storage = (string)el.Element("storage"),
                           publisher = (string)el.Element("publisher"),
                           year = (int)el.Element("year"),
                       };
            return item.First();
        }
        [XmlInclude(typeof(ArtistTitle))]
        private ArtistTitle artistTitle(string path, int id)
        {
            var item = from pr in XDocument.Load(path).Descendants("offer")
                         where (int)pr.Attribute($"id") == id
                         select new ArtistTitle
                         {
                             categoryId = (int)pr.Element("categoryId"),
                             currencyId = (string)pr.Element("currencyId"),
                             desctription = (string)pr.Element("description"),
                             picture = (string)pr.Element("picture"),
                             price = (double)pr.Element("price"),
                             url = (string)pr.Element("url"),
                             artist = (string)pr.Element("artist"),
                             country = (string)pr.Element("country"),
                             director = (string)pr.Element("director"),
                             media = (string)pr.Element("media"),
                             originalName = (string)pr.Element("originalName"),
                             starring = (string)pr.Element("starring"),
                             title = (string)pr.Element("title"),
                             year = (int)pr.Element("year")
                         };
            return item.First();
        }
        [XmlInclude(typeof(Tour))]
        private Tour tour(string path, int id)
        {
            var item = from el in XDocument.Load(path).Descendants("offer")
                       where (int)el.Attribute($"id") == id
                       select new Tour
                       {
                           price = (double)el.Element("price"),
                           url = (string)el.Element("url"),
                           picture = (string)el.Element("picture"),
                           desctription = (string)el.Element("description"),
                           currencyId = (string)el.Element("currencyId"),
                           categoryId = (int)el.Element("categoryId"),
                           country = (string)el.Element("country"),
                           days = (int)el.Element("days"),
                           delivery = (bool)el.Element("delivery"),
                           edataTour = (string)el.Elements("dataTour").Last(),
                           hotel_stars = (string)el.Element("hotel_stars"),
                           included = (string)el.Element("included"),
                           local_delivery_cost = (int)el.Element("local_delivery_cost"),
                           name = (string)el.Element("name"),
                           meal = (string)el.Element("meal"),
                           region = (string)el.Element("region"),
                           room = (string)el.Element("room"),
                           sdataTour = (string)el.Elements("dataTour").First(),
                           transport = (string)el.Element("transport"),
                           worldRegion = (string)el.Element("worldRegion")
                       };
            return item.First();
        }
        [XmlInclude(typeof(event_ticket))]
        private event_ticket eventTicket(string path, int id)
        {
            var item = from pr in XDocument.Load(path).Descendants("offer")
                         where (int)pr.Attribute($"id") == id
                         select new event_ticket
                         {
                             categoryId = (int)pr.Element("categoryId"),
                             currencyId = (string)pr.Element("currencyId"),
                             desctription = (string)pr.Element("description"),
                             picture = (string)pr.Element("picture"),
                             price = (double)pr.Element("price"),
                             url = (string)pr.Element("url"),
                             date = (string)pr.Element("date"),
                             delivery = (bool)pr.Element("delivery"),
                             hall_part = (string)pr.Element("hall_part"),
                             is_kids = (int)pr.Element("is_kids"),
                             is_premiere = (int)pr.Element("is_premiere"),
                             local_delivery_cost = (int)pr.Element("local_delivery_cost"),
                             name = (string)pr.Element("name"),
                             plan = GetHall(id, path),
                             place = (string)pr.Element("place")
                         };
            return item.First();
        }
        [XmlInclude(typeof(Hall))]
        private Hall GetHall(int id, string path)
        {
            var item = from pr in XDocument.Load(path).Descendants("offer")
                       where (int)pr.Attribute("id") == id
                       select new Hall
                       {
                           plan = (string)pr.Element("hall").Attribute("plan"),
                           Name = (string)pr.Element("hall")
                       };

            return item.First();
        }
    }
}
