<%@ WebHandler Language="C#" Class="ImageHandler" %>

#region Using Directives
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HearbalKartDB.Data;
using HearbalKartDB.Entities;
using HearbalKart.Business.Classes;
using System.Linq;
using System.IO;
#endregion

public class ImageHandler : IHttpHandler {
    ProdTable objprod = new ProdTable();
    Product ObjprodClass = new Product();
    public void ProcessRequest (HttpContext context) {
        string imageid = context.Request.QueryString["ImID"];
        objprod = ObjprodClass.GetProdByID(Convert.ToInt32(imageid));
        string path = null;
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;
        if (!string.IsNullOrEmpty(imageid))
        {
            path = HttpContext.Current.Server.MapPath(objprod.ImageUrl);
            response.WriteFile(path);
        }
        else
            throw new ArgumentNullException();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}