using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.Converter
{
    public class StatusConverter : JsonConverter
    {
        public enum Status
        {
            Ranked,
            Loved,
            Graveyard,
            Pending,
            Approved,
            Qualified,
            Wip,
            Any
        }

        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ranked":
                    return Status.Ranked;
                case "loved":
                    return Status.Loved;
                case "graveyard":
                    return Status.Graveyard;
                case "pending":
                    return Status.Pending;
                case "approved":
                    return Status.Approved;
                case "qualified":
                    return Status.Qualified;
                case "wip":
                    return Status.Wip;
                case "any":
                    return Status.Any;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Ranked:
                    serializer.Serialize(writer, "ranked");
                    return;
                case Status.Loved:
                    serializer.Serialize(writer, "loved");
                    return;
                case Status.Graveyard:
                    serializer.Serialize(writer, "graveyard");
                    return;
                case Status.Pending:
                    serializer.Serialize(writer, "pending");
                    return;
                case Status.Approved:
                    serializer.Serialize(writer, "approved");
                    return;
                case Status.Qualified:
                    serializer.Serialize(writer, "qualified");
                    return;
                case Status.Wip:
                    serializer.Serialize(writer, "wip");
                    return;
                case Status.Any:
                    serializer.Serialize(writer, "any");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }
}
