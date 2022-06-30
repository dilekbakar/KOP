<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IslemSil.aspx.cs" Inherits="KOP.IslemSil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="style-table">
                <tr>
                    <td>UYE_AD</td>
                    <td>
                        <asp:TextBox ID="txtUYE_AD" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>KITAP_ADI</td>
                    <td>
                        <asp:TextBox ID="txtKITAP_ADI" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>VERILME_TAR</td>
                    <td>
                        <asp:TextBox ID="txtVERILME_TAR" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>TESLIM_TAR</td>
                    <td>
                        <asp:TextBox ID="txtTESLIM_TAR" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSIL" Text="İşlemi Sil" runat="server" OnClick="btnSIL_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblUyariSIL" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
              <asp:hiddenfield id="hfUYE_AD"
              value="0" 
              runat="server"/>
          <asp:hiddenfield id="hfKITAP_ADI"
              value="0" 
              runat="server"/>
          <asp:hiddenfield id="hfVERILME_TAR"
              value="0" 
              runat="server"/>
          <asp:hiddenfield id="hfTESLIM_TAR"
              value="0" 
              runat="server"/>
          
    </form>
</body>
</html>
