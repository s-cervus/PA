using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Manejo de archivos físicos (.txt y .html)
using System.Diagnostics; // Ejecutar el Bloc de Notas y el Navegador
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
                    // 1. Validar en Laptops
                    foreach (DataRow fila in FormVenta.TablaLaptops.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            if (stockActual < item.Cantidad)
                            {
                                MessageBox.Show("¡Gis de alerta! No hay suficiente stock de '" + item.Descripcion + "'.\nDisponibles: " + stockActual + " pzas.\nSolicitadas en carrito: " + item.Cantidad + " pzas.", "Falta de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }

                    // 2. Validar en Celulares
                    foreach (DataRow fila in FormVenta.TablaCelulares.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            if (stockActual < item.Cantidad)
                            {
                                MessageBox.Show("¡Gis de alerta! No hay suficiente stock de '" + item.Descripcion + "'.\nDisponibles: " + stockActual + " pzas.\nSolicitadas en carrito: " + item.Cantidad + " pzas.", "Falta de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }

                    // 3. Validar en Componentes
                    foreach (DataRow fila in FormVenta.TablaComponentes.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            if (stockActual < item.Cantidad)
                            {
                                MessageBox.Show("¡Gis de alerta! No hay suficiente stock de '" + item.Descripcion + "'.\nDisponibles: " + stockActual + " pzas.\nSolicitadas en carrito: " + item.Cantidad + " pzas.", "Falta de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }

                    // 4. Validar en Minerales
                    foreach (DataRow fila in FormVenta.TablaMinerales.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            if (stockActual < item.Cantidad)
                            {
                                MessageBox.Show("¡Gis de alerta! No hay suficiente stock/peso de '" + item.Descripcion + "'.\nDisponibles: " + stockActual + " unidades.\nSolicitadas en carrito: " + item.Cantidad + " unidades.", "Falta de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }
                }

                // =========================================================================
                // FASE 2: PROCESAR DESCUENTOS (Solo entra si la Fase 1 fue totalmente exitosa)
                // =========================================================================
                foreach (var item in FormVenta.Carrito)
                {
                    // Descontar en Laptops
                    foreach (DataRow fila in FormVenta.TablaLaptops.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            fila["Stock"] = stockActual - item.Cantidad;
                        }
                    }

                    // Descontar en Celulares
                    foreach (DataRow fila in FormVenta.TablaCelulares.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            fila["Stock"] = stockActual - item.Cantidad;
                        }
                    }

                    // Descontar en Componentes / Refacciones
                    foreach (DataRow fila in FormVenta.TablaComponentes.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            fila["Stock"] = stockActual - item.Cantidad;
                        }
                    }

                    // Descontar en Minerales
                    foreach (DataRow fila in FormVenta.TablaMinerales.Rows)
                    {
                        if (fila["ID"].ToString() == item.ID)
                        {
                            int stockActual = Convert.ToInt32(fila["Stock"]);
                            fila["Stock"] = stockActual - item.Cantidad;
                        }
                    }
                }

                // === GUARDADO MAESTRO EN DISCO DURO ===
                FormVenta.GuardarInventarioEnDisco();

                // =========================================================================
                // FASE 3: GENERACIÓN DE TICKET CORPORATIVO DETALLADO (.TXT)
                // =========================================================================
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                try
                {
                    // Generamos la marca de tiempo para el archivo físico
                    string nombreArchivo = "Ticket_Venta_" + timestamp + ".txt";
                    string rutaTicket = Path.Combine(Application.StartupPath, nombreArchivo);

                    // SISTEMA AUTÓNOMO DE FOLIOS: Cuenta cuántos archivos de ticket existen y le asigna el consecutivo
                    int numeroFolio = 1;
                    if (Directory.Exists(Application.StartupPath))
                    {
                        var archivosTickets = Directory.GetFiles(Application.StartupPath, "Ticket_Venta_*.txt");
                        numeroFolio = archivosTickets.Length + 1;
                    }
                    string folioFormateado = numeroFolio.ToString("D5"); // Convierte el 1 en "00001"

                    // Cálculos Contables e IVA
                    decimal totalVenta = 0;
                    foreach (var item in FormVenta.Carrito)
                    {
                        totalVenta += item.Total;
                    }
                    decimal subtotal = totalVenta / 1.16m;
                    decimal ivaCalculado = totalVenta - subtotal;

                    // Construcción del diseño tipo ticket de tienda comercial (Ancho estándar de 48 caracteres)
                    StringBuilder ticket = new StringBuilder();
                    ticket.AppendLine("************************************************");
                    ticket.AppendLine("                SOY PIBBLE S.A.                 ");
                    ticket.AppendLine("          SOLUCIONES LOGISTICAS & SCRAP         ");
                    ticket.AppendLine("        CECYT 13 'RICARDO FLORES MAGON'         ");
                    ticket.AppendLine("     TEL. EMPRESA: 55-6208-0416 Ext. 53132      ");
                    ticket.AppendLine("************************************************");
                    ticket.AppendLine(" FOLIO: TKT-" + folioFormateado);
                    ticket.AppendLine(" FECHA/HORA: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    ticket.AppendLine(" ATENDIO: Chimino Jimenez calvillo/Administrador");
                    ticket.AppendLine("------------------------------------------------");
                    // Encabezados con anchos fijos alineados: Descripcion(20), Cant(5), Precio U.(10), Importe(11)
                    ticket.AppendLine(string.Format("{0,-20} {1,5} {2,10} {3,11}", "Descripcion Art.", "Cant", "P. Unit", "Importe"));
                    ticket.AppendLine("------------------------------------------------");

                    foreach (var item in FormVenta.Carrito)
                    {
                        // Cortamos la descripción si excede los 18 caracteres para no romper las columnas del ticket
                        string descCortada = item.Descripcion.Length > 18 ? item.Descripcion.Substring(0, 18) : item.Descripcion;
                        decimal precioUnitario = item.Precio;

                        ticket.AppendLine(string.Format("{0,-20} {1,5} {2,10:C} {3,11:C}", descCortada, item.Cantidad, precioUnitario, item.Total));
                    }

                    ticket.AppendLine("------------------------------------------------");
                    ticket.AppendLine(string.Format("{0,-20} {1,5} {2,10} {3,11:C}", "SUBTOTAL:", "", "", subtotal));
                    ticket.AppendLine(string.Format("{0,-20} {1,5} {2,10} {3,11:C}", "I.V.A. (16%):", "", "", ivaCalculado));
                    ticket.AppendLine(string.Format("{0,-20} {1,5} {2,10} {3,11:C}", "TOTAL NETO:", "", "", totalVenta));
                    ticket.AppendLine("************************************************");
                    ticket.AppendLine("       POLIZA DE GARANTIA LIMITADA TECH         ");
                    ticket.AppendLine("   Este ticket cuenta con 30 dias de garantia   ");
                    ticket.AppendLine("   directa contra defectos de hardware o vicios ");
                    ticket.AppendLine("   ocultos en refacciones y componentes scrap.  ");
                    ticket.AppendLine("   No aplica por mal uso o rupturas fisicas.    ");
                    ticket.AppendLine("------------------------------------------------");
                    ticket.AppendLine("      ¡Gracias por apoyar al reciclaje!       ");
                    ticket.AppendLine("      Proyecto Aula - Reduciendo e-Waste        ");
                    ticket.AppendLine("************************************************");

                    // Grabamos el string final en el disco duro (.txt)
                    File.WriteAllText(rutaTicket, ticket.ToString());

                    // Abrimos el archivo en la pantalla con el Bloc de Notas de Windows
                    Process.Start("notepad.exe", rutaTicket);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al estructurar o imprimir el ticket: " + ex.Message, "Error de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // =========================================================================
                // ¡NUEVO!: APARTADO EXTRA DE GENERACIÓN DE CFDI 4.0 (FACTURA SAT)
                // =========================================================================
                DialogResult respuestaCFDI = MessageBox.Show(
                    "¿El cliente solicita Comprobante Fiscal Digital (Factura CFDI 4.0)?",
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

                        // Consecutivo de folios de factura
                        int numFolioFactura = 1;
                        if (Directory.Exists(Application.StartupPath))
                        {
                            var archivosCFDI = Directory.GetFiles(Application.StartupPath, "CFDI_SAT_Venta_*.html");
                            numFolioFactura = archivosCFDI.Length + 1;
                        }

                        // Re-calculamos importes contables exactos desglosando el IVA de la imagen
                        decimal totalVentaFactura = 0;
                        foreach (var item in FormVenta.Carrito) { totalVentaFactura += item.Total; }
                        decimal subtotalFactura = totalVentaFactura / 1.16m;
                        decimal ivaFactura = totalVentaFactura - subtotalFactura;

                        string uuid = Guid.NewGuid().ToString().ToUpper();
                        string selloDigital = Convert.ToBase64String(Encoding.UTF8.GetBytes(uuid + "PibbleLogisticaSAT"));

                        // Maquetación CSS/HTML idéntica al formato real del SAT que enviaste
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

                        // Fila Superior: Emisor y Bloque de Control Fiscal
                        html.AppendLine("<table class='header-table'>");
                        html.AppendLine("<tr>");
                        html.AppendLine($"<td style='width:55%'><strong>RFC emisor:</strong> CGS060118-RR3<br><strong>Nombre emisor:</strong> SOY PIBBLE S.A. DE C.V.<br><strong>Folio:</strong> {numFolioFactura}</td>");
                        html.AppendLine($"<td style='width:45%'><strong>Folio fiscal:</strong> {uuid}<br><strong>No. de serie del CSD:</strong> 00001000000517978910<br><strong>Serie:</strong> B</td>");
                        html.AppendLine("</tr>");
                        html.AppendLine("<tr><td colspan='2'><hr></td></tr>");

                        // Fila Media: Receptor y Datos de Expedición
                        html.AppendLine("<tr>");
                        html.AppendLine($"<td><strong>RFC receptor:</strong> BOA581223VS5<br><strong>Nombre receptor:</strong>  Bonifacia Enterprises, S.A.<br><br><strong>Uso CFDI:</strong> G01 Adquisición de Mercancías.</td>");
                        html.AppendLine($"<td><strong>Código postal, fecha y hora de emisión:</strong> 02770 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}<br><strong>Efecto de comprobante:</strong> Ingreso<br><strong>Régimen fiscal:</strong> Régimen General de las Personas Morales</td>");
                        html.AppendLine("</tr>");
                        html.AppendLine("</table>");

                        html.AppendLine("<div style='font-weight:bold; font-size:12px; margin-bottom:5px;'>Conceptos</div>");

                        // Tabla de Productos/Artículos Reciclados Vendidos
                        html.AppendLine("<table class='concepts-table'>");
                        html.AppendLine("<tr><th>Clave Producto</th><th>No. Identificación</th><th>Cantidad</th><th>Clave Unidad</th><th>Unidad</th><th>Valor Unitario</th><th>Importe</th><th>Objeto Impuesto</th></tr>");

                        foreach (var item in FormVenta.Carrito)
                        {
                            decimal valorUnitarioNeto = item.Precio / 1.16m;
                            decimal importeNetoArticulo = valorUnitarioNeto * item.Cantidad;

                            html.AppendLine("<tr>");
                            html.AppendLine($"<td>40101825</td>"); // Clave SAT estándar para Scrap/Reciclaje
                            html.AppendLine($"<td>KS{item.ID}</td>");
                            html.AppendLine($"<td>{item.Cantidad}</td>");
                            html.AppendLine($"<td>H87</td>"); // Clave de pieza/unidad comercial
                            html.AppendLine($"<td>PIEZAS</td>");
                            html.AppendLine($"<td>{valorUnitarioNeto:C}</td>");
                            html.AppendLine($"<td>{importeNetoArticulo:C}</td>");
                            html.AppendLine($"<td>Sí objeto de impuesto.</td>");
                            html.AppendLine("</tr>");

                            // Sub-renglón detallado de impuesto por artículo idéntico al del SAT
                            decimal ivaDeEsteArticulo = item.Total - importeNetoArticulo;
                            html.AppendLine($"<tr><td colspan='8' style='text-align:left; font-size:9px; background:#F2F2F2; border-top:0;'>");
                            html.AppendLine($"&nbsp;&nbsp;&nbsp;&nbsp;<strong>Base:</strong> {importeNetoArticulo:C} &nbsp;|&nbsp; <strong>Impuesto:</strong> IVA &nbsp;|&nbsp; <strong>Tipo Factor:</strong> Tasa &nbsp;|&nbsp; <strong>Tasa o Cuota:</strong> 16.00% &nbsp;|&nbsp; <strong>Importe IVA:</strong> {ivaDeEsteArticulo:C}");
                            html.AppendLine($"</td></tr>");
                        }
                        html.AppendLine("</table>");

                        // Sección inferior de Moneda, Métodos de Pago y Totales agrupados
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
                        html.AppendLine($"<tr><td style='font-size:12px;'><strong>Total:</strong></td><td style='font-size:12px; font-weight:bold;'>{totalVentaFactura:C}</td></tr>");
                        html.AppendLine("</table>");
                        html.AppendLine("</div>");
                        html.AppendLine("</div>");

                        // Bloque obligatorio de Sellos Digitales y Cadena Original del SAT
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

                        // Guardamos físicamente la factura .html en la carpeta bin/Debug
                        File.WriteAllText(rutaFactura, html.ToString());

                        // Lanzamos el archivo para que se abra automáticamente en el navegador de la máquina
                        Process.Start(new ProcessStartInfo(rutaFactura) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al compilar la Factura CFDI: " + ex.Message, "Error de Sistema Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // =========================================================================
                // FASE 4: CONTABILIDAD Y LIMPIEZA
                // =========================================================================
                string asiento = "--- POLIZA DE DIARIO / INGRESO ---\n\n" +
                                 "CARGO:\n" +
                                 "  [+] Caja y Bancos -------------- " + lblTotal.Text + "\n\n" +
                                 "ABONO:\n" +
                                 "  [-] Ventas de Mercancía / Scrap -- " + lblTotal.Text + "\n\n" +
                                 "¡Venta registrada e inventario actualizado con éxito!";

                MessageBox.Show(asiento, "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);

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