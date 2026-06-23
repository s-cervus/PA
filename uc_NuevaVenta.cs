using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Manejo de archivos físicos (.html, .pdf)
using System.Diagnostics; // Ejecutar el Navegador o el Bloc de Notas
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA
{
    public partial class uc_NuevaVenta : UserControl
    {
        public uc_NuevaVenta()
        {
            InitializeComponent();

            // MANDAMOS LLAMAR A LA FUNCIÓN QUE CARGA EL CARRITO EN LA TABLA
            ActualizarPantallaCaja();
        }

        // Esta función va a revisar el carrito del FormEntrada y lo pinta en la tabla
        public void ActualizarPantallaCaja()
        {
            dgvCarrito.DataSource = null; // Limpiamos la tabla
            dgvCarrito.DataSource = FormVenta.Carrito; // Le pasamos la lista global

            // Calculamos la suma total de lo que lleva
            decimal totalGeneral = 0;
            foreach (var item in FormVenta.Carrito)
            {
                totalGeneral += item.Total;
            }

            lblTotal.Text = "Total: " + totalGeneral.ToString("C"); // El "C" le da formato de dinero ($)
        }

        // Evento del botón para cobrar, actualizar inventario y simular la contabilidad
        private void btnTerminarVenta_Click_1(object sender, EventArgs e)
        {
            if (FormVenta.Carrito.Count > 0)
            {
                // =========================================================================
                // FASE 1: VALIDACIÓN DE SEGURIDAD (Revisar que haya suficiente stock de TODO)
                // =========================================================================
                foreach (var item in FormVenta.Carrito)
                {
                    DataRow filaEncontrada = null;
                    string categoria = "";

                    // Buscamos usando LINQ en cada tabla de inventario
                    filaEncontrada = FormVenta.TablaLaptops.AsEnumerable().FirstOrDefault(r => r["ID"].ToString() == item.ID);
                    if (filaEncontrada != null) categoria = "Laptops";

                    if (filaEncontrada == null)
                    {
                        filaEncontrada = FormVenta.TablaCelulares.AsEnumerable().FirstOrDefault(r => r["ID"].ToString() == item.ID);
                        if (filaEncontrada != null) categoria = "Celulares";
                    }

                    if (filaEncontrada == null)
                    {
                        filaEncontrada = FormVenta.TablaComponentes.AsEnumerable().FirstOrDefault(r => r["ID"].ToString() == item.ID);
                        if (filaEncontrada != null) categoria = "Componentes / Refacciones";
                    }

                    if (filaEncontrada == null)
                    {
                        filaEncontrada = FormVenta.TablaMinerales.AsEnumerable().FirstOrDefault(r => r["ID"].ToString() == item.ID);
                        if (filaEncontrada != null) categoria = "Minerales";
                    }

                    // Si localizamos el artículo, validamos sus existencias en stock
                    if (filaEncontrada != null)
                    {
                        int stockActual = Convert.ToInt32(filaEncontrada["Stock"]);
                        if (stockActual < item.Cantidad)
                        {
                            MessageBox.Show($"¡Gis de alerta! No hay suficiente stock/peso en la categoría [{categoria}] para '{item.Descripcion}'.\nDisponibles: {stockActual} pzas.\nSolicitadas en carrito: {item.Cantidad} pzas.", "Falta de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return; // Frena toda la transacción
                        }
                    }
                    else
                    {
                        MessageBox.Show($"El producto '{item.Descripcion}' (ID: {item.ID}) no fue localizado en ninguna de las tablas de inventario.", "Error de Catálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // =========================================================================
                // FASE 2: PROCESAR DESCUENTOS (Solo entra si la Fase 1 fue exitosa)
                // =========================================================================
                foreach (var item in FormVenta.Carrito)
                {
                    DataRow fila = FormVenta.TablaLaptops.AsEnumerable().FirstOrDefault(r => r["ID"].ToString() == item.ID) ??
                                   FormVenta.TablaCelulares.AsEnumerable().FirstOrDefault(r => r["ID"].ToString() == item.ID) ??
                                   FormVenta.TablaComponentes.AsEnumerable().FirstOrDefault(r => r["ID"].ToString() == item.ID) ??
                                   FormVenta.TablaMinerales.AsEnumerable().FirstOrDefault(r => r["ID"].ToString() == item.ID);

                    if (fila != null)
                    {
                        int stockActual = Convert.ToInt32(fila["Stock"]);
                        fila["Stock"] = stockActual - item.Cantidad;
                    }
                }

                // === GUARDADO MAESTRO EN DISCO DURO ===
                FormVenta.GuardarInventarioEnDisco();

                // =========================================================================
                // FASE 3: GENERACIÓN DE TICKET FORMATO PDF/HTML EXCLUSIVO
                // =========================================================================
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string folioFormateado = "00001";
                decimal totalVenta = 0;

                try
                {
                    string nombreTicket = "Ticket_Venta_" + timestamp + ".html";
                    string rutaTicket = Path.Combine(Application.StartupPath, nombreTicket);

                    // Sistema autónomo de folios
                    if (Directory.Exists(Application.StartupPath))
                    {
                        var archivosTickets = Directory.GetFiles(Application.StartupPath, "Ticket_Venta_*.html");
                        folioFormateado = (archivosTickets.Length + 1).ToString("D5");
                    }

                    foreach (var item in FormVenta.Carrito) { totalVenta += item.Total; }
                    decimal subtotal = totalVenta / 1.16m;
                    decimal ivaCalculado = totalVenta - subtotal;

                    // Maquetación HTML de Alta Calidad con CSS Emulado a un PDF Comercial Recortado (Ancho Fijo)
                    StringBuilder ticketHtml = new StringBuilder();
                    ticketHtml.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'><style>");
                    ticketHtml.AppendLine("body { font-family: 'Courier New', Courier, monospace; width: 320px; margin: 10px auto; padding: 10px; border: 1px dashed #000; font-size: 12px; color: #000; }");
                    ticketHtml.AppendLine(".center { text-align: center; }");
                    ticketHtml.AppendLine(".right { text-align: right; }");
                    ticketHtml.AppendLine("table { width: 100%; border-collapse: collapse; margin: 10px 0; }");
                    ticketHtml.AppendLine("th { border-bottom: 1px dashed #000; font-weight: bold; text-align: left; }");
                    ticketHtml.AppendLine("td { padding: 3px 0; vertical-align: top; }");
                    ticketHtml.AppendLine(".total-section { font-weight: bold; border-top: 1px dashed #000; margin-top: 5px; padding-top: 5px; }");
                    ticketHtml.AppendLine("</style></head><body>");

                    ticketHtml.AppendLine("<div class='center'>");
                    ticketHtml.AppendLine("<strong>SOY PIBBLE S.A.</strong><br>");
                    ticketHtml.AppendLine("SOLUCIONES LOGISTICAS & SCRAP<br>");
                    ticketHtml.AppendLine("CECYT 13 'RICARDO FLORES MAGON'<br>");
                    ticketHtml.AppendLine("TEL: 55-6208-0416 Ext. 53132<br>");
                    ticketHtml.AppendLine("====================================<br>");
                    ticketHtml.AppendLine($"<strong>FOLIO: TKT-{folioFormateado}</strong><br>");
                    ticketHtml.AppendLine($"FECHA: {DateTime.Now:dd/MM/yyyy HH:mm:ss}<br>");
                    ticketHtml.AppendLine("ATENDIÓ: Administrador Sistema<br>");
                    ticketHtml.AppendLine("</div>");

                    ticketHtml.AppendLine("<table>");
                    ticketHtml.AppendLine("<tr><th>DESCRIPCIÓN</th><th class='right'>CANT</th><th class='right'>IMP</th></tr>");

                    foreach (var item in FormVenta.Carrito)
                    {
                        string desc = item.Descripcion.Length > 18 ? item.Descripcion.Substring(0, 18) : item.Descripcion;
                        ticketHtml.AppendLine($"<tr><td>{desc}</td><td class='right'>{item.Cantidad}</td><td class='right'>{item.Total:C}</td></tr>");
                    }
                    ticketHtml.AppendLine("</table>");

                    ticketHtml.AppendLine("<div class='total-section'>");
                    ticketHtml.AppendLine($"<div class='right'>SUBTOTAL: {subtotal:C}</div>");
                    ticketHtml.AppendLine($"<div class='right'>I.V.A. (16%): {ivaCalculado:C}</div>");
                    ticketHtml.AppendLine($"<div class='right'>TOTAL NETO: {totalVenta:C}</div>");
                    ticketHtml.AppendLine("</div>");

                    ticketHtml.AppendLine("<br><div class='center' style='font-size:10px;'>");
                    ticketHtml.AppendLine("PÓLIZA DE GARANTÍA LIMITADA<br>");
                    ticketHtml.AppendLine("30 días directos contra defectos de hardware.<br>");
                    ticketHtml.AppendLine("------------------------------------<br>");
                    ticketHtml.AppendLine("¡Gracias por apoyar al reciclaje!<br>");
                    ticketHtml.AppendLine("Proyecto Aula - Reduciendo e-Waste");
                    ticketHtml.AppendLine("</div></body></html>");

                    File.WriteAllText(rutaTicket, ticketHtml.ToString());

                    // Lanzamos el Ticket en formato web listo para guardarse/imprimirse en PDF al instante
                    Process.Start(new ProcessStartInfo(rutaTicket) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al estructurar o imprimir el ticket PDF: " + ex.Message, "Error de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // =========================================================================
                // APARTADO DE GENERACIÓN DE CFDI 4.0 (FACTURA SAT)
                // =========================================================================
                DialogResult respuestaCFDI = MessageBox.Show(
                    "¿El cliente solicita Comprobante Fiscal Digital (Factura CFDI 4.0 PDF)?",
                    "Facturación SAT - Soy Pibble S.A.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuestaCFDI == DialogResult.Yes)
                {
                    try
                    {
                        string nombreFactura = "CFDI_SAT_Venta_" + timestamp + ".html";
                        string rutaFactura = Path.Combine(Application.StartupPath, nombreFactura);

                        int numFolioFactura = 1;
                        if (Directory.Exists(Application.StartupPath))
                        {
                            var archivosCFDI = Directory.GetFiles(Application.StartupPath, "CFDI_SAT_Venta_*.html");
                            numFolioFactura = archivosCFDI.Length + 1;
                        }

                        decimal subtotalFactura = totalVenta / 1.16m;
                        decimal ivaFactura = totalVenta - subtotalFactura;

                        string uuid = Guid.NewGuid().ToString().ToUpper();
                        string selloDigital = Convert.ToBase64String(Encoding.UTF8.GetBytes(uuid + "PibbleLogisticaSAT"));

                        StringBuilder html = new StringBuilder();
                        html.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'><style>");
                        html.AppendLine("body { font-family: Arial, sans-serif; font-size: 11px; color: #000; margin: 20px; line-height: 1.3; }");
                        html.AppendLine(".header-table, .concepts-table { width: 100%; border-collapse: collapse; margin-bottom: 12px; }");
                        html.AppendLine(".header-table td { padding: 4px; vertical-align: top; border: 0; }");
                        html.AppendLine(".concepts-table th { background-color: #A6A6A6; color: black; font-weight: bold; padding: 5px; text-align: center; border: 1px solid #000; font-size: 10px; }");
                        html.AppendLine(".concepts-table td { padding: 5px; border: 1px solid #000; text-align: center; }");
                        html.AppendLine(".title-invoice { font-size: 14px; font-weight: bold; text-align: center; margin-bottom: 15px; border-bottom: 2px solid #000; padding-bottom: 5px; text-transform: uppercase; }");
                        html.AppendLine(".totals-table { float: right; width: 260px; border-collapse: collapse; margin-top: 10px; }");
                        html.AppendLine(".totals-table td { padding: 4px; text-align: right; }");
                        html.AppendLine(".sello-box { font-size: 8px; word-break: break-all; border: 1px solid #000; padding: 4px; margin-top: 2px; background: #FFF; font-family: monospace; }");
                        html.AppendLine("hr { border: 0; border-top: 1px solid #000; margin: 5px 0; }");
                        html.AppendLine("</style></head><body>");

                        html.AppendLine("<div class='title-invoice'>Representación Impresa de Comprobante Fiscal Digital por Internet (CFDI 4.0)</div>");

                        html.AppendLine("<table class='header-table'>");
                        html.AppendLine("<tr>");
                        html.AppendLine($"<td style='width:55%'><strong>RFC emisor:</strong> CGS060118-RR3<br><strong>Nombre emisor:</strong> SOY PIBBLE S.A. DE C.V.<br><strong>Folio:</strong> {numFolioFactura}</td>");
                        html.AppendLine($"<td style='width:45%'><strong>Folio fiscal:</strong> {uuid}<br><strong>No. de serie del CSD:</strong> 00001000000517978910<br><strong>Serie:</strong> B</td>");
                        html.AppendLine("</tr>");
                        html.AppendLine("<tr><td colspan='2'><hr></td></tr>");

                        html.AppendLine("<tr>");
                        html.AppendLine($"<td><strong>RFC receptor:</strong> BOA581223VS5<br><strong>Nombre receptor:</strong>  Bonifacia Enterprises, S.A.<br><br><strong>Uso CFDI:</strong> G01 Adquisición de Mercancías.</td>");
                        html.AppendLine($"<td><strong>Código postal, fecha y hora de emisión:</strong> 02770 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}<br><strong>Efecto de comprobante:</strong> Ingreso<br><strong>Régimen fiscal:</strong> Régimen General de las Personas Morales</td>");
                        html.AppendLine("</tr>");
                        html.AppendLine("</table>");

                        html.AppendLine("<div style='font-weight:bold; font-size:12px; margin-bottom:5px;'>Conceptos</div>");

                        html.AppendLine("<table class='concepts-table'>");
                        html.AppendLine("<tr><th>Clave Producto</th><th>No. Identificación</th><th>Cantidad</th><th>Clave Unidad</th><th>Unidad</th><th>Valor Unitario</th><th>Importe</th><th>Objeto Impuesto</th></tr>");

                        foreach (var item in FormVenta.Carrito)
                        {
                            decimal valorUnitarioNeto = item.Precio / 1.16m;
                            decimal importeNetoArticulo = valorUnitarioNeto * item.Cantidad;

                            html.AppendLine("<tr>");
                            html.AppendLine($"<td>40101825</td>");
                            html.AppendLine($"<td>KS{item.ID}</td>");
                            html.AppendLine($"<td>{item.Cantidad}</td>");
                            html.AppendLine($"<td>H87</td>");
                            html.AppendLine($"<td>PIEZAS</td>");
                            html.AppendLine($"<td>{valorUnitarioNeto:C}</td>");
                            html.AppendLine($"<td>{importeNetoArticulo:C}</td>");
                            html.AppendLine($"<td>Sí objeto de impuesto.</td>");
                            html.AppendLine("</tr>");

                            decimal ivaDeEsteArticulo = item.Total - importeNetoArticulo;
                            html.AppendLine($"<tr><td colspan='8' style='text-align:left; font-size:9px; background:#F2F2F2; border-top:0;'>");
                            html.AppendLine($"&nbsp;&nbsp;&nbsp;&nbsp;<strong>Base:</strong> {importeNetoArticulo:C} &nbsp;|&nbsp; <strong>Impuesto:</strong> IVA &nbsp;|&nbsp; <strong>Tipo Factor:</strong> Tasa &nbsp;|&nbsp; <strong>Tasa o Cuota:</strong> 16.00% &nbsp;|&nbsp; <strong>Importe IVA:</strong> {ivaDeEsteArticulo:C}");
                            html.AppendLine($"</td></tr>");
                        }
                        html.AppendLine("</table>");

                        html.AppendLine("<div style='width: 100%; overflow: hidden;'>");
                        html.AppendLine("<div style='float:left; width:50%; line-height:1.6;'>");
                        html.AppendLine("<strong>Moneda:</strong> peso mexicano<br>");
                        html.AppendLine("<strong>Forma de pago:</strong> CREDITO / TRANSFERENCIA<br>");
                        html.AppendLine("<strong>Método de pago:</strong> Pago en una sola exhibición");
                        html.AppendLine("</div>");

                        html.AppendLine("<div style='float:right; width:45%;'>");
                        html.AppendLine("<table class='totals-table'>");
                        html.AppendLine($"<tr><td><strong>Subtotal:</strong></td><td style='width:100px;'>{subtotalFactura:C}</td></tr>");
                        html.AppendLine($"<tr><td><strong>Impuestos trasladados (IVA 16.00%):</strong></td><td>{ivaFactura:C}</td></tr>");
                        html.AppendLine($"<tr><td style='font-size:12px;'><strong>Total:</strong></td><td style='font-size:12px; font-weight:bold;'>{totalVenta:C}</td></tr>");
                        html.AppendLine("</table>");
                        html.AppendLine("</div>");
                        html.AppendLine("</div>");

                        html.AppendLine("<div style='margin-top:25px;'>");
                        html.AppendLine("<strong>Sello digital del CFDI:</strong>");
                        html.AppendLine($"<div class='sello-box'>{selloDigital}==</div>");
                        html.AppendLine("<strong>Sello digital del SAT:</strong>");
                        html.AppendLine($"<div class='sello-box'>SAT{Guid.NewGuid().ToString().Replace("-", "").ToUpper()}==</div>");
                        html.AppendLine("<strong>Cadena Original del complemento de certificación digital del SAT:</strong>");
                        html.AppendLine($"<div class='sello-box'>||1.1|{uuid}|{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}|SAT970701NN3|{selloDigital.Substring(0, 30)}...||</div>");
                        html.AppendLine("</div>");

                        html.AppendLine("<p style='text-align:center; color:#555; margin-top:20px; font-size:10px;'>Póliza de garantía de 30 días vigente. Este documento es una simulación contable con fines académicos para el Proyecto Aula.</p>");
                        html.AppendLine("</body></html>");

                        File.WriteAllText(rutaFactura, html.ToString());
                        Process.Start(new ProcessStartInfo(rutaFactura) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al compilar la Factura CFDI: " + ex.Message, "Error de Sistema Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // =========================================================================
                // FASE 4: CONTABILIDAD (Libro Diario en Formato Tabla Profesional HTML)
                // =========================================================================
                try
                {
                    string rutaDiarioHtml = Path.Combine(Application.StartupPath, "diario.html");
                    StringBuilder asientoHtml = new StringBuilder();

                    // Sistema autónomo de folios para los asientos
                    int numeroAsiento = 1;
                    if (File.Exists(rutaDiarioHtml))
                    {
                        // Contamos cuántas veces aparece la etiqueta de inicio de asiento para calcular el número actual
                        string contenidoActual = File.ReadAllText(rutaDiarioHtml);
                        numeroAsiento = (contenidoActual.Split(new string[] { "" }, StringSplitOptions.None).Length);
                    }
                    else
                    {
                        // Si el archivo no existe, creamos la estructura base del documento HTML con sus estilos CSS
                        asientoHtml.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'><style>");
                        asientoHtml.AppendLine("body { font-family: 'Arial', sans-serif; margin: 30px; color: #000; }");
                        asientoHtml.AppendLine(".diario-table { width: 100%; border-collapse: collapse; margin-bottom: 30px; font-size: 13px; }");
                        asientoHtml.AppendLine(".diario-table th, .diario-table td { border: 1px solid #000; padding: 6px; text-align: left; }");
                        asientoHtml.AppendLine(".header-green { background-color: #92D050; font-size: 16px; font-weight: bold; font-style: italic; text-align: center !important; }");
                        asientoHtml.AppendLine(".header-asiento { font-size: 14px; font-weight: bold; font-style: italic; text-align: center !important; width: 25%; }");
                        asientoHtml.AppendLine(".sub-headers th { background-color: #FFF; font-weight: bold; font-style: italic; text-align: center; font-size: 12px; }");
                        asientoHtml.AppendLine(".text-center { text-align: center; }");
                        asientoHtml.AppendLine(".text-right { text-align: right; }");
                        asientoHtml.AppendLine(".indent { padding-left: 25px !important; }");
                        asientoHtml.AppendLine(".concepto-row { border: 1px solid #000; padding: 8px; font-weight: bold; background-color: #FFF; font-size: 12px; margin-top: -31px; margin-bottom: 25px; border-top: 0; }");
                        asientoHtml.AppendLine("</style></head><body>");
                        asientoHtml.AppendLine("<h1 style='text-align:center; text-transform:uppercase;'>Registro de Libro Diario - Soy Pibble S.A.</h1><hr><br>");
                    }

                    // Estructura del Asiento según la imagen solicitada
                    asientoHtml.AppendLine("");
                    asientoHtml.AppendLine("<table class='diario-table'>");
                    asientoHtml.AppendLine("  <tr>");
                    asientoHtml.AppendLine("    <td colspan='3' class='header-green'>LIBRO DIARIO</td>");
                    asientoHtml.AppendLine($"    <td colspan='2' class='header-asiento'>ASIENTO No. {numeroAsiento.ToString("D3")}</td>");
                    asientoHtml.AppendLine("  </tr>");
                    asientoHtml.AppendLine("  <tr class='sub-headers'>");
                    asientoHtml.AppendLine("    <th style='width: 12%;'>FECHA</th>");
                    asientoHtml.AppendLine("    <th style='width: 48%;'>NOMBRE DE LAS CUENTAS</th>");
                    asientoHtml.AppendLine("    <th style='width: 12%;'>PARCIAL</th>");
                    asientoHtml.AppendLine("    <th style='width: 14%;'>DEBE</th>");
                    asientoHtml.AppendLine("    <th style='width: 14%;'>HABER</th>");
                    asientoHtml.AppendLine("  </tr>");

                    // Renglón del CARGO: Caja y Bancos
                    asientoHtml.AppendLine("  <tr>");
                    asientoHtml.AppendLine($"    <td class='text-center'>{DateTime.Now:dd/MM/yyyy}</td>");
                    asientoHtml.AppendLine("    <td>Caja y Bancos</td>");
                    asientoHtml.AppendLine("    <td></td>");
                    asientoHtml.AppendLine($"    <td class='text-right'>{totalVenta:C}</td>");
                    asientoHtml.AppendLine("    <td></td>");
                    asientoHtml.AppendLine("  </tr>");

                    // Renglón del ABONO: Ventas de Mercancía / Scrap (con sangría/indentado)
                    asientoHtml.AppendLine("  <tr>");
                    asientoHtml.AppendLine("    <td></td>");
                    asientoHtml.AppendLine("    <td class='indent'>Ventas de Mercancía / Scrap</td>");
                    asientoHtml.AppendLine("    <td></td>");
                    asientoHtml.AppendLine("    <td></td>");
                    asientoHtml.AppendLine($"    <td class='text-right'>{totalVenta:C}</td>");
                    asientoHtml.AppendLine("  </tr>");

                    // Renglón de SUMAS IGUALES
                    asientoHtml.AppendLine("  <tr>");
                    asientoHtml.AppendLine("    <td colspan='3' class='text-right' style='font-weight:bold; font-style:italic;'>SUMAS IGUALES</td>");
                    asientoHtml.AppendLine($"    <td class='text-right' style='font-weight:bold;'>{totalVenta:C}</td>");
                    asientoHtml.AppendLine($"    <td class='text-right' style='font-weight:bold;'>{totalVenta:C}</td>");
                    asientoHtml.AppendLine("  </tr>");
                    asientoHtml.AppendLine("</table>");

                    // Recuadro inferior de CONCEPTO
                    asientoHtml.AppendLine("<div class='concepto-row'>");
                    asientoHtml.AppendLine($"  CONCEPTO: Venta de mercancía reciclable e-waste correspondiente al ticket TKT-{folioFormateado}.");
                    asientoHtml.AppendLine("</div>");

                    // Guardamos o anexamos el bloque en el archivo HTML contable
                    File.AppendAllText(rutaDiarioHtml, asientoHtml.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al maquetar el asiento contable en HTML: " + ex.Message, "Error Diario HTML", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Ventana de aviso rápido en C#
                MessageBox.Show("¡Venta registrada e historial del Libro Diario estructurado con éxito!", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos todo para la siguiente venta
                FormVenta.Carrito.Clear();
                ActualizarPantallaCaja();
            }
            else
            {
                MessageBox.Show("El carrito está vacío, carnal. Agrega algo desde el catálogo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}