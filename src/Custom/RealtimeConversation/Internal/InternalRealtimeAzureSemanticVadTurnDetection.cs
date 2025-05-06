using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.RealtimeConversation;

[JsonSerializable(typeof(EndOfUtteranceDetection))]
internal partial class SourceGenerationContext : JsonSerializerContext
{ }

public class EndOfUtteranceDetection
{
    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("threshold")]
    public float? Threshold { get; set; }

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }
}

[Experimental("OPENAI002")]
[CodeGenType("RealtimeAzureSemanticVadTurnDetection")]
[CodeGenSerialization(nameof(PrefixPaddingMs), DeserializationValueHook = nameof(DeserializeMillisecondDuration), SerializationValueHook = nameof(SerializePrefixPaddingMs))]
[CodeGenSerialization(nameof(SilenceDurationMs), DeserializationValueHook = nameof(DeserializeMillisecondDuration), SerializationValueHook = nameof(SerializeSilenceDurationMs))]
internal class InternalRealtimeAzureSemanticVadTurnDetection : ConversationTurnDetectionOptions, IJsonModel<InternalRealtimeAzureSemanticVadTurnDetection>
{
    public InternalRealtimeAzureSemanticVadTurnDetection() : base(ConversationTurnDetectionKind.AzureSemanticVadDetection)
    {
    }

    internal InternalRealtimeAzureSemanticVadTurnDetection(ConversationTurnDetectionKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, float? threshold, TimeSpan? prefixPaddingMs, TimeSpan? silenceDurationMs, bool? createResponse, bool? removeFillerWords, EndOfUtteranceDetection endOfUtteranceDetection) : base(kind, additionalBinaryDataProperties)
    {
        Threshold = threshold;
        PrefixPaddingMs = prefixPaddingMs;
        SilenceDurationMs = silenceDurationMs;
        CreateResponse = createResponse;
        RemoveFillerWords = removeFillerWords;
        EndOfUtteranceDetection = endOfUtteranceDetection;
    }

    public float? Threshold { get; set; }

    public TimeSpan? PrefixPaddingMs { get; set; }

    public TimeSpan? SilenceDurationMs { get; set; }

    public bool? CreateResponse { get; set; }

    public bool? RemoveFillerWords { get; set; }

    public EndOfUtteranceDetection EndOfUtteranceDetection { get; set; }

