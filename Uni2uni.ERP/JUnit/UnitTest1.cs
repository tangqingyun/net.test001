using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uni2uni.ERP.Bll;
using Uni2uni.ERP.Domain;
using Uni2uni.ERP.Domain.Parameters;

namespace JUnit
{
    [TestClass]
    public class UnitTest1 : TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void CreateCategory()
        {
            ProductCategoryBll bll = new ProductCategoryBll();
            Guid id = Guid.NewGuid();
            Guid parentId = new Guid("03AB2F9D-873D-410B-92D4-19C7A2DD29A7");
            string cateName = "生活百货7";
            ProductCategory model;
            string msg;
            bool bol = bll.CreateCategory(id, cateName, parentId, out model, out msg);
            Assert.IsTrue(bol, "添加失败！");
        }

        [TestMethod]
        public void GetCategory()
        {
           var model= ProductCategory.Get(new Guid("03AB2F9D-873D-410B-92D4-19C7A2DD29A7"));
           var list = model.ChildrenList;
           Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GetProductCategoryPage()
        {
            ProductCategoryBll bll = new ProductCategoryBll();
            int pageIndex = 1;
            int pageSize = 10;
            ProductCategoryParam model = new ProductCategoryParam();
            int total;
            var list = bll.GetPageData(pageIndex, pageSize,model,out total);
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GetProductCategory()
        {
            ProductCategoryBll bll = new ProductCategoryBll();
            var model = bll.GetProductCategoryById(new Guid("00000000-0000-0000-0000-000000000000"));
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void ChangeCategory()
        {
            ProductCategoryBll bll = new ProductCategoryBll();
            string msg;
            bool bol = bll.ChangeCategory(Guid.Empty, "全部分类", Guid.Empty, out msg);
            Assert.IsTrue(bol, "更新失败");
        }

        [TestMethod]
        public void CreateProduct()
        {
            ProductBll bll = new ProductBll();
            Product newProduct;
            string msg;
            string productName = "测试产品333";
            bool bol = bll.CreateProduct(Guid.NewGuid(), new Guid("BF8F0EDD-7E4D-4861-B827-A228009AF0AA"), productName, out newProduct, out msg);
            Assert.IsTrue(bol, "创建失败！");
        }

         [TestMethod]
        public void GetProduct()
        {
            ProductBll bll = new ProductBll();
            Product p = Product.Get(new Guid("141DC549-0C3F-4108-A00E-A22800B4EAAD"));
            foreach (var itm in p.GoodsList)
            {
                string gname=itm.GoodsName;
            }

        }

        [TestMethod]
        public void CreateGoods()
        {
            ProductBll bll = new ProductBll();
            Goods newGoods;
            string msg;
            GoodsParam param = new GoodsParam
            {
                GoodsId = Guid.NewGuid(),
                Product = Product.Get(new Guid("141DC549-0C3F-4108-A00E-A22800B4EAAD")),
                GoodsName = "OLAY玉兰油水感透白轻透倍护隔离防晒液SPF30 PA+++ 40ml",
                GoodsPrice = 100,
                SalePrice = 90,
                GoodsDetailPath = "www.uni2uni.com"
            };
            bool bol = bll.CreateGoods(param, out newGoods, out msg);
            Assert.IsTrue(bol, "创建成功");
        }

    }
}
