using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace Web.App.Infastructure
{



    // Originally from http://blogs.msdn.com/b/henrikn/archive/2012/02/18/using-json-net-with-asp-net-web-api.aspx
    public class JsonCamelCaseFormatter : MediaTypeFormatter
    {
        private readonly JsonSerializerSettings jsonSerializerSettings;

        public JsonCamelCaseFormatter()
        {
            jsonSerializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver =
                        new CamelCasePropertyNamesContractResolver()
                };

            // Fill out the mediatype and encoding we support
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            Encoding = new UTF8Encoding(false, true);
        }

        protected override bool CanReadType(Type type)
        {
            return type != typeof(IKeyValueModel);
        }

        protected override bool CanWriteType(Type type)
        {
            return true;
        }

        protected override Task<object> OnReadFromStreamAsync(Type type,            Stream stream, HttpContentHeaders contentHeaders, System.Runtime.Serialization.Formatter formatterContext)
        {
            // Create a serializer
            var serializer = JsonSerializer.Create(jsonSerializerSettings);

            // Create task reading the content
            return Task.Factory.StartNew(
                () =>
                {
                    using (var streamReader = new StreamReader(stream, Encoding))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                        return serializer.Deserialize(jsonTextReader, type);
                });
        }

        protected override Task OnWriteToStreamAsync(Type type, object value,
            Stream stream, HttpContentHeaders contentHeaders,
            Formatter formatterContext,
            System.Net.TransportContext transportContext)
        {
            // Create a serializer
            var serializer = JsonSerializer.Create(jsonSerializerSettings);

            // Create task writing the serialized content
            return Task.Factory.StartNew(
                () =>
                {
                    using (var jsonTextWriter =
                        new JsonTextWriter(new StreamWriter(stream, Encoding))
                        {
                            Formatting = Formatting.Indented,
                            CloseOutput = false
                        })
                    {
                        serializer.Serialize(jsonTextWriter, value);
                        jsonTextWriter.Flush();
                    }
                });
        }
    }


}