using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft;
using System.Net.Http;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace Sync_Livepass
{
    public partial class SyncLivepass : Form
    {
        static string ConexionString = ConfigurationManager.AppSettings["_ConexionString"];
        static string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
        SqlConnection conexion = new SqlConnection(ConexionString);
        string EventoCodigo;
        string EventoNombre;
        int CantTicketsUtilizados;
        List<string> IdTicketsUtilizados = new List<string>();
        bool Boton_Descargar;
        bool Boton_Reportar;

        public SyncLivepass()
        {
            InitializeComponent();
        }

        private void SyncLivepass_Load(object sender, EventArgs e)
        {
            ConsultaEventos();
            //btn_reportar.Enabled = false;
            //txt_cantidad_subida.Enabled = false;
            //txt_url_subida.Enabled = false;
            cbox_evento.SelectedIndex = -1;
            btn_Descargar.Enabled = false;
            lbl_estado.Visible = false;
            lbl_estado2.Visible=false;
            timer1.Interval=
            timer1.Interval=timer2.Interval=int.Parse(ConfigurationManager.AppSettings["TimerDelay"]);
            Boton_Descargar = false;
            Boton_Reportar = false;
            


        }
        private void ConsultaEventos()
        {
            try
            {
                conexion.Open();
                string QueryConsulta = "select codigo, nombre from evento where eliminado ='0' order by nombre";
                SqlCommand comando = new SqlCommand(QueryConsulta, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);

                DataTable Tabla = new DataTable();
                data.Fill(Tabla);
                conexion.Close();

                List<Evento> oEvento = new List<Evento>();

                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    oEvento.Add(new Evento
                    {
                        EventoCodigo = Tabla.Rows[i]["codigo"].ToString(),
                        EventoNombre = Tabla.Rows[i]["nombre"].ToString(),

                    });

                }
                cbox_evento.DataSource = oEvento;
                cbox_evento.DisplayMember = "EventoNombre";
                cbox_evento.ValueMember = "EventoCodigo";

            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.Message);

            }


        }

        private void Descargar()
        {
            
            timer1.Stop();
            timer1.Enabled = false;
            timer2.Stop();
            timer2.Enabled = false;
            btn_Descargar.Enabled = false;
            cbox_evento.Enabled = false;
            txt_url_Bajada.Enabled = false;
            txt_validator_code.Enabled = false;
            
            string FechaConsulta;


            try
            {
                //Consulta Last Update

                conexion.Open();
                SqlCommand ComandoConsLasUpd = new SqlCommand();
                ComandoConsLasUpd.Connection = conexion;
                ComandoConsLasUpd.CommandType = CommandType.StoredProcedure;
                ComandoConsLasUpd.CommandText = "Sp_consultalastupdatelivepass22";
                ComandoConsLasUpd.Parameters.Add(new SqlParameter("@validator_code", SqlDbType.VarChar, 50)).Value = txt_validator_code.Text;
                var a = ComandoConsLasUpd.ExecuteScalar();
                conexion.Close();

                DateTime b = Convert.ToDateTime(a);
                b = b.AddSeconds(1);
                FechaConsulta = b.ToString("yyyy-MM-ddTHH:mm:ss.mmm");
                //FechaConsulta = FechaConsulta.PadRight(17, '0');

                string FechaLlamada = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.mmm");



                lbl_estado.Text = "Solicitando Tickets...";
                MyDelay(500);
                // CONEXION CON LA API LIVEPASS 
                string url = txt_url_Bajada.Text.Trim().Replace("/validator_code/", "/" + txt_validator_code.Text.Trim() + "/");
                var client = new RestClient(url);
                client.Timeout = -1;
                client.FollowRedirects = false;
                var request = new RestRequest(Method.GET);
                request.AddParameter("start_date", FechaConsulta);
                request.AddParameter("end_date", FechaLlamada);
                request.AddParameter("page", "1");
                request.AddParameter("per_page", txt_cantidad_bajada.Text);
                request.AddHeader("Authorization", "Bearer "+ApiKey);
                IRestResponse response = client.Execute(request);

                List<Ticket> ticketsList = JsonConvert.DeserializeObject<List<Ticket>>(response.Content.ToString());

                if (ticketsList == null)
                {
                    btn_Descargar.Enabled = true;
                    lbl_estado.Visible = false;
                    lbl_estado2.Visible = false;
                    MessageBox.Show("Evento Vacio o Inexistente");
                    return;

                }

                if (ticketsList.Count == 0)
                {
                    progressBar1.Value = 0;
                    btn_Descargar.Enabled = false;
                    lbl_estado.Visible = true;

                    lbl_estado.Text = "Sin Tickets para Descargar...";
                    lbl_estado2.Visible = false;
                    
                    if (Boton_Reportar == true)
                    {
                        MyDelay(int.Parse(ConfigurationManager.AppSettings["TimerDelay"]));
                        Reportar();
                        return;
                    }
                    else
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                        return;
                    }
                    
                   
                    
                }
                progressBar1.Maximum = ticketsList.Count;
                progressBar1.Minimum = 0;

              

                for (int i = 0; i < ticketsList.Count; i++)
                {
                    lbl_estado.Visible = true;
                    lbl_estado.Text = "Descargando:";
                    progressBar1.Value = i + 1;
                    lbl_estado2.Visible = true;
                    txt_cantidad_bajada.Enabled = false;
                    lbl_estado2.Text = progressBar1.Value.ToString() + " / " + ticketsList.Count.ToString();

                    conexion.Open();
                    SqlCommand Comando = new SqlCommand();
                    Comando.Connection = conexion;
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = "SP_InsertaTicketsLivepass22";
                    
                    if (ticketsList[i].id == null) { ticketsList[i].id = ""; }
                    Comando.Parameters.Add(new SqlParameter("@id_ticket_livepass", SqlDbType.VarChar,50)).Value = ticketsList[i].id;
                    
                    if (ticketsList[i].label == null) { ticketsList[i].label = ""; }
                    Comando.Parameters.Add(new SqlParameter("@label", SqlDbType.VarChar, 50)).Value = ticketsList[i].label;
                    
                    if (ticketsList[i].event_name == null) { ticketsList[i].event_name = ""; }
                    Comando.Parameters.Add(new SqlParameter("@event_name", SqlDbType.VarChar, 50)).Value = ticketsList[i].event_name;

                    if (ticketsList[i].code == null) { ticketsList[i].code = ""; }
                    Comando.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar, 50)).Value = ticketsList[i].code;
                    
                    if (ticketsList[i].dni == null) { ticketsList[i].dni = ""; }
                    Comando.Parameters.Add(new SqlParameter("@dni", SqlDbType.VarChar, 50)).Value = ticketsList[i].dni;

                    if (ticketsList[i].location == null) { ticketsList[i].location = ""; }
                    Comando.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 50)).Value = ticketsList[i].location;

                    if (ticketsList[i].row == null) { ticketsList[i].row = ""; }
                    Comando.Parameters.Add(new SqlParameter("@row", SqlDbType.VarChar, 50)).Value = ticketsList[i].row;

                    if (ticketsList[i].number == null) { ticketsList[i].number = ""; }
                    Comando.Parameters.Add(new SqlParameter("@number", SqlDbType.VarChar, 50)).Value = ticketsList[i].number;

                    if (ticketsList[i].price == null) { ticketsList[i].price = ""; }
                    Comando.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar, 50)).Value = ticketsList[i].price;

                    if (ticketsList[i].status == null) { ticketsList[i].status = ""; }
                    Comando.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 50)).Value = ticketsList[i].status;

                    if (ticketsList[i].updated_at == null) { ticketsList[i].updated_at = ""; }
                    Comando.Parameters.Add(new SqlParameter("@updated_at", SqlDbType.VarChar,50)).Value = ticketsList[i].updated_at;

                    Comando.Parameters.Add(new SqlParameter("@validator_code", SqlDbType.VarChar, 50)).Value = txt_validator_code.Text;

                    Comando.ExecuteNonQuery();
                    conexion.Close();


                    MyDelay(int.Parse(ConfigurationManager.AppSettings["miliSegundosdelay"]));
                }

                //INSERTANDO EN TERCERO
                lbl_estado.Text = "Insertando en la Base de Datos";
                

                conexion.Open();
                SqlCommand Comando2 = new SqlCommand();
                Comando2.CommandType = CommandType.StoredProcedure;
                Comando2.Connection = conexion;
                Comando2.CommandText = "Sp_InsertaTicketsLivepass22Tercero";
                Comando2.Parameters.Add(new SqlParameter("@evento", SqlDbType.VarChar, 50)).Value = EventoCodigo;
                Comando2.Parameters.Add(new SqlParameter("@validator_code", SqlDbType.VarChar, 50)).Value = txt_validator_code.Text;
                Comando2.ExecuteNonQuery();
                conexion.Close();
                MyDelay(500);

                

                lbl_estado2.Text = "";
                lbl_estado.Text = "";
                progressBar1.Value = 0;


                if (Boton_Reportar == true)
                {
                    MyDelay(int.Parse(ConfigurationManager.AppSettings["TimerDelay"]));
                    Reportar();
                }
                else
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        private void btn_Descargar_Click(object sender, EventArgs e)
        {
            if (txt_validator_code.Text == "")
            {
                MessageBox.Show("Ingrese Validator Code");
            }
            else
            {
                if (Boton_Reportar == true)
                {
                    Boton_Descargar = true;
                }
                else
                {
                    Descargar();
                }
            }

        }
        public static void MyDelay(int ms)
        {

            //int milisegundosdelay = int.Parse(ConfigurationManager.AppSettings["miliSegundosdelay"]);

            DateTime dt = DateTime.Now + TimeSpan.FromMilliseconds(ms);

            do
            {
                Application.DoEvents();

            } while (DateTime.Now < dt);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Descargar();
        }

        private void cbox_evento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_evento.SelectedIndex >= 0)
            {
                EventoCodigo = cbox_evento.SelectedValue.ToString();
                EventoNombre = cbox_evento.Text.ToString();
                btn_Descargar.Enabled = true;
            }
        }

   
        public string  GetJsonBodyPost ()
        {
            JsonBodyPost body = new JsonBodyPost();
            List<codes> _code = new List<codes>();

            try
            {
                if (int.Parse(ProcesaTicketsUtilizados(txt_validator_code.Text)) > 0)
                {
                    conexion.Open();
                    SqlCommand Comando = new SqlCommand();
                    Comando.Connection = conexion;
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = "SP_ConsultaTicketsUtilizadosLivepass22";
                    Comando.Parameters.Add(new SqlParameter("@ValidatorCode", SqlDbType.VarChar, 50)).Value = txt_validator_code.Text;
                    SqlDataAdapter data = new SqlDataAdapter(Comando);
                    DataTable Tabla = new DataTable();
                    data.Fill(Tabla);
                    conexion.Close();

                    CantTicketsUtilizados = Tabla.Rows.Count;

                    for (int i = 0; i < Tabla.Rows.Count; i++)
                    {
                        codes o_code = new codes();

                        IdTicketsUtilizados.Add(Tabla.Rows[i]["id_ticket_livepass_syncro"].ToString());
                        o_code.code = Tabla.Rows[i]["code"].ToString();
                        o_code.devise_id = Tabla.Rows[i]["device"].ToString();

                        DateTime b = Convert.ToDateTime(Tabla.Rows[i]["FechaPasada"]);
                        o_code.captured_at = b.ToString("yyyy-MM-ddTHH:mm:ss.mmm");

                        o_code.dni = "";

                        _code.Add(o_code);
                    }


                    body.codes = _code;

                    string Resultbody = JsonConvert.SerializeObject(body);

                    return Resultbody;
                }
                else
                {
                    lbl_estado.Visible = true;
                    lbl_estado.Text = "Sin tickets para reportar";
                    MyDelay(1000);
                    lbl_estado.Visible = false;
                    return "";
                }
             
            }
            catch (Exception ex)
            {
              
                MessageBox.Show(ex.Message);
                return "";
            }
     
        }

        private void btn_reportar_Click(object sender, EventArgs e)
        {
            if (txt_validator_code.Text == "")
            {
                MessageBox.Show("Ingrese Validator Code");
            }
            else
            {
                if (Boton_Reportar == false)
                {
                    Boton_Reportar = true;
                    btn_reportar.Text = "Detener Reporte";
                    
                }
                else
                {
                    Boton_Reportar = false;
                    btn_reportar.Text = "Reportar";
                    timer2.Stop();
                    timer2.Enabled = false;
                    
                }


                if (Boton_Descargar == false && Boton_Reportar == true)
                {
                    Reportar();
                    Boton_Reportar = true;
                    

                }
            }


           
           
            
            

           

        }

        private void Reportar()
        {
            timer2.Stop();
            timer2.Enabled = false;

            var body = GetJsonBodyPost();
            if (body != "")
            {
                try
                {

                    progressBar1.Maximum = 1;
                    progressBar1.Minimum = 0;
                    lbl_estado.Visible = true;
                    lbl_estado2.Visible = true;
                    lbl_estado.Text = "Reportando";
                    lbl_estado2.Text = CantTicketsUtilizados.ToString() + " Tickets utilizados";



                    string url = txt_url_subida.Text.Trim().Replace("/validator_code/", "/" + txt_validator_code.Text.Trim() + "/");
                    var client = new RestClient(url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", "Bearer " + ApiKey);
                    request.AddHeader("Content-Type", "application/json");
                    //request.AddHeader("Cookie", "SPSE=FKFJ8Uy9cKUlVX9U6MVy5M9ELbFP+WXycW/oS8WmT1FZ9F0ons19r3jTBQ81x04ZKkr+iUFcsncBKLtuaDzSuA==; SPSI=c24100627f9780df3de0387bab077dd7");


                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);

                    if (response.StatusCode.ToString() == "OK")
                    {
                        foreach (string id in IdTicketsUtilizados)
                        {
                            conexion.Open();
                            SqlCommand Comando2 = new SqlCommand();
                            Comando2.Connection = conexion;
                            Comando2.CommandType = CommandType.StoredProcedure;
                            Comando2.CommandText = "SP_RegistraStatusTicketLivepass_Syncro22";
                            Comando2.Parameters.Add(new SqlParameter("@id_ticket", SqlDbType.VarChar, 50)).Value = id;
                            Comando2.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar, 50)).Value = response.StatusCode.ToString();
                            Comando2.ExecuteNonQuery();
                            conexion.Close();
                        }
                        IdTicketsUtilizados.Clear();

                    }
                    MyDelay(int.Parse(ConfigurationManager.AppSettings["miliSegundosdelay"]));

                    progressBar1.Value = 1;
                    MyDelay(1000);
                    lbl_estado.Visible = false;
                    lbl_estado2.Visible = false;
                    progressBar1.Value = 0;
                    MyDelay(1000);


                    if (Boton_Descargar == true)
                    {
                  
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                    else
                    {
                        
                        timer2.Enabled = true;
                        timer2.Start();
                    }

                   


                }


                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                if (Boton_Descargar == true)
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }
                else
                {
                    timer2.Enabled = true;
                    timer2.Start();
                 
                }
            }

        }

        private string ProcesaTicketsUtilizados(string ValidatorCode)
        {
            try
            {
                conexion.Open();
                SqlCommand Comando = new SqlCommand();
                Comando.Connection = conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "SP_ProcesaTicketsUtilizadosLivepass22";
                Comando.Parameters.Add(new SqlParameter("@ValidatorCode", SqlDbType.VarChar, 50)).Value = ValidatorCode;
                Comando.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int)).Value = Convert.ToInt32(txt_cantidad_subida.Text);
                var a=Comando.ExecuteScalar();
                conexion.Close();
                return a.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "0";
               

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Reportar();
        }
    }
}
