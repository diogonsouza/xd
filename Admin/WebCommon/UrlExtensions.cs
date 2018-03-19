using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.WebCommon
{
    public static class UrlExtensions
    {
        public static string StaticTable(this UrlHelper helper, int page = 1)
        {
            return helper.Action("StaticTable", "Tabela", new { page = page});
        }

        public static string StaticTableCheckBox(this UrlHelper helper, int page = 1)
        {
            return helper.Action("StaticTableCheckBox", "Tabela", new { page = page });
        }

        public static string StaticTableCheckBoxPadding(this UrlHelper helper, int page = 1)
        {
            return helper.Action("StaticTableCheckBoxPadding", "Tabela", new { page = page });
        }

        public static string DynamicTable(this UrlHelper helper, int page = 1)
        {
            return helper.Action("DynamicTable", "Tabela", new { page = page });
        }

        public static string Logout(this UrlHelper helper)
        {
            return helper.Action("Logout", "Login");
        }
    }
}