﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer_TandaPenyerahan.aspx.cs" Inherits="MVC.UI.Report.ReportViewer_TandaPenyerahan" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <%-- <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">--%>
        <div class='form-vertical'>
       <asp:ScriptManager ID="ScriptManager1" runat="server">

       </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1"  runat="server" Font-Names="Verdana" 
            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" SizeToReportContent="true">
        </rsweb:ReportViewer>
        
    </div>


</form> 
   <%-- </asp:Content>--%>

</body>
</html>
