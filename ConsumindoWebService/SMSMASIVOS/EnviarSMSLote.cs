using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace ConsumindoWebService.SMSMASIVOS
{
    public class EnviarSMSLote
    {
        private string EnviarSMS()
        {
            //Codigo para enviar SMS
            string usuario = "MIUSUARIO";
            string clave = "MICLAVE";
            string numero = "1144445555";
            string texto = "Texto de prueba!";
            string respuesta = ""; //en esta variable quedará la respuesta del llamado a la API de SMS MASIVOS

            //Test sin enviar SMS
            Uri uri = new Uri("http://servicio.smsmasivos.com.ar/enviar_sms.asp?TEST=1&API=1&USUARIO=" + System.Web.HttpUtility.UrlEncode(usuario) + "&CLAVE=" + System.Web.HttpUtility.UrlEncode(clave) + "&TOS=" + System.Web.HttpUtility.UrlEncode(numero) + "&TEXTO=" + System.Web.HttpUtility.UrlEncode(texto));

            //Test enviando realmente un SMS
            //Uri uri = new Uri("http://servicio.smsmasivos.com.ar/enviar_sms.asp?API=1&USUARIO=" + System.Web.HttpUtility.UrlEncode(usuario) + "&CLAVE=" + System.Web.HttpUtility.UrlEncode(clave) + "&TOS=" + System.Web.HttpUtility.UrlEncode(numero) + "&TEXTO=" + System.Web.HttpUtility.UrlEncode(texto));

            HttpWebRequest requestFile = (HttpWebRequest)WebRequest.Create(uri);

            requestFile.ContentType = "application/html";

            HttpWebResponse webResp = requestFile.GetResponse() as HttpWebResponse;

            if (requestFile.HaveResponse)
            {
                if (webResp.StatusCode == HttpStatusCode.OK || webResp.StatusCode == HttpStatusCode.Accepted)
                {
                    StreamReader respReader = new StreamReader(webResp.GetResponseStream(), Encoding.GetEncoding("iso-8859-1"));

                    respuesta = respReader.ReadToEnd();

                    //En la variable respuesta queda la respuesta del llamado a nuestra API
                    //Colocar aquí lo que se desea hacer con la respuesta
                    return respuesta;
                }
            }
            return "Erro:";
        }


        public string EnviaSMSBloque()
        {
            string usuario = "MIUSUARIO";
            string clave = "MICLAVE";
            string bloque = "";
            string respuesta = ""; //en esta variable quedará la respuesta del llamado a la API de SMS MASIVOS

            bloque = bloque + "ID1\t1144444444\tMi texto 1\n";
            bloque = bloque + "ID2\t1155555555\tMi texto 2\n";

            Uri uri = new Uri("http://servicio.smsmasivos.com.ar/enviar_sms_bloque.asp");

            HttpWebRequest requestFile = (HttpWebRequest)WebRequest.Create(uri);

            requestFile.Method = "POST";
            requestFile.ContentType = "application/x-www-form-urlencoded";

            StringBuilder postData = new StringBuilder();
            postData.Append("api=" + HttpUtility.UrlEncode("1") + "&");
            postData.Append("usuario=" + HttpUtility.UrlEncode(usuario) + "&");
            postData.Append("clave=" + HttpUtility.UrlEncode(clave) + "&");
            postData.Append("separadorcampos=" + HttpUtility.UrlEncode("tab") + "&");
            postData.Append("bloque=" + HttpUtility.UrlEncode(bloque) + "&");

            //Comentar la linea de abajo para enviar realmente
            postData.Append("test=1");

            byte[] byteArray = Encoding.GetEncoding("iso-8859-1").GetBytes(postData.ToString());
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData.ToString());

            requestFile.ContentLength = byteArray.Length;

            Stream requestStream = requestFile.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Close();

            HttpWebResponse webResp = requestFile.GetResponse() as HttpWebResponse;

            if (requestFile.HaveResponse)
            {
                if (webResp.StatusCode == HttpStatusCode.OK || webResp.StatusCode == HttpStatusCode.Accepted)
                {
                    StreamReader respReader = new StreamReader(webResp.GetResponseStream(), Encoding.GetEncoding("iso-8859-1"));

                    respuesta = respReader.ReadToEnd();

                    //En la variable respuesta queda la respuesta del llamado a nuestra API
                    //Colocar aquí lo que se desea hacer con la respuesta
                    return respuesta;
                }
            }

            return "Erro";
        }


    }
}
