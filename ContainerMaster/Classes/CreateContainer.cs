using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CCR
{
    class CreateContainer
    {
        string connectionString = "Data Source=srv-swdb;Initial Catalog=swdb;Persist Security Info=True;User ID=swdb;Password=SouthWare99";
        List<Container> containerList = new List<Container>();
        DataTable cmDetailsTable = new DataTable();
        DataTable cmDataTable = new DataTable();
        public enum JoinType { Items, PO, POItems };
        JoinType joinType;

        public DataTable AddToDataTable(DataTable dt, int position = 0)
        {
            if (position == 0)
            {
                position = dt.Columns.Count;
            }

            if (dt.Columns.Contains("Item Number") && dt.Columns.Contains("PO Number"))
            {
                joinType = JoinType.POItems;
                GetContainerInfo();
                Create();
                foreach (Container container in containerList)
                {
                    dt.Columns.Add("\"Supplier: " + container.supplier + "\r\n" +
                                                "ETA: " + container.etaData + "\r\n" +
                                                "Shipped: " + container.shipped + "\r\n" +
                                                "Cartons: " + container.cartons + "\r\n" +
                                                "Delivery Mode: " + container.deliveryMode + "\r\n" +
                                                "Container number: " + container.containerNumber + "\"").SetOrdinal(position);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (container.contents.ContainsKey(row["Item Number"].ToString() + row["PO Number"].ToString()))
                        {
                            row[position] = container.contents[row["Item Number"].ToString() + row["PO Number"].ToString()];
                        }
                    }
                    position++;
                }
            }
            else if(dt.Columns.Contains("Item Number"))
            {
                joinType = JoinType.Items;
                GetContainerInfo();
                Create();
                foreach (Container container in containerList)
                {
                    dt.Columns.Add("\"Supplier: " + container.supplier + "\r\n" +
                                                "ETA: " + container.etaData + "\r\n" +
                                                "Shipped: " + container.shipped + "\r\n" +
                                                "Cartons: " + container.cartons + "\r\n" +
                                                "Delivery Mode: " + container.deliveryMode + "\r\n" +
                                                "Container number: " + container.containerNumber + "\"").SetOrdinal(position);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (container.contents.ContainsKey(row["Item Number"].ToString()))
                        {
                            row[dt.Columns.Count - 1] = container.contents[row["Item Number"].ToString()];
                        }                        
                    }
                    position++;
                }
            }
            else
            {
                throw new Exception("Requested data could not be bound to Container Master. Please Provide Item number, PO number or both");
            }

            

      
            return dt;
        }

        private void Create()
        {
            DataTable cmDetailsTable = new DataTable();
            if (joinType == JoinType.POItems)
            {
                cmDetailsTable = GetData.ExecuteQuery(@"select * from CM_Details where Delivered is null order by Supplier, ETADate", connectionString);
            }
            else if (joinType == JoinType.Items)
            {
                cmDetailsTable = GetData.ExecuteQuery(@"select * from CM_Details where Delivered is null order by ETADate", connectionString);
            }
            foreach (DataRow row in cmDetailsTable.Rows)
            {
                Container container = new Container();
                container.id = row["CMID"].ToString();
                container.supplier = row["Supplier"].ToString();
                container.etaData = Convert.ToDateTime(row["ETADate"]).ToString("d");
                container.shipped = Convert.ToDateTime(row["ShipDate"]).ToString("d");
                container.cartons = row["ContainerQty"].ToString();
                container.deliveryMode = row["ShipType"].ToString();
                container.containerNumber = row["ContainerNumber"].ToString();
                container.SetContainerColor();

                if (joinType == JoinType.Items)
                {
                    var containerDeets = from details in cmDataTable.AsEnumerable()
                                         where container.id == details.Field<string>("CMID")
                                         select new
                                         {
                                             ItemNumber = details.Field<string>("ItemNumber").ToString(),
                                             ItemQty = details.Field<double>("ItemQty")
                                         };

                    foreach(var details in containerDeets)
                    {
                        if(joinType == JoinType.Items)
                            container.contents.Add(details.ItemNumber, details.ItemQty);
                    }
                }

                if (joinType == JoinType.POItems)
                {
                    var containerDeets = from details in cmDataTable.AsEnumerable()
                                         where container.id == details.Field<string>("CMID")
                                         select new
                                         {
                                             ItemNumber = details.Field<string>("ItemNumber").ToString(),
                                             PONumber = details.Field<string>("PONumber").ToString(),
                                             ItemQty = details.Field<double>("ItemQty")
                                         };

                    foreach (var details in containerDeets)
                    {
                        if (joinType == JoinType.POItems)
                            container.contents.Add(details.ItemNumber + details.PONumber, details.ItemQty);
                    }
                }
                        

                containerList.Add(container);

            }
        }

        private void GetContainerInfo()
        {
            if (joinType == JoinType.Items  )
            {
                cmDataTable = GetData.ExecuteQuery(@"SELECT ItemNumber, sum(itemqty) as ItemQty, a.CMID 
                                                     FROM CM_Data a 
                                                     JOIN CM_Details b on a.CMID = b.CMID 
                                                     WHERE Delivered is null
                                                     group by ItemNumber, a.CMID", connectionString);
            }
            if (joinType == JoinType.POItems)
            {
                cmDataTable = GetData.ExecuteQuery(@"SELECT PONumber, ItemNumber, sum(ItemQty) as ItemQty, data.CMID 
                                                     FROM CM_Data data join CM_Details details on data.CMID = details.CMID 
                                                     WHERE Delivered is null group by ItemNumber, PONumber, data.CMID", connectionString);
            }
        }

        public List<Container> GetContainerList()
        {
            return containerList;
        }
    }


    class Container
    {
        public string id { get; set; }
        public string supplier { get; set; }
        public string etaData { get; set; }
        public string shipped { get; set; }
        public string cartons { get; set; }
        public string deliveryMode { get; set; }
        public string containerNumber { get; set; }
        public int[] RGBcolor = new int[3];

        public Dictionary<string, double> contents = new Dictionary<string, double>();

        public void SetContainerColor()
        {
            if (supplier == "Asian Art & Craft")
            {
                RGBcolor[0] = 242;
                RGBcolor[1] = 164;
                RGBcolor[2] = 209;
            }

            if (supplier == "Aurient")
            {
                RGBcolor[0] = 255;
                RGBcolor[1] = 255;
                RGBcolor[2] = 193;
            }
                
            if (supplier == "Banaras")
            {
                RGBcolor[0] = 177;
                RGBcolor[1] = 160;
                RGBcolor[2] = 199;
            }
            if (supplier == "Bestone")
            {
                RGBcolor[0] = 253;
                RGBcolor[1] = 233;
                RGBcolor[2] = 217;
            }
            if (supplier == "Chain Wit")
            {
                RGBcolor[0] = 197;
                RGBcolor[1] = 217;
                RGBcolor[2] = 241;
            }
            if (supplier == "Creative Craft")
            {
                RGBcolor[0] = 146;
                RGBcolor[1] = 205;
                RGBcolor[2] = 220;
            }
            if (supplier == "Kwan Hing")
            {
                RGBcolor[0] = 250;
                RGBcolor[1] = 191;
                RGBcolor[2] = 143;
            }
            if (supplier == "Ningbo")
            {
                RGBcolor[0] = 235;
                RGBcolor[1] = 241;
                RGBcolor[2] = 222;
            }
            if (supplier == "Samsom")
            {
                RGBcolor[0] = 218;
                RGBcolor[1] = 238;
                RGBcolor[2] = 243;
            }    
            if (supplier == "TMI")
            {
                RGBcolor[0] = 196;
                RGBcolor[1] = 189;
                RGBcolor[2] = 151;
            }
            if (supplier == "Yu Ming")
            {
                RGBcolor[0] = 141;
                RGBcolor[1] = 180;
                RGBcolor[2] = 226;
            }
            if (supplier == "Zhongyi")
            {
                RGBcolor[0] = 191;
                RGBcolor[1] = 211;
                RGBcolor[2] = 145;
            }
        }
    }
}
