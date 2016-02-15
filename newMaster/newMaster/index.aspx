<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="newMaster.WebForm1" %>

<%@ Register TagPrefix="My" TagName="myUserControl" Src="~/myUserControl.ascx" %>
<%@ Reference Control="~/myUserControl.ascx" %>







<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <%--   <My:myUserControl runat="server" ID="myUserControl1" UserName="John Doe" UserAge="45" UserCountry="Australia" />
    <My:myUserControl runat="server" ID="myUserControl2" UserName="Svenne Banan" UserAge="73" UserCountry="Sweden" />--%>

    <%--    <My:myUserControl runat="server" ID="myUserControl" />--%>
    <asp:PlaceHolder runat="server" ID="phUserInfoBox" />
 




    <asp:Literal ID="litContactTable" runat="server"></asp:Literal>







    <script>
        function showModal(img) {
            $('#myContactImg').attr("src", img.src);
            $('#myContactImg').attr("width", "570px");
            $('#myModalImg').modal();
        }
    </script>

    <div id="myModalImg" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <img id="myContactImg" src="#" />
                </div>
            </div>
        </div>
    </div>




    <%--

    <div class="container">
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Förnamn</th>
                        <th>Efternamn</th>
                        <th>Alternativ</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>Testaren</td>
                        <td>Testpilotson</td>
                        <td>
                            <button type="button" class="btn btn-info btn-lgSmaller" data-toggle="modal" data-target="#myModalShowContact">Visa</button>
                            <button type="button" class="btn btn-infoYellow btn-lgSmaller" data-toggle="modal" data-target="#myModalChangeContact">Ändra</button>
                            <button type="button" class="btn btn-infoGreen btn-lgSmaller" data-toggle="modal" data-target="#myModalAddContact">Lägg till</button>
                            <button type="button" class="btn btn-infoRed btn-lgSmaller" data-toggle="modal" data-target="#myModalDeleteContact">Ta bort</button>
                        </td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Patrik</td>
                        <td>Weibust</td>
                        <td>Test utan edit</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    
    --%>








    <!-- Visa kontakt Modal -->
    <div id="myModalShowContact" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Kontaktinformation</h4>
                </div>
                <div class="modal-body">
                    <p>Här ska infon in, förnamn, efternamn adresser osv osv.......</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Ändra kontakt Modal -->
    <div id="myModalChangeContact" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Kontaktinformation</h4>
                </div>
                <div class="modal-body">


                    <div style="max-width: 500px; margin: 0 auto;">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>

                        <div class="form-group">
                            <label for="firstname">Förnamn:</label>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="lastname">Efternamn:</label>
                            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <button type="submit" class="btn btn-default">Uppdatera</button>
                    </div>


                    <%-- <p>kontakt att uppdatera.......</p>--%>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Avbryt</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Skapa ny kontakt Modal -->
    <div id="myModalAddContact" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Skapa en ny kontakt</h4>
                </div>
                <div class="modal-body">


                    <div style="max-width: 500px; margin: 0 auto;">
                        <asp:Literal ID="LiteralInfo" runat="server"></asp:Literal>

                        <div class="form-group">
                            <label for="firstname">Förnamn:</label>
                            <asp:TextBox ID="firstname" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="lastname">Efternamn:</label>
                            <asp:TextBox ID="lastname" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <button type="submit" class="btn btn-default">Lägg till</button>
                    </div>


                    <%--<p>Person som ska läggas till....</p>--%>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Avbryt</button>
                </div>
            </div>
        </div>
    </div>









    <!-- Ta bort kontakt Modal -->
    <div id="myModalDeleteContact" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Kontaktinformation</h4>
                </div>
                <div class="modal-body">
                    <p>Är du säker på att du vill ta bort kontakten?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Ja</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Nej</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>







