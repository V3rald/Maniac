using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.Converter
{
    public class ModeConverter : JsonConverter
    {
        public enum Mode
        {
            Fruits,
            Mania,
            Osu,
            Taiko
        }

        public override bool CanConvert(Type t) => t == typeof(Mode) || t == typeof(Mode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "fruits":
                    return Mode.Fruits;
                case "mania":
                    return Mode.Mania;
                case "osu":
                    return Mode.Osu;
                case "taiko":
                    return Mode.Taiko;
            }
            throw new Exception("Cannot unmarshal type Mode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Mode)untypedValue;
            switch (value)
            {
                case Mode.Fruits:
                    serializer.Serialize(writer, "fruits");
                    return;
                case Mode.Mania:
                    serializer.Serialize(writer, "mania");
                    return;
                case Mode.Osu:
                    serializer.Serialize(writer, "osu");
                    return;
                case Mode.Taiko:
                    serializer.Serialize(writer, "taiko");
                    return;
            }
            throw new Exception("Cannot marshal type Mode");
        }

        public static readonly ModeConverter Singleton = new ModeConverter();
    }
}
