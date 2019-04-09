<%@ Page Title="" Language="C#" MasterPageFile="~/Identory.Master" AutoEventWireup="true" CodeBehind="InventList.aspx.cs" Inherits="Inventory.UI.InventList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper wrapper-content animated fadeInRight">
        <div class="ibox-content">
            <div class="row row-lg">
                <div class="col-sm-12">
                    <h4 class="example-title">管理员列表</h4>
                    <div class="example">
                        <table  class="table table-striped">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col" data-field="stno">仓库编号</th>
                                    <th scope="col" data-field="gno">商品</th>
                                    <th scope="col" data-field="number">库存总量</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td scope="row"><%# Eval("stno") %></td>
                                            <td><%# Eval("gno") %></td>
                                            <td><%# Eval("number") %></td>
                                        </tr>
                                    </ItemTemplate>                                    
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/content.min.js?v=1.0.0"></script>
    <script src="js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="js/demo/bootstrap-table-demo.min.js"></script>
    <script type="text/javascript" src="http://tajs.qq.com/stats?sId=9051096" charset="UTF-8"></script>
</asp:Content>
