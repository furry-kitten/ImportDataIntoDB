using DocumentFormat.OpenXml.Office.CustomUI;

using Microsoft.SqlServer.Server;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportTODBFromYML.Models
{
    public static class SQLCommands
    {
        private static string connectionString = "Data Source=DESKTOP-ELQ12AO;User ID=sa;Password=Tok_Vol583;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static DataTable SendProduct(Product product)
        {
            DataTable Table = new DataTable();

            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("Price", typeof(int));
            Table.Columns.Add("Url", typeof(string));
            Table.Columns.Add("Picture", typeof(string));
            Table.Columns.Add("Description", typeof(string));
            Table.Columns.Add("CurID", typeof(string));
            Table.Columns.Add("CatID", typeof(int));

            Table.Rows.Add(0, product.price, product.url, product.picture, product.desctription, product.currencyId, product.categoryId);

            return Table;
        }
        public static DataTable SendOffer(Offer offer)
        {
            DataTable Table = new DataTable();

            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("Bid", typeof(int));
            Table.Columns.Add("Cbid", typeof(int));
            Table.Columns.Add("Available", typeof(byte));

            var row = Table.NewRow();
            row["ID"] = offer.id;
            row["Bid"] = offer.bid;
            row["Cbid"] = offer.cbid;
            row["Available"] = offer.available;

            Table.Rows.Add(row);

            return Table;
        }
        public static DataTable SendCMI(Offer offer)
        {
            var table = new DataTable();
            table.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID", typeof(int)),
                new DataColumn("DownLoadable", typeof(byte)),
                new DataColumn("Auther", typeof(string)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Publicher", typeof(string)),
                new DataColumn("Language", typeof(string)),
                new DataColumn("Year", typeof(int)),
                new DataColumn("ISBN", typeof(string))
            });
            
            var row = table.NewRow();

            switch (offer.product)
            {
                case AudioBook audio:
                    row["DownLoadable"] = audio.downloadable;
                    row["Auther"] = audio.author;
                    row["Name"] = audio.name;
                    row["Publicher"] = audio.publisher;
                    row["Language"] = audio.language;
                    row["Year"] = audio.year;
                    row["ISBN"] = audio.ISBN;
                    break;
                case Book book:
                    row["DownLoadable"] = book.downloadable;
                    row["Auther"] = book.author;
                    row["Name"] = book.name;
                    row["Publicher"] = book.publisher;
                    row["Language"] = book.language;
                    row["Year"] = book.year;
                    row["ISBN"] = book.ISBN;
                    break;
                default: throw new Exception();
            };

            table.Rows.Add(row);

            return table;
        }

        public static DataTable SendVendor(Offer offer)
        {
            VendorModel vendor = offer.product as VendorModel;
            DataTable Table = new DataTable();

            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("ProductID", typeof(int));
            Table.Columns.Add("Delivery", typeof(byte));
            Table.Columns.Add("ManufacturerWarranty", typeof(byte));
            Table.Columns.Add("LocalDeliveryCost", typeof(int));
            Table.Columns.Add("TypePrefix", typeof(string));
            Table.Columns.Add("Vendor", typeof(string));
            Table.Columns.Add("VendorCode", typeof(string));
            Table.Columns.Add("Model", typeof(string));
            Table.Columns.Add("CountryOrigin", typeof(string));
            Table.Columns.Add("OfferID", typeof(int));

            var row = Table.NewRow();
            row["ProductID"] = 1;
            row["Delivery"] = vendor.delivery;
            row["ManufacturerWarranty"] = vendor.manufacturer_warranty;
            row["LocalDeliveryCost"] = vendor.local_delivery_cost;
            row["TypePrefix"] = vendor.typePrefix;
            row["Vendor"] = vendor.vendor;
            row["VendorCode"] = vendor.vendorCode;
            row["Model"] = vendor.model;
            row["CountryOrigin"] = vendor.country_of_origin;
            row["OfferID"] = offer.id;

            Table.Rows.Add(row);

            return Table;
        }
        public static DataTable SendBook(Offer offer)
        {
            var item = offer.product as Book;
            DataTable Table = new DataTable();

            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("ProductID", typeof(int));
            Table.Columns.Add("CMI", typeof(int));
            Table.Columns.Add("Delivery", typeof(int));
            Table.Columns.Add("Series", typeof(string));
            Table.Columns.Add("Binding", typeof(string));
            Table.Columns.Add("LocalDeliveryCost", typeof(int));
            Table.Columns.Add("Volume", typeof(int));
            Table.Columns.Add("Part", typeof(int));
            Table.Columns.Add("PageExtant", typeof(int));
            Table.Columns.Add("OfferID", typeof(int));

            var row = Table.NewRow();
            row["ProductID"] = 1;
            row["CMI"] = 0;
            row["Delivery"] = item.delivery;
            row["Series"] = item.series;
            row["Binding"] = item.binding;
            row["LocalDeliveryCost"] = item.local_delivery_cost;
            row["Volume"] = item.volume;
            row["Part"] = item.part;
            row["PageExtant"] = item.page_extent;
            row["OfferID"] = offer.id;

            Table.Rows.Add(row);

            return Table;
        }
        public static DataTable SendAudioBook(Offer offer)
        {
            AudioBook item = offer.product as AudioBook;
            DataTable Table = new DataTable();

            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("ProductID", typeof(int));
            Table.Columns.Add("CMI", typeof(int));
            Table.Columns.Add("PerformedBy", typeof(string));
            Table.Columns.Add("PerformanceType", typeof(string));
            Table.Columns.Add("Storage", typeof(string));
            Table.Columns.Add("Format", typeof(string));
            Table.Columns.Add("RecordingLenght", typeof(string));
            Table.Columns.Add("OfferID", typeof(int));

            var row = Table.NewRow();
            row["ProductID"] = 1;
            row["PerformedBy"] = item.performed_by;
            row["PerformanceType"] = item.performance_type;
            row["Storage"] = item.storage;
            row["Format"] = item.format;
            row["RecordingLenght"] = item.recording_length;
            row["OfferID"] = offer.id;

            Table.Rows.Add(row);

            return Table;
        }
        public static DataTable SendArtistTitle(Offer offer)
        {
            var vendor = offer.product as ArtistTitle;
            DataTable Table = new DataTable();

            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("ProductID", typeof(int));
            Table.Columns.Add("Artist", typeof(string));
            Table.Columns.Add("Title", typeof(string));
            Table.Columns.Add("Media", typeof(string));
            Table.Columns.Add("Year", typeof(string));
            Table.Columns.Add("Starring", typeof(string));
            Table.Columns.Add("Director", typeof(string));
            Table.Columns.Add("OriginalName", typeof(string));
            Table.Columns.Add("Country", typeof(string));
            Table.Columns.Add("OfferID", typeof(int));

            var row = Table.NewRow();
            row["ProductID"] = 1;
            row["Artist"] = vendor.artist;
            row["Title"] = vendor.title;
            row["Media"] = vendor.media;
            row["Year"] = vendor.year;
            row["Starring"] = vendor.starring;
            row["Director"] = vendor.director;
            row["OriginalName"] = vendor.originalName;
            row["Country"] = vendor.country;
            row["OfferID"] = offer.id;

            Table.Rows.Add(row);

            return Table;
        }
        public static DataTable SendTour(Offer offer)
        {
            Tour item = offer.product as Tour;
            DataTable Table = new DataTable();

            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("ProductID", typeof(int));
            Table.Columns.Add("Delivery", typeof(byte));
            Table.Columns.Add("LocalDeliveryCost", typeof(int));
            Table.Columns.Add("WorldRegion", typeof(string));
            Table.Columns.Add("Country", typeof(string));
            Table.Columns.Add("Region", typeof(string));
            Table.Columns.Add("Days", typeof(int));
            Table.Columns.Add("SDateTour", typeof(DateTime));
            Table.Columns.Add("EDateTour", typeof(DateTime));
            Table.Columns.Add("Name", typeof(string));
            Table.Columns.Add("HostelStars", typeof(string));
            Table.Columns.Add("Room", typeof(string));
            Table.Columns.Add("Meal", typeof(string));
            Table.Columns.Add("Included", typeof(string));
            Table.Columns.Add("Transport", typeof(string));
            Table.Columns.Add("OfferID", typeof(int));

            var row = Table.NewRow();
            row["ProductID"] = 1;
            row["Delivery"] = item.delivery;
            row["LocalDeliveryCost"] = item.local_delivery_cost;
            row["WorldRegion"] = item.worldRegion;
            row["Country"] = item.country;
            row["Region"] = item.region;
            row["Days"] = item.days;
            row["SDateTour"] = item.sdataTour;
            row["EDateTour"] = item.edataTour;
            row["Name"] = item.name;
            row["HostelStars"] = item.hotel_stars;
            row["Room"] = item.region;
            row["Meal"] = item.meal;
            row["Included"] = item.included;
            row["Transport"] = item.transport;
            row["OfferID"] = offer.id;

            Table.Rows.Add(row);

            return Table;
        }
        public static DataTable SendEventTicket(Offer offer)
        {
            var vendor = offer.product as event_ticket;
            DataTable Table = new DataTable();

            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("ProductID", typeof(int));
            Table.Columns.Add("DeliveryPublic", typeof(byte));
            Table.Columns.Add("LocalDeliveryCost", typeof(int));
            Table.Columns.Add("Name", typeof(string));
            Table.Columns.Add("Place", typeof(string));
            Table.Columns.Add("HallPlan", typeof(string));
            Table.Columns.Add("HallName", typeof(string));
            Table.Columns.Add("HallPart", typeof(string));
            Table.Columns.Add("Date", typeof(string));
            Table.Columns.Add("IsPremiere", typeof(string));
            Table.Columns.Add("IsKids", typeof(string));
            Table.Columns.Add("OfferID", typeof(int));

            var row = Table.NewRow();
            row["ProductID"] = 1;
            row["DeliveryPublic"] = vendor.delivery;
            row["LocalDeliveryCost"] = vendor.local_delivery_cost;
            row["Name"] = vendor.name;
            row["Place"] = vendor.place;
            row["HallPlan"] = vendor.plan.plan;
            row["HallName"] = vendor.plan.Name;
            row["HallPart"] = vendor.hall_part;
            row["Date"] = vendor.date;
            row["IsPremiere"] = vendor.is_premiere;
            row["IsKids"] = vendor.is_kids;
            row["OfferID"] = offer.id;

            Table.Rows.Add(row);

            return Table;
        }
        public static void SendFullData(Shop shop)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = null;
                SqlParameter parameter = new SqlParameter();

                //command.Parameters.AddRange(new SqlParameter[] { new SqlParameter { ParameterName = "userData" }, new SqlParameter { ParameterName = "product" }, new SqlParameter { ParameterName = "offer" } });

#if DEBUG
                connection.Open();

                foreach (var offer in shop.offers)
                {
                    switch(offer.product)
                    {
                        case VendorModel vendor:
                            command = new SqlCommand("TestBase.dbo.InsertIntoVendor", connection);
                            command.Parameters.AddWithValue("userData", SendVendor(offer));
                            command.Parameters["userData"].TypeName = "dbo.InsertVendor";
                            break;
                        case AudioBook audio:
                            command = new SqlCommand("TestBase.dbo.InsertIntoAudioBook", connection);
                            command.Parameters.AddWithValue("userData", SendAudioBook(offer));
                            command.Parameters["userData"].TypeName = "dbo.InsertAudioBook";
                            command.Parameters.AddWithValue("cmi", SendCMI(offer));
                            command.Parameters["cmi"].TypeName = "dbo.BookCommonPart";
                            break;
                        case Book book:
                            command = new SqlCommand("TestBase.dbo.InsertIntoBook", connection);
                            command.Parameters.AddWithValue("userData", SendBook(offer));
                            command.Parameters["userData"].TypeName = "dbo.InsertBook";
                            command.Parameters.AddWithValue("cmi", SendCMI(offer));
                            command.Parameters["cmi"].TypeName = "dbo.BookCommonPart";
                            break;
                        case event_ticket ticket:
                            command = new SqlCommand("TestBase.dbo.InsertIntoEventTicket", connection);
                            command.Parameters.AddWithValue("userData", SendEventTicket(offer));
                            command.Parameters["userData"].TypeName = "dbo.InsertEventTicket";
                            break;
                        case Tour tour:
                            command = new SqlCommand("TestBase.dbo.InsertIntoTour", connection);
                            command.Parameters.AddWithValue("userData", SendTour(offer));
                            command.Parameters["userData"].TypeName = "dbo.InsertTour";
                            break;
                        case ArtistTitle artist:
                            command = new SqlCommand("TestBase.dbo.InsertIntoArtistTitle", connection);
                            command.Parameters.AddWithValue("userData", SendArtistTitle(offer));
                            command.Parameters["userData"].TypeName = "dbo.InsertArtistTitle";
                            break;
                        default: throw new Exception();
                    }
                    /*
                    command.Parameters["userData"].Value =
                        offer.product is VendorModel ? SendVendor(offer) :
                        offer.product is AudioBook ? SendAudioBook(offer) :
                        offer.product is Book ? SendBook :
                        offer.product is 
                    command.Parameters["userData"].TypeName = "dbo.InsertVendor";
                    */

                    command.Parameters.AddWithValue("product", SendProduct(offer.product));
                    command.Parameters["product"].TypeName = "dbo.InsertProduct";

                    command.Parameters.AddWithValue("offer", SendOffer(offer));
                    command.Parameters["offer"].TypeName = "dbo.InsertOffer";

                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                }
#else
                connection.Open();

                command = new SqlCommand("TestBase.dbo.InsertIntoVendor", connection);
                command.Parameters.AddWithValue("userData", SendVendor(shop.offers[0]));
                command.Parameters["userData"].TypeName = "dbo.InsertVendor";

                command.Parameters.AddWithValue("@product", SendProduct(shop.offers[0].product));
                command.Parameters["@product"].TypeName = "dbo.InsertProduct";

                command.Parameters.AddWithValue("@offer", SendOffer(shop.offers[0]));
                command.Parameters["@offer"].TypeName = "dbo.InsertOffer";
#endif
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Dispose();
            }
        }
    }
}
