using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;

namespace JSONParserVoorbeeld
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Tip: 
             * Open de properties van TempleOfDoom.json.
             * Zie dat build action op None staat -> Hij komt niet in je .exe / .dll file
             * Zie dat de copy to output directory op 'Copy if newer' staat -> 
             *  Hij is dus altijd relatief te benaderen om dat hij na het builden ook bij je .exe / .dll staat.
             *  
             */
            string fileName = "./Files/TempleOfDoom.json";

            /**
             * We gebruiken de nuget package Newtonsoft.json
             * Kijk voor documentatie op: http://www.newtonsoft.com/json/help
             */
            JObject json = JObject.Parse(File.ReadAllText(fileName));

            // Ga key value based door je json heen.
            JToken jtoken = json["rooms"][2]["items"][0]["type"];
            string type = jtoken.Value<string>();
            Console.WriteLine(type);

            // Parsing kan met generics naar het juiste type.
            jtoken = json.SelectToken("$.rooms[2].items[0].damage");
            int damage = jtoken.Value<int>();
            Console.WriteLine(damage);

            // Of loop door je children:
            foreach (JObject jconnection in json["connections"])
            {
                foreach (JProperty jProperty in jconnection.Children().OfType<JProperty>())
                {
                    Console.WriteLine($"Key: {jProperty.Name}, Value: {jProperty.Value}");

                }
            }

            // Of krijg een key/value dictionary van je items:
            JToken jFirstRoom = json["rooms"][0];
            Dictionary<string, string> roomProperties = jFirstRoom.ToObject<Dictionary<string, string>>();
            Console.WriteLine(roomProperties["width"]);

            // Of je parst direct naar je (parsed) objecten:
            JToken jPlayer= json["player"];
            ParsedPlayer parsedPlayer = jPlayer.ToObject<ParsedPlayer>();
            Console.WriteLine(parsedPlayer);

            Console.ReadKey();
        }
    }
}
