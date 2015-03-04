using QCMS.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestGoodsDataInsert
{
    public partial class GoodsDataImport : System.Web.UI.Page
    {
        DatabaseHelper olddb = new DatabaseHelper("Uni2uni_GoodsInfo");
        DatabaseHelper newdb = new DatabaseHelper("Uni2uni_GoodsInfo1");
        StringBuilder errorResult = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData.DataSource = GetOnlineDatabaseCollectionInfoImportData();
            BindData.DataBind();
            
           // InsertSingGoods(20000002943);

           // InsertGoodsProperty(20000001681);

            //Response.Write(errorResult.ToString());
        }

        


        public bool InsertGoodsProperty(long GoodCode)
        {
            DataRow goodsRow = GetSingGoods(GoodCode);
            if (goodsRow == null)
            {
                errorResult.Append(GoodCode + "商品不存在</br>");
                return false;
            }

            string goodsID = goodsRow["GoodsID"].ToString();
            string productID = goodsRow["ProductsID"].ToString();
            DataRow productRow = GetGoodsToProduct(productID);
            if (productRow == null)
            {
                errorResult.Append(GoodCode + "无产品信息</br>");
                return false;
            }

            string brandID = productRow["BrandID"].ToString();
            string productCategoryID = productRow["ProductCategoryID"].ToString();

            int num=CheckNewDatabaseProductCategoryRelProperty(productCategoryID);
            if (num > 0)
            {
                errorResult.Append(GoodCode + "正式库商品属性中已创建，请手动创建商品关联</br>");
                return false;
            }

            return false;

            DataTable dt1 = GetProductCategoryRelProperty(productCategoryID);
            StringBuilder productCategoryRelPropertySQL = new StringBuilder();
            StringBuilder ProductPropertyKeyworkSQL = new StringBuilder();
            StringBuilder GoodsPropertyValuesSQL = new StringBuilder();

            foreach (DataRow dr1 in dt1.Rows)
            {
                string ProductCategoryRelPropertyID = dr1["ProductCategoryRelPropertyID"].ToString();
                //DataRow isExits= CheckProductCategoryRelProperty(ProductCategoryRelPropertyID);
                //if (isExits == null)
                //{
                    productCategoryRelPropertySQL.Append(GetProductCategoryRelPropertySQL(dr1));
                //}
                DataTable dt2 = GetGM_ProductPropertyKeywork(ProductCategoryRelPropertyID);               
                foreach (DataRow dr2 in dt2.Rows)
                {

                    //int pnumber = CheckProductPropertyKeywork(dr2["ProductPropertyKeyworkID"].ToString());
                    //if (pnumber == 0)
                    //{
                        ProductPropertyKeyworkSQL.Append(GetProductPropertyKeyworkSQL(dr2, ProductCategoryRelPropertyID));
                    //}

                }
            }

           
            DataTable dt3 = GetGoodsPropertyValues(goodsID);
            foreach (DataRow dr3 in dt3.Rows)
            {
                string ProductPropertyValuesID = dr3["ProductPropertyValuesID"].ToString();
                //int isExit = CheckGoodsPropertyValues(ProductPropertyValuesID);
                //if (isExit == 0)
                //{
                    GoodsPropertyValuesSQL.Append(GetGoodsPropertyValuesSQL(dr3));
                //}
                
            }

            IDictionary<string,IList<DbParameter>> dic=new Dictionary<string,IList<DbParameter>>();
            string sql1=productCategoryRelPropertySQL.ToString();
            if (!string.IsNullOrWhiteSpace(sql1))
            {
                dic.Add(productCategoryRelPropertySQL.ToString(), null);
            }

            string sql2 = ProductPropertyKeyworkSQL.ToString();
            if (!string.IsNullOrWhiteSpace(sql2))
            {
                dic.Add(sql2, null);
            }

            string sql3 = GoodsPropertyValuesSQL.ToString();
            if (!string.IsNullOrWhiteSpace(sql2))
            {
                dic.Add(sql3, null);
            }
           
            string result = string.Empty;
            if (dic.Count > 0)
            {
                bool bol = newdb.ExecuteTransation(dic, CommandType.Text);
                if (bol)
                {
                    errorResult.Append(GoodCode + "商品关联信息导入成功</br>");
                }
            }
            return true;
        }

        public string GetProductCategoryRelPropertySQL(DataRow dr)
        {
            string sql = string.Format(@"
IF NOT EXISTS(SELECT * FROM GM_ProductCategoryRelProperty WHERE ProductCategoryRelPropertyID='{0}')
                INSERT INTO dbo.GM_ProductCategoryRelProperty
                ( ProductCategoryRelPropertyID , ProductCategoryID ,ProductPropertysID ,PropertySort ,
                  PropertyType , PropertyUnit ,PropertyValueType ,SystemKeyWork ,IsSearch
                )
            VALUES  ( '{0}' , -- ProductCategoryRelPropertyID - uniqueidentifier
                  '{1}' , -- ProductCategoryID - uniqueidentifier
                  '{2}' , -- ProductPropertysID - uniqueidentifier
                  {3} , -- PropertySort - int
                  {4} , -- PropertyType - int
                  '{5}' , -- PropertyUnit - nvarchar(10)
                  {6} , -- PropertyValueType - bit
                  '{7}' , -- SystemKeyWork - varchar(100)
                  {8}  -- IsSearch - int
                )",
                dr["ProductCategoryRelPropertyID"].ToString(),
                dr["ProductCategoryID"].ToString(),
                dr["ProductPropertysID"].ToString(),
                Convert.ToInt32(dr["PropertySort"]),
                Convert.ToInt32(dr["PropertyType"]),
                dr["PropertyUnit"].ToString(),
                Convert.ToBoolean(dr["PropertyValueType"])==true?1:0,
                dr["SystemKeyWork"].ToString(),
                Convert.ToInt32(dr["IsSearch"]));
            return sql;
        }

        public string GetProductPropertyKeyworkSQL(DataRow dr, string ProductCategoryRelPropertyID)
        {
            string sql = string.Format(@"IF NOT EXISTS(SELECT * FROM GM_ProductPropertyKeywork WHERE ProductPropertyKeyworkID='{0}')
                    INSERT INTO dbo.GM_ProductPropertyKeywork
                    ( ProductPropertyKeyworkID ,
                      ProductCategoryRelPropertyID ,
                      ProValue ,
                      ProValueLevel ,
                      ProValueDescribe ,
                      CreateBy ,
                      CreateTime ,
                      UpdateBy ,
                      UpdateTime ,                 
                      isValid
                    )
            VALUES  ( '{0}' , -- ProductPropertyKeyworkID - uniqueidentifier
                      '{1}' , -- ProductCategoryRelPropertyID - uniqueidentifier
                      '{2}' , -- ProValue - varchar(100)
                      {3}, -- ProValueLevel - int
                      '{4}' , -- ProValueDescribe - nvarchar(500)
                      '{5}' , -- CreateBy - uniqueidentifier
                      '{6}' , -- CreateTime - datetime
                      '{7}' , -- UpdateBy - uniqueidentifier
                      '{8}' , -- UpdateTime - datetime                    
                      {9}  -- isValid - bit
                    )",
                       dr["ProductPropertyKeyworkID"].ToString(),
                       ProductCategoryRelPropertyID,
                       dr["ProValue"].ToString(),
                       Convert.ToInt32(dr["ProValueLevel"]),
                       dr["ProValueDescribe"],
                       dr["CreateBy"].ToString(),
                       dr["CreateTime"].ToString(),
                       dr["UpdateBy"].ToString(),
                       dr["UpdateTime"].ToString(),
                       Convert.ToBoolean(dr["isValid"]) == true ? 1 : 0
                      );
            return sql;
        }

        public string GetGoodsPropertyValuesSQL(DataRow dr)
        {
            string sql = string.Format(@"
IF NOT EXISTS(SELECT * FROM dbo.GM_ProductPropertyValues WHERE ProductPropertyValuesID='{0}')
                INSERT INTO dbo.GM_ProductPropertyValues
                ( ProductPropertyValuesID ,GoodID ,ProductCategoryRelPropertyID ,ProductPropertyKeyworkID ,
                  GoodPropertiyName , GoodPropertiyValue ,GoodPropertiyAttachDes ,
                  CreateBy ,CreateTime ,UpdateBy ,UpdateTime ,isValid
                )
        VALUES  ( '{0}' , -- ProductPropertyValuesID - uniqueidentifier
                  '{1}' , -- GoodID - uniqueidentifier
                  '{2}' , -- ProductCategoryRelPropertyID - uniqueidentifier
                  '{3}' , -- ProductPropertyKeyworkID - uniqueidentifier
                  '{4}' , -- GoodPropertiyName - varchar(100)
                  '{5}' , -- GoodPropertiyValue - varchar(100)
                  '{6}' , -- GoodPropertiyAttachDes - text
                  '{7}' , -- CreateBy - uniqueidentifier
                  '{8}' , -- CreateTime - datetime
                  '{9}' , -- UpdateBy - uniqueidentifier
                  '{10}' , -- UpdateTime - datetime
                  {11}  -- isValid - bit
                )",
                  dr["ProductPropertyValuesID"].ToString(),
                  dr["GoodID"].ToString(),
                  dr["ProductCategoryRelPropertyID"].ToString(),
                  dr["ProductPropertyKeyworkID"].ToString(),
                  dr["GoodPropertiyName"].ToString(),
                  dr["GoodPropertiyValue"].ToString(),
                  dr["GoodPropertiyAttachDes"].ToString(),
                  dr["CreateBy"].ToString(),
                  dr["CreateTime"].ToString(),
                  dr["UpdateBy"].ToString(),
                  dr["UpdateTime"].ToString(),
                  Convert.ToBoolean(dr["isValid"]) == true ? 1 : 0
                 );
            return sql;
        }


        public bool InsertSingGoods(long GoodCode)
        {
            DataRow goodsRow = GetSingGoods(GoodCode);
            if (goodsRow == null)
            {
                Response.Write(GoodCode + "商品不存在！==");
                Response.End();
            }

            string goodsID = goodsRow["GoodsID"].ToString();
            string productID = goodsRow["ProductsID"].ToString();
            DataTable imgTable = GetGoodsImages(goodsID);
            if (imgTable == null)
            {
                Response.Write(GoodCode + "无商品图片==");
                Response.End();
            }
            DataRow productRow = GetGoodsToProduct(productID);
            if (productRow == null)
            {
                Response.Write(GoodCode + "无产品信息");
                Response.End();
            }

            string brandID = productRow["BrandID"].ToString();
            string productCategoryID = productRow["ProductCategoryID"].ToString();

            DataTable goodsPropertyValueTable = GetGoodsPropertyValues(goodsID);


            DataRow newProductToBandRow = GetNewProductToBand(brandID);
            if (newProductToBandRow == null)//如果正式库中没有此品牌则从测试库中导入
            {
                DataRow oldProductToBandRow = GetOldProductToBand(brandID);

                DataRow CategoryRelBrandRow = GetCategoryRelBrand(productCategoryID, brandID);
            }

            DataTable productCategoryRelPropertyTable = GetProductCategoryRelProperty(productCategoryID);
            if (productCategoryRelPropertyTable == null)
            {
                Response.Write(GoodCode + "无产品分类属性关系信息");
                Response.End();
            }

            foreach (DataRow dr in productCategoryRelPropertyTable.Rows)
            {
                string ProductCategoryRelPropertyID = dr["ProductCategoryRelPropertyID"].ToString();
                DataTable productPropertyKeyworkTable = GetGM_ProductPropertyKeywork(ProductCategoryRelPropertyID);
            }
            return true;
        }

        //获得商品
        public DataRow GetSingGoods(long GoodCode)
        {
            string sql = "select * from GM_Goods where GoodCode=" + GoodCode;
            DataTable goodsTable = newdb.GetDataTable(sql, CommandType.Text, null);
            if (goodsTable.Rows.Count == 0)
                return null;
            else
                return goodsTable.Rows[0];
        }

        //获得商品图片
        public DataTable GetGoodsImages(string GoodsID)
        {
            string sql = "SELECT * FROM dbo.GM_Images WHERE GoodsID='" + GoodsID + "'";
            DataTable dt = olddb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt;
        }

        //获得商品所属产品
        public DataRow GetGoodsToProduct(string ProductsID)
        {
            string sql = "SELECT * FROM dbo.GM_Products WHERE ProductsID='" + ProductsID + "'";
            DataTable dt = newdb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0];
        }

        //获得商品属性参数值
        public DataTable GetGoodsPropertyValues(string GoodsID)
        {
            string sql = "SELECT * FROM GM_ProductPropertyValues WHERE GoodID='" + GoodsID + "'";
            DataTable dt = olddb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt;
        }
        //获取老商品库中产品所属品牌
        public DataRow GetOldProductToBand(string BandID)
        {
            string sql = "SELECT * FROM dbo.GM_Brand WHERE BrandID='" + BandID + "'";
            DataTable dt = olddb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0];
        }
        //获取正式库中产品所属品牌
        public DataRow GetNewProductToBand(string BandID)
        {
            string sql = "SELECT * FROM dbo.GM_Brand WHERE BrandID='" + BandID + "'";
            DataTable dt = olddb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0];
        }

        //获取分类与品牌关系信息
        public DataRow GetCategoryRelBrand(string ProductCategoryID, string BrandID)
        {
            string sql = "SELECT * FROM GM_CategoryRelBrand WHERE ProductCategoryID='" + ProductCategoryID + "' AND BrandID='" + BrandID + "'";
            DataTable dt = olddb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0];
        }

        //获取产品分类属性关系信息
        public DataTable GetProductCategoryRelProperty(string ProductCategoryID)
        {
            string sql = "SELECT * FROM dbo.GM_ProductCategoryRelProperty WHERE ProductCategoryID='" + ProductCategoryID + "'";
            DataTable dt = olddb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt;
        }

        //获取产品分类属性关系值
        public DataTable GetGM_ProductPropertyKeywork(string ProductCategoryRelPropertyID)
        {
            string sql = "SELECT * FROM dbo.GM_ProductPropertyKeywork WHERE ProductCategoryRelPropertyID='" + ProductCategoryRelPropertyID + "'";
            DataTable dt = olddb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt;
        }

        //判断正式库中是否已存在此属性关联;
        public DataRow CheckProductCategoryRelProperty(string ProductCategoryRelPropertyID)
        {
            string sql = "SELECT * FROM GM_ProductCategoryRelProperty WHERE ProductCategoryRelPropertyID='" + ProductCategoryRelPropertyID + "'";
            DataTable dt = newdb.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0];
        }

        //判断商品属性是否存在
        public int CheckGoodsPropertyValues(string ProductPropertyValuesID)
        {
            string sql = "SELECT count(*) FROM dbo.GM_ProductPropertyValues WHERE ProductPropertyValuesID='" + ProductPropertyValuesID + "';";
           object obj= newdb.GetScalar(sql, CommandType.Text, null);
           return Convert.ToInt32(obj);
        }
        //判断属性值是否存在
        public int CheckProductPropertyKeywork(string ProductPropertyKeyworkID)
        {
            string sql = "SELECT count(*) FROM GM_ProductPropertyKeywork WHERE ProductPropertyKeyworkID='" + ProductPropertyKeyworkID + "'";
            object obj = newdb.GetScalar(sql, CommandType.Text, null);
            return Convert.ToInt32(obj);
        }

        //检测正式库中产品分类属性关系是否已存在
        public int CheckNewDatabaseProductCategoryRelProperty(string ProductCategoryID)
        {
            string sql = "SELECT count(*) FROM dbo.GM_ProductCategoryRelProperty WHERE ProductCategoryID='" + ProductCategoryID + "'";
            object obj = newdb.GetScalar(sql, CommandType.Text, null);
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 查询正式库中需求导入的数据 
        /// </summary>
        /// <returns></returns>
        public DataTable GetOnlineDatabaseCollectionInfoImportData()
        {
//            string sql = @"select InfoID, InfoTitle,InfoCode,ProviderID,MarketPrice,SalePrice,Number,
//    0 as Category,InsertTime,IsDel,StartTime,EndTime,NewGoodsID,IsDel from Uni2uni_GoodsInfo.dbo.CollectionInfo
//    WHERE 
//    IsDel=0
//    AND (GETDATE()>=StartTime AND GETDATE()<=EndTime) 
//    AND NewGoodsID IS NULL
//    AND InfoTitle NOT LIKE '%慈铭%'
//    ORDER BY InfoCode ASC ";
            string sql = @"SELECT a.*,b.ProductName,c.ProductCategoryRelNum,d.BrandName FROM dbo.GM_Goods A 
INNER JOIN dbo.GM_Products B ON A.ProductsID=B.ProductsID 
LEFT JOIN 
(
	SELECT ProductCategoryID,COUNT(*) ProductCategoryRelNum  FROM dbo.GM_ProductCategoryRelProperty group BY ProductCategoryID
)
C ON b.ProductCategoryID=C.ProductCategoryID
INNER JOIN dbo.GM_Brand D ON b.BrandID=d.BrandID
WHERE GoodCode IN(
select InfoCode from Uni2uni_GoodsInfo.dbo.CollectionInfo WHERE IsDel=0
AND (GETDATE()>=StartTime AND GETDATE()<=EndTime) 
AND NewGoodsID IS NULL
AND InfoTitle NOT LIKE '%慈铭%'
) 
ORDER BY GoodCode ASC";
            DataTable dt = newdb.GetDataTable(sql, CommandType.Text, null);
            return dt;
        }

    }

}