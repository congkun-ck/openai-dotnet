// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Responses
{
    public partial class ComputerCallAction : IJsonModel<ComputerCallAction>
    {
        internal ComputerCallAction()
        {
        }

        void IJsonModel<ComputerCallAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ComputerCallAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputerCallAction)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Kind.ToSerialString());
            }
            if (_additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ComputerCallAction IJsonModel<ComputerCallAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ComputerCallAction JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ComputerCallAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputerCallAction)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeComputerCallAction(document.RootElement, options);
        }

        internal static ComputerCallAction DeserializeComputerCallAction(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("type"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "click":
                        return InternalResponsesComputerCallClickAction.DeserializeInternalResponsesComputerCallClickAction(element, options);
                    case "double_click":
                        return InternalResponsesComputerCallDoubleClickAction.DeserializeInternalResponsesComputerCallDoubleClickAction(element, options);
                    case "scroll":
                        return InternalResponsesComputerCallScrollAction.DeserializeInternalResponsesComputerCallScrollAction(element, options);
                    case "screenshot":
                        return InternalResponsesComputerCallScreenshotAction.DeserializeInternalResponsesComputerCallScreenshotAction(element, options);
                    case "type":
                        return InternalResponsesComputerCallTypeAction.DeserializeInternalResponsesComputerCallTypeAction(element, options);
                    case "wait":
                        return InternalResponsesComputerCallWaitAction.DeserializeInternalResponsesComputerCallWaitAction(element, options);
                    case "keypress":
                        return InternalResponsesComputerCallKeyPressAction.DeserializeInternalResponsesComputerCallKeyPressAction(element, options);
                    case "drag":
                        return InternalResponsesComputerCallDragAction.DeserializeInternalResponsesComputerCallDragAction(element, options);
                    case "move":
                        return InternalResponsesComputerCallMoveAction.DeserializeInternalResponsesComputerCallMoveAction(element, options);
                }
            }
            return UnknownResponsesComputerCallItemAction.DeserializeUnknownResponsesComputerCallItemAction(element, options);
        }

        BinaryData IPersistableModel<ComputerCallAction>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ComputerCallAction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ComputerCallAction)} does not support writing '{options.Format}' format.");
            }
        }

        ComputerCallAction IPersistableModel<ComputerCallAction>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ComputerCallAction PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ComputerCallAction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeComputerCallAction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ComputerCallAction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ComputerCallAction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ComputerCallAction computerCallAction)
        {
            if (computerCallAction == null)
            {
                return null;
            }
            return BinaryContent.Create(computerCallAction, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ComputerCallAction(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeComputerCallAction(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
