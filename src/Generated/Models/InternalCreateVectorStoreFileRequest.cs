// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.VectorStores
{
    internal partial class InternalCreateVectorStoreFileRequest
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalCreateVectorStoreFileRequest(string fileId)
        {
            Argument.AssertNotNull(fileId, nameof(fileId));

            FileId = fileId;
        }

        internal InternalCreateVectorStoreFileRequest(string fileId, InternalVectorStoreFileAttributes attributes, FileChunkingStrategy chunkingStrategy, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            FileId = fileId;
            Attributes = attributes;
            ChunkingStrategy = chunkingStrategy;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string FileId { get; }

        public InternalVectorStoreFileAttributes Attributes { get; set; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
