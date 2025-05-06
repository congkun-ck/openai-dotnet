using System;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenType("RealtimeTurnDetection")]
public partial class ConversationTurnDetectionOptions
{
    [CodeGenMember("Kind")]
    public ConversationTurnDetectionKind Kind { get; internal protected set; }

    public static ConversationTurnDetectionOptions CreateDisabledTurnDetectionOptions()
    {
        return new InternalRealtimeNoTurnDetection();
    }

    public static ConversationTurnDetectionOptions CreateServerVoiceActivityTurnDetectionOptions(
        float? detectionThreshold = null,
        TimeSpan? prefixPaddingDuration = null,
        TimeSpan? silenceDuration = null,
        bool? enableAutomaticResponseCreation = null)
    {
        return new InternalRealtimeServerVadTurnDetection()
        {
            Threshold = detectionThreshold,
            PrefixPaddingMs = prefixPaddingDuration,
            SilenceDurationMs = silenceDuration,
            CreateResponse = enableAutomaticResponseCreation,
        };
    }

    public static ConversationTurnDetectionOptions CreateAzureSemanticVadTurnDetectionOptions(
        float? detectionThreshold = null,
        TimeSpan? prefixPaddingDuration = null,
        TimeSpan? silenceDuration = null,
        bool? enableAutomaticResponseCreation = null,
        bool? removeFillerWords = null,
        EndOfUtteranceDetection endOfUtteranceDetection = null
        )
    {
        return new InternalRealtimeAzureSemanticVadTurnDetection()
        {
            Threshold = detectionThreshold,
            PrefixPaddingMs = prefixPaddingDuration,
            SilenceDurationMs = silenceDuration,
            CreateResponse = enableAutomaticResponseCreation,
            RemoveFillerWords = removeFillerWords,
            EndOfUtteranceDetection = endOfUtteranceDetection
        };
    }
}