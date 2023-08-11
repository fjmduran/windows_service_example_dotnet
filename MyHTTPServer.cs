using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EjemploServicioDotNET
{
    internal class MyHTTPServer
    {
        public MyHTTPServer() {
            HttpListener _listener = new();
            Thread _listenerThread;


            _listenerThread = new(StartListener);
            const string url = "http://localhost:8888/";

            _listener.Prefixes.Add(url);
            _listener.Start();
            _listenerThread.Start();

            Console.WriteLine("Servidor HTTP iniciado en " + url);

            void StartListener()
            {
                while (_listener.IsListening)
                {
                    var context = _listener.GetContext();
                    var request = context.Request;                                       

                    var response = context.Response;
                    string miRespuesta = "Hola desde el servidor HTTP de @fjmduran";
                                                          
                    if (request.HttpMethod == "GET")
                    {
                        miRespuesta += "\nHa hecho una petición GET";
                    }

                    byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(miRespuesta);
                    response.ContentLength64 = responseBytes.Length;
                    response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
                    response.OutputStream.Close();
                }

            }
        }
    }
}
