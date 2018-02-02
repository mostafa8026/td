using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpExample
{
    class Program
    {
        
        public const string MyFileName = "tdjson.dll";
        [DllImport(MyFileName,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr td_json_client_create();
        
        [DllImport(MyFileName,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr td_json_client_destroy(IntPtr i);

        [DllImport(MyFileName,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr td_json_client_send(IntPtr i, string s);

        [DllImport(MyFileName,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr td_json_client_receive(IntPtr i, double d);

        [DllImport(MyFileName,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern void td_set_log_verbosity_level(int i);

        static void Main(string[] args)
        {
            //td_set_log_verbosity_level(10);

            var client = td_json_client_create();
            string jsonq = "{\"@type\": \"getTextEntities\", \"text\": \"@telegram /test_command https://telegram.org telegram.me\", \"@extra\": [\"5\", 7.0]}";
            //string jsonq = "{\"@type\": \"getAuthorizationState\", \"@extra\": 1.01234}";
            //td_json_client_send(client, jsonq);

            try
            {
                    var ret = td_json_client_receive(client, 10);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                td_json_client_destroy(client);
            }
        }
    }
}