    void IJsonModel<InternalRealtimeAzureSemanticVadTurnDetection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeAzureSemanticVadTurnDetection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(InternalRealtimeAzureSemanticVadTurnDetection)} does not support writing '{format}' format.");
        }
        base.JsonModelWriteCore(writer, options);
        if (Optional.IsDefined(Threshold) && _additionalBinaryDataProperties?.ContainsKey("threshold") != true)
        {
            writer.WritePropertyName("threshold"u8);
            writer.WriteNumberValue(Threshold.Value);
        }
        if (Optional.IsDefined(PrefixPaddingMs) && _additionalBinaryDataProperties?.ContainsKey("prefix_padding_ms") != true)
        {
            writer.WritePropertyName("prefix_padding_ms"u8);
            SerializePrefixPaddingMs(writer, options);
        }
        if (Optional.IsDefined(SilenceDurationMs) && _additionalBinaryDataProperties?.ContainsKey("silence_duration_ms") != true)
        {
            writer.WritePropertyName("silence_duration_ms"u8);
            SerializeSilenceDurationMs(writer, options);
        }
        if (Optional.IsDefined(CreateResponse) && _additionalBinaryDataProperties?.ContainsKey("create_response") != true)
        {
            writer.WritePropertyName("create_response"u8);
            writer.WriteBooleanValue(CreateResponse.Value);
        }
        if (Optional.IsDefined(RemoveFillerWords) && _additionalBinaryDataProperties?.ContainsKey("remove_filler_words") != true)
        {
            writer.WritePropertyName("remove_filler_words"u8);
            writer.WriteBooleanValue(RemoveFillerWords.Value);
        }
        if (Optional.IsDefined(EndOfUtteranceDetection) && _additionalBinaryDataProperties?.ContainsKey("end_of_utterance_detection") != true)
        {
            writer.WritePropertyName("end_of_utterance_detection"u8);
            writer.WriteRawValue(JsonSerializer.Serialize(EndOfUtteranceDetection, SourceGenerationContext.Default.EndOfUtteranceDetection));
        }
    }

    InternalRealtimeAzureSemanticVadTurnDetection IJsonModel<InternalRealtimeAzureSemanticVadTurnDetection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeAzureSemanticVadTurnDetection)JsonModelCreateCore(ref reader, options);

    protected override ConversationTurnDetectionOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeAzureSemanticVadTurnDetection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(InternalRealtimeAzureSemanticVadTurnDetection)} does not support reading '{format}' format.");
        }
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeInternalRealtimeAzureSemanticVadTurnDetection(document.RootElement, options);
    }

    internal static InternalRealtimeAzureSemanticVadTurnDetection DeserializeInternalRealtimeAzureSemanticVadTurnDetection(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        ConversationTurnDetectionKind kind = default;
        IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        float? threshold = default;
        TimeSpan? prefixPaddingMs = default;
        TimeSpan? silenceDurationMs = default;
        bool? createResponse = default;
        bool? removeFillerWords = default;
        EndOfUtteranceDetection eou = null;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("type"u8))
            {
                kind = prop.Value.GetString().ToConversationTurnDetectionKind();
                continue;
            }
            if (prop.NameEquals("threshold"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                threshold = prop.Value.GetSingle();
                continue;
            }
            if (prop.NameEquals("prefix_padding_ms"u8))
            {
                DeserializeMillisecondDuration(prop, ref prefixPaddingMs);
                continue;
            }
            if (prop.NameEquals("silence_duration_ms"u8))
            {
                DeserializeMillisecondDuration(prop, ref silenceDurationMs);
                continue;
            }
            if (prop.NameEquals("create_response"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                createResponse = prop.Value.GetBoolean();
                continue;
            }
            if (prop.NameEquals("remove_filler_words"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                removeFillerWords = prop.Value.GetBoolean();
                continue;
            }
            if (prop.NameEquals("end_of_utterance_detection"))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                eou = JsonSerializer.Deserialize(prop.Value, SourceGenerationContext.Default.EndOfUtteranceDetection);
            }
            additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
        }
        return new InternalRealtimeAzureSemanticVadTurnDetection(
            kind,
            additionalBinaryDataProperties,
            threshold,
            prefixPaddingMs,
            silenceDurationMs,
            createResponse,
            removeFillerWords,
            eou);
    }

    BinaryData IPersistableModel<InternalRealtimeAzureSemanticVadTurnDetection>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

    protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeAzureSemanticVadTurnDetection>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(InternalRealtimeAzureSemanticVadTurnDetection)} does not support writing '{options.Format}' format.");
        }
    }

    InternalRealtimeAzureSemanticVadTurnDetection IPersistableModel<InternalRealtimeAzureSemanticVadTurnDetection>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeAzureSemanticVadTurnDetection)PersistableModelCreateCore(data, options);

    protected override ConversationTurnDetectionOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeAzureSemanticVadTurnDetection>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                using (JsonDocument document = JsonDocument.Parse(data))
                {
                    return DeserializeInternalRealtimeAzureSemanticVadTurnDetection(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(InternalRealtimeAzureSemanticVadTurnDetection)} does not support reading '{options.Format}' format.");
        }
    }

    string IPersistableModel<InternalRealtimeAzureSemanticVadTurnDetection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public static implicit operator BinaryContent(InternalRealtimeAzureSemanticVadTurnDetection InternalRealtimeAzureSemanticVadTurnDetection)
    {
        if (InternalRealtimeAzureSemanticVadTurnDetection == null)
        {
            return null;
        }
        return BinaryContent.Create(InternalRealtimeAzureSemanticVadTurnDetection, ModelSerializationExtensions.WireOptions);
    }

    public static explicit operator InternalRealtimeAzureSemanticVadTurnDetection(ClientResult result)
    {
        using PipelineResponse response = result.GetRawResponse();
        using JsonDocument document = JsonDocument.Parse(response.Content);
        return DeserializeInternalRealtimeAzureSemanticVadTurnDetection(document.RootElement, ModelSerializationExtensions.WireOptions);
    }

    private static void DeserializeMillisecondDuration(JsonProperty property, ref TimeSpan? duration)
    {
        if (property.Value.ValueKind == JsonValueKind.Number)
        {
            duration = TimeSpan.FromMilliseconds(property.Value.GetInt32());
        }
    }

    private void SerializePrefixPaddingMs(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        SerializeMillisecondDuration(writer, PrefixPaddingMs);
    }

    private void SerializeSilenceDurationMs(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        SerializeMillisecondDuration(writer, SilenceDurationMs);
    }

    private static void SerializeMillisecondDuration(Utf8JsonWriter writer, TimeSpan? duration)
    {
        if (duration.HasValue)
        {
            writer.WriteNumberValue((int)duration.Value.TotalMilliseconds);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
