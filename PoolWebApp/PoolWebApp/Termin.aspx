<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Termin.aspx.cs" Inherits="PoolWebApp.Termin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="IDTermin" DataSourceID="TerminDataSource" Height="232px" Width="403px">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
        <asp:BoundField DataField="IDTermin" HeaderText="IDTermin" InsertVisible="False" ReadOnly="True" SortExpression="IDTermin" />
        <asp:BoundField DataField="VremeOd" HeaderText="VremeOd" SortExpression="VremeOd" />
        <asp:BoundField DataField="VremeDo" HeaderText="VremeDo" SortExpression="VremeDo" />
        <asp:BoundField DataField="DatumTermina" HeaderText="DatumTermina" SortExpression="DatumTermina" />
        <asp:BoundField DataField="IDBazen" HeaderText="IDBazen" SortExpression="IDBazen" />
        <asp:BoundField DataField="IDRezervacija" HeaderText="IDRezervacija" SortExpression="IDRezervacija" />
        <asp:BoundField DataField="IDAdmin" HeaderText="IDAdmin" SortExpression="IDAdmin" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="TerminDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:PoolAppConnectionString %>" DeleteCommand="DELETE FROM [Termin] WHERE [IDTermin] = @IDTermin" InsertCommand="INSERT INTO [Termin] ([VremeOd], [VremeDo], [DatumTermina], [IDBazen], [IDRezervacija], [IDAdmin]) VALUES (@VremeOd, @VremeDo, @DatumTermina, @IDBazen, @IDRezervacija, @IDAdmin)" SelectCommand="SELECT * FROM [Termin]" UpdateCommand="UPDATE [Termin] SET [VremeOd] = @VremeOd, [VremeDo] = @VremeDo, [DatumTermina] = @DatumTermina, [IDBazen] = @IDBazen, [IDRezervacija] = @IDRezervacija, [IDAdmin] = @IDAdmin WHERE [IDTermin] = @IDTermin">
    <DeleteParameters>
        <asp:Parameter Name="IDTermin" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter DbType="Time" Name="VremeOd" />
        <asp:Parameter DbType="Time" Name="VremeDo" />
        <asp:Parameter DbType="Date" Name="DatumTermina" />
        <asp:Parameter Name="IDBazen" Type="Int32" />
        <asp:Parameter Name="IDRezervacija" Type="Int32" />
        <asp:Parameter Name="IDAdmin" Type="Int32" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter DbType="Time" Name="VremeOd" />
        <asp:Parameter DbType="Time" Name="VremeDo" />
        <asp:Parameter DbType="Date" Name="DatumTermina" />
        <asp:Parameter Name="IDBazen" Type="Int32" />
        <asp:Parameter Name="IDRezervacija" Type="Int32" />
        <asp:Parameter Name="IDAdmin" Type="Int32" />
        <asp:Parameter Name="IDTermin" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
</asp:Content>
