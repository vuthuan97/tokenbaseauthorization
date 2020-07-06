<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallAPI2.aspx.cs" Inherits="webAPISolution.webAPI.CallAPI2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gv_display" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="name" HeaderText="Họ Tên" />
                    <asp:BoundField DataField="location" HeaderText="Quê Quán" />
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
