<%@ Page Title="" Language="C#" MasterPageFile="~/Identory.Master" AutoEventWireup="true" CodeBehind="ManagerEdit.aspx.cs" Inherits="Inventory.UI.ManagerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-sm-12">
                <div class="form-horizontal m-t">
                    <div class="form-group">
                        <label class="col-sm-3 control-label">管理员编号：</label>
                        <div class="col-sm-8">
                            <input id="txtmno" name="mno" runat="server" minlength="6" maxlength="6" type="text" disabled class="form-control" required="" aria-required="true" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">管理员姓名：</label>
                        <div class="col-sm-8">
                            <input id="mname" runat="server" type="text" class="form-control" name="mname" required="" aria-required="true"/>
                        </div>
                    </div>
                     <div class="form-group">
                        <label class="col-sm-3 control-label">性别：</label>
                        <div class="col-sm-8">
                            <select id="sex" name="sex" runat="server" class="form-control" required="" aria-selected="True">
                                <option selected="selected" value="男">男</option>
                                <option value="女"> 女</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">仓库编号：</label>
                        <div class="col-sm-8">
                            <textarea id="stno" runat="server" name="stno" class="form-control" ></textarea>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">出生日期：</label>
                        <div class="col-sm-8">
                            <textarea id="birthday" runat="server" name="birthday" class="form-control" ></textarea>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-4 col-sm-offset-3">
                            <asp:Button runat="server" ID="btnEdit" Text="提交" CssClass="btn btn-primary" OnClick="btnEdit_Click"   />
                        </div>
                    </div>
                </div>
                

            </div>
        </div>
    </div>

    <script src="js/content.min.js?v=1.0.0"></script>
    <script src="js/plugins/validate/jquery.validate.min.js"></script>
    <script src="js/plugins/validate/messages_zh.min.js"></script>
</asp:Content>
