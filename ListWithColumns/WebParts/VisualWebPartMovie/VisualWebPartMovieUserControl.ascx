<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPartMovieUserControl.ascx.cs" Inherits="ListWithColumns.WebParts.VisualWebPartMovie.VisualWebPartMovieUserControl" %>

<link href="/_layouts/15/ListWithColumns/css/jquery.dataTables.min.css" rel="stylesheet" />
<script src="/_layouts/15/ListWithColumns/js/jquery-1.12.4.js"></script>
<script src="/_layouts/15/ListWithColumns/js/jquery.dataTables.min.js"></script>
<link href="/_layouts/15/ListWithColumns/css/visualwebpart.css" rel="stylesheet" />

<script type="text/javascript" src="/_layouts/15/ListWithColumns/js/visualwebpart.js"></script>



<h1>Movie Web Part </h1>


    <table id="myTable" class="display">
        <thead>
            <tr>
                <th>Name</th>
                <th>Category</th>
                <th>Description</th>
                <th>Year</th>
                <th>Price</th>
                <th>Remove</th>
                <th>Edit</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>Name</th>
                <th>Category</th>
                <th>Description</th>
                <th>Year</th>
                <th>Price</th>
                <th>Remove</th>
                <th>Edit</th>
            </tr>
        </tfoot>
        <tbody>

            <%--<asp:Repeater ID="RepeaterMovie" runat="server" OnItemCommand="OnItemCommand">--%>
            <asp:Repeater ID="RepeaterMovie" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>

                            <asp:Label ID="lbl_Id" runat="server" Text='<%# ((SPListItem)Container.DataItem)["ID"]  %>' Visible="false" />

                            <asp:Label ID="lblMovie_Name" runat="server" Text='<%# ((SPListItem)Container.DataItem)["Movie_Name"]  %>' />
                         <%--   <asp:TextBox ID="txtMovie_Name" runat="server" Width="120" OnTextChanged="TextBox_OnTextChanged" Text='<%# ((SPListItem)Container.DataItem)["Movie_Name"]  %>' Visible="false" />--%>
                            <asp:TextBox ID="txtMovie_Name" Text='<%# ((SPListItem)Container.DataItem)["Movie_Name"]  %>' runat="server" Width="120" Visible="false" />
                        </td>
                        <td>
                            <asp:Label ID="lblMovie_Category" runat="server" Text='<%# ((SPListItem)Container.DataItem)["Movie_Category"]  %>' />
                         <%--   <asp:TextBox ID="txtMovie_Category" runat="server" Width="120" OnTextChanged="TextBox_OnTextChanged" Text='<%# ((SPListItem)Container.DataItem)["Movie_Category"]  %>' Visible="false" />--%>
                            <asp:TextBox ID="txtMovie_Category" Text='<%# ((SPListItem)Container.DataItem)["Movie_Category"]  %>' runat="server" Width="120" Visible="false" />
                        </td>
                        <td>

                            <asp:Label ID="lblMovie_Description" runat="server" Text='<%# ((SPListItem)Container.DataItem)["Movie_Description"]  %>' />
                         <%--   <asp:TextBox ID="txtMovie_Description" runat="server" Width="120" OnTextChanged="TextBox_OnTextChanged" Text='<%# ((SPListItem)Container.DataItem)["Movie_Description"]  %>' Visible="false" />--%>
                            <asp:TextBox ID="txtMovie_Description" Text='<%# ((SPListItem)Container.DataItem)["Movie_Description"]  %>' runat="server" Width="120" Visible="false" />
                        </td>
                        <td>
                            <asp:Label ID="lblMovie_Year" runat="server" Text='<%# ((SPListItem)Container.DataItem)["Movie_Year"]  %>' />
                        <%--    <asp:TextBox ID="txtMovie_Year" runat="server" Width="120" OnTextChanged="TextBox_OnTextChanged" Text='<%# ((SPListItem)Container.DataItem)["Movie_Year"]  %>' Visible="false" />--%>
                            <asp:TextBox ID="txtMovie_Year" Text='<%# ((SPListItem)Container.DataItem)["Movie_Year"]  %>' runat="server" Width="120" Visible="false" />
                        </td>
                        <td>
                            <asp:Label ID="lblMovie_Price" runat="server" Text='<%# ((SPListItem)Container.DataItem)["Movie_Price"]  %>' />
                          <%--  <asp:TextBox ID="txtMovie_Price" runat="server" Width="120" OnTextChanged="TextBox_OnTextChanged" Text='<%# ((SPListItem)Container.DataItem)["Movie_Price"]  %>' Visible="false" />--%>
                            <asp:TextBox ID="txtMovie_Price" Text='<%# ((SPListItem)Container.DataItem)["Movie_Price"]  %>' runat="server" Width="120" Visible="false" />
                        </td>
                        <td>
                            <%--  <asp:LinkButton ID="RemoveButton" runat="server" Text='Delete' CommandName="delete"
                            CausesValidation="false" CommandArgument='<%# ((SPListItem)Container.DataItem)["ID"]  %>'> </asp:LinkButton>--%>
                            <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Do you want to delete this ?');" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" OnClick="OnEdit" />
                            <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" Visible="false" OnClick="OnUpdate" />
                            <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false" OnClick="OnCancel" />
                           

                            <%-- <button class="ms-Button docs-DialogExample-button">Edit</button>--%>
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>

    <div class="row">
        <div class="col-sm-6">
            <button type="button" id="addButton" class="btn btn-primary" >Add Product</button>
        </div>
    </div>

    <%--// ADD NEW ITEM--%>
<div class="panel panel-primary hidden" id="editPanel">
    <div class="panel-heading">
        Product Information
    </div>
    <div class="panel-body">
        <table id="AddNew" class="display">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Category</th>
                    <th>Description</th>
                    <th>Year</th>
                    <th>Price</th>
                    <th>Add Item</th>
                    <th>Cancel</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <input type="hidden" id="productid" value="0" />
                        <input type="text" id="productName" class="form-control input" runat="server" value="Name.." />
                    </td>
                    <td>
                        <input type="text" id="productCategory" class="form-control input" runat="server" value="Action.." />
                    </td>
                    <td>
                        <input type="text" id="productDescription" class="form-control input" runat="server" value="Info.." />
                    </td>
                    <td>
                        <input type="text" id="productYear" class="form-control input" runat="server" value="Year.." />
                    </td>
                    <td>
                        <input type="text" id="productPrice" class="form-control input" runat="server" value="Price.." />
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkAdd" Text="Add" CssClass="btn btn-primary" runat="server" OnClick="addItem" />

                    </td>
                    <td>
                        <button type="button" id="cancelButton" class="btn btn-primary" onclick="cancelClick();">Cancel</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>



