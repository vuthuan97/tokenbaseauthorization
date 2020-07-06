<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallAPI.aspx.cs" Inherits="webAPISolution.webAPI.CallAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
           <div class="form-group">
                <label for="txtName">Name:</label>
               <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
           </div>
            <div class="form-group">
               
                <label for="txtEmail">Email:</label>
               <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
           </div>
            <div class="form-group">
              
                <label for="txtLocation">Location :</label>
               <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
           </div>
            <div class="form-group">
                <asp:Button ID="btnSave" runat="server" Text="Save" />
           </div>


            <div class="row">
                <asp:DropDownList ID="dropdown" runat="server"></asp:DropDownList>
            </div>
        </div>
    </form>
</body>
</html>
 <script>
     function InsertData() {
         var data = {};
         data.EmpName = $("#txtName").val();
         data.Email = $("#txtEmail").val();
         data.Locations = $("#txtLocation").val();
         $.ajax({
             url: "http://localhost:52584/api/Insert",
             type: "POST",
             contentType: "Application/json;charset=utf-8",
             data: JSON.stringify(data),
             dataType: "json",
             success: function (response) {
                 alert(response);
                 location.reload();
             }
         });

     }
     $(document).ready(function () {
         $("#btnSave").click(function (e) {
             InsertData();
             e.preventDefault();

         });
     })
 </script>