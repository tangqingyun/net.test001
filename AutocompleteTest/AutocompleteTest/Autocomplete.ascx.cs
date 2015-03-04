using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutocompleteTest
{
    public partial class Autocomplete : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdDataType.Value = DataType;
            }
        }

        public string DataType { set; get; }
       
    }


    public enum EnumAction
    {
        /// <summary>
        /// 人员
        /// </summary>
        Emplyee,
        /// <summary>
        /// 供应商
        /// </summary>
        Provider,
        /// <summary>
        /// 商品
        /// </summary>
        Goods,
    }
}