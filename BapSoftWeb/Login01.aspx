<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login01.aspx.cs" Inherits="Login01" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>»» Inicio Sesion ««</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="description" content="Expand, contract, animate forms with jQuery wihtout leaving the page" />
        <meta name="keywords" content="expand, form, css3, jquery, animate, width, height, adapt, unobtrusive javascript"/>
		<link rel="shortcut icon" href="../favicon.ico" type="image/x-icon"/>
        <link rel="stylesheet" type="text/css" href="css/style.css" />
		<script src="js/cufon-yui.js" type="text/javascript"></script>
		<script src="js/ChunkFive_400.font.js" type="text/javascript"></script>
		<script type="text/javascript">
		    Cufon.replace('h1', { textShadow: '1px 1px #fff' });
		    Cufon.replace('h2', { textShadow: '1px 1px #fff' });
		    Cufon.replace('h3', { textShadow: '1px 1px #000' });
		    Cufon.replace('.back');
		</script>
        
        <%-- Otros Agregados --%>
        <script src="js/JSfunciones.js" type="text/javascript"></script>
        <link href="css/login02.css" rel="stylesheet" type="text/css" /> 

    </head>
<body>
    <div class="wrapper">	       
			<div class="content">
				<div id="form_wrapper" class="form_wrapper">
					<form class="register">
						<h3>Registro</h3>
						<div class="column">
							<div>
								<label>Primer Nombre:</label>
								<input type="text" />
								<span class="error">Esto es un Error</span>
							</div>
							<div>
								<label>Segundo Nombre:</label>
								<input type="text" />
								<span class="error">Esto es un Error</span>
							</div>
							<div>
								<label>Sitio Web:</label>
								<input type="text" value="http://"/>
								<span class="error">Esto es un Error</span>
							</div>
						</div>
						<div class="column">
							<div>
								<label>Usuario:</label>
								<input type="text"/>
								<span class="error">Esto es un Error</span>
							</div>
							<div>
								<label>Email:</label>
								<input type="text" />
								<span class="error">Esto es un Error</span>
							</div>
							<div>
								<label>Contraseña:</label>
								<input type="password" />
								<span class="error">Esto es un Error</span>
							</div>
						</div>
						<div class="bottom">
							<div class="remember">
								<input type="checkbox" />
								<span>Deseo recibir actualizaciones</span>
							</div>
							<input type="submit" value="Registrar" />
							<a href="index.html" rel="login" class="linkform">Usted tiene una cuenta ya? Inicio de sesión aquí</a>
							<div class="clear"></div>
						</div>
					</form>
					<form class="login active" runat="server">
                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
						<div>									            			                        
                            <h3>Ingreso al Sistema</h3>			             							                                      
					        <label>Empresa:</label>
                            <asp:DropDownList ID="cboEmpresalogueo" runat="server" CssClass="con_estilos" AutoPostBack="True" OnSelectedIndexChanged="cboEmpresalogueo_SelectedIndexChanged">
                            </asp:DropDownList>				           				           
					        <label>Usuario:</label>
                            <asp:TextBox ID="txtusuario" runat="server" CssClass="full-width"></asp:TextBox>									           				          
					        <label>Clave: <a href="forgot_password.html" rel="forgot_password" class="forgot linkform">Olvidaste tu contraseña?</a></label>
                            <asp:TextBox ID="txtpassword" runat="server" CssClass="full-width" TextMode="Password"></asp:TextBox>				            							                                                
                        </div>
						<div class="bottom">
							<div class="remember"><input type="checkbox" /><span>Mantenme conectado</span></div>							
                            <asp:Button ID="btnAceptar" runat="server" Text="Acceder" OnClick="btnAceptar_Click" />
							<a href="register.html" rel="register" class="linkform">No cerrar sesión ¿No tienes una cuenta todavía? Regístrese aquí</a>
							<div class="clear"></div>
						</div>

                         <!-- Dialog box:: Edit linea info style="display:none;" -->
                        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                        <%--<section id="Section1">--%>

                        <asp:Panel ID="pnlEditData" runat="server" CssClass="modalPopup" Height="300px" Width="600px" onmouseup="mueve_divbuscar();"  Style="display: none">

                            <table width="600" border="0" cellpadding="0" cellspacing="0">
                                <tr class="headPopup" style="height: 10px">
                                    <td width="500" align="left">&nbsp;&nbsp;Perfil de Usuario&nbsp;<asp:Label ID="txt_titulo" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="100" align="right">
                                        <asp:ImageButton runat="server" ID="btn_cerrar" ImageUrl="~/images/cerrar-form.png" OnClientClick="cerrar();" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <div class="block-border2" style="width: 120px; position: absolute; top: 53px; left: 30px;">                              
                                <asp:Image ID="foto" runat="server" Visible="false" Height="140px" Width="120px" /><br />
                                <asp:Label ID="usuario" runat="server" Text="Label" Font-Size="7pt"></asp:Label>
                            </div>
                            <div class="block-border" style="width: 370px; position: absolute; top: 52px; left: 196px;">
                                <table>
                                    <tr>
                                        <td align="right">Dominio:&nbsp;&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cbo_dominio" runat="server" AutoPostBack="True" CssClass="cmb_Style"
                                                Enabled="True" Width="246px" OnSelectedIndexChanged="cbo_dominio_SelectedIndexChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Módulo:&nbsp;&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cbo_modulo" runat="server" AutoPostBack="True" CssClass="cmb_Style"
                                                Enabled="True" Width="246px" OnSelectedIndexChanged="cbo_modulo_SelectedIndexChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Local:&nbsp;&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cbo_local" runat="server" CssClass="cmb_Style" Width="246px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Fecha:&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="fechsis" runat="server" CssClass="textPopup" Width="100px" AutoPostBack="True">
                                            </asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="fechsis"
                                                Mask="99/99/9999" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                                                ErrorTooltipEnabled="True" MaskType="Date" UserDateFormat="DayMonthYear" />
                                            <cc1:CalendarExtender ID="fechguia_CalendarExtender" runat="server" Enabled="True"
                                                Format="dd/MM/yyyy" TargetControlID="fechsis" PopupPosition="TopLeft" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;&nbsp;
                                        </td>
                                        <td align="left" style="padding-left: 25px;">
                                            <asp:Button ID="editBox_OK" runat="server" Text="Ingresar" OnClick="editBox_OK_Click"/>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>

                        <%--</section>--%>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="hiddenTargetControlForModalPopup"
                            PopupControlID="pnlEditData" BackgroundCssClass="modalBackground" DropShadow="false" OnCancelScript="cancel()" />

					</form>
					<form class="forgot_password">
						<h3>Has Olvidado Tu Password</h3>
						<div>
							<label>Nombre de Usuario ó Email:</label>
							<input type="text" />
							<span class="error">Esto es un Error</span>
						</div>
						<div class="bottom">
							<input type="submit" value="Enviar recordatorio"></input>
							<a href="index.html" rel="login" class="linkform">De repente remebered? Inicio de sesión aquí</a>
							<a href="register.html" rel="register" class="linkform">No tienes una cuenta? Regístrese aquí</a>
							<div class="clear"></div>
						</div>
					</form>
				</div>
				<div class="clear"></div>
			</div>			
		</div>
		
		<!-- The JavaScript -->		
        <script src="js/JqueryGoogle.js" type="text/javascript"></script>
		<script type="text/javascript">
		    $(function () {
		        //la forma envoltorio (incluye todas las formas)
		        var $form_wrapper = $('#form_wrapper'),
					//la forma actual es el que tiene la clase activa
					$currentForm = $form_wrapper.children('form.active'),
					//los vínculos formulario de cambio
					$linkform = $form_wrapper.find('.linkform');

		        //obtener la anchura y la altura de cada formulario y guardarlos para más tarde					
		        $form_wrapper.children('form').each(function (i) {
		            var $theForm = $(this);
		            //resolver el problema ninguno visualización incorporada al utilizar fadeIn FadeOut
		            if (!$theForm.hasClass('active'))
		                $theForm.hide();
		            $theForm.data({
		                width: $theForm.width(),
		                height: $theForm.height()
		            });
		        });

		        //ancho y alto del envoltorio (el mismo de forma actual) conjunto
		        setWrapperWidth();

		        /*
				Para la demo desactivamos los botones de envío
                si usted envía el formulario, es necesario comprobar la
                que forma se Inscrito, y dar la clase activa
                a la forma que desea mostrar
				*/

		        $linkform.bind('click', function (e) {
		            var $link = $(this);
		            var target = $link.attr('rel');
		            $currentForm.fadeOut(400, function () {
		                //remove class active from current form
		                $currentForm.removeClass('active');
		                //new current form
		                $currentForm = $form_wrapper.children('form.' + target);
		                //animate the wrapper
		                $form_wrapper.stop()
									 .animate({
									     width: $currentForm.data('width') + 'px',
									     height: $currentForm.data('height') + 'px'
									 }, 500, function () {
									     //new form gets class active
									     $currentForm.addClass('active');
									     //show the new form
									     $currentForm.fadeIn(400);
									 });
		            });
		            e.preventDefault();
		        });

		        function setWrapperWidth() {
		            $form_wrapper.css({
		                width: $currentForm.data('width') + 'px',
		                height: $currentForm.data('height') + 'px'
		            });
		        }

		        /*
				para la demo desactivamos los botones de envío
                si usted envía el formulario, es necesario comprobar la
                que forma se Inscrito, y dar la clase activa
                a la forma que desea mostrar
				*/

		        //$form_wrapper.find('input[type="submit"]')
				//			 .click(function (e) {
				//			     e.preventDefault();
		        //			 });

		    });
        </script>

</body>
</html>
