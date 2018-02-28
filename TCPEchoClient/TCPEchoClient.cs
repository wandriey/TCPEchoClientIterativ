/*
 * TCPEchoClient
 *
 * Author Michael Claudius, ZIBAT Computer Scienc
 * Version 1.0. 2014.02.10
 * Copyright 2014 by Michael Claudius
 * Revised 2014.09.01, 2016.09.14
 * All rights reserved
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPEchoClient
{
    class TCPEchoClient
    {
        static void Main(string[] args)
        { 
            TcpClient clientSocket = new TcpClient("192.168.6.76", 6789);  //Clientens TCP opretter forbindelse til Serverens, ved brug af serverens
            Console.WriteLine("Client ready");                          //IP-adresse 

            Stream ns = clientSocket.GetStream();        //provides a Stream
            StreamReader sr = new StreamReader(ns);      //Et streamReader objekt laves (kan læse information)
            StreamWriter sw = new StreamWriter(ns);      //Et StreamWriter objekt laves (kan skrive information) 

            sw.AutoFlush = true;                         //enable automatic flushing (hvis ikke dette var enablet, så skulle hele
                                                         //StreamWriterens "buffer" være fyldt, før man er i stand til at sende informationen.
            for (int i = 0; i < 5; i++)
            {
                string message = Console.ReadLine();        //En variable message, der gives alt det der skrives i console vinduet som værdi. 

                sw.WriteLine(message);                      //Hvad sker helt præcist her? 
                string serverAnswer = sr.ReadLine();

                Console.WriteLine("Server: " + serverAnswer);

            }
            
            Console.WriteLine("No more from server. Press Enter");
            Console.ReadLine();

            ns.Close();

            clientSocket.Close();
        }
    }

}
