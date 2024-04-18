
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class MatchMakingModel
{
    [RealtimeProperty(1, true, true)] private RealtimeDictionary<LobbyModel> _lobbies;
    [RealtimeProperty(2, true, true)] private RealtimeDictionary<SpanishSpeakerModel> _unpairedSpanishSpeakers;
    [RealtimeProperty(3, true, true)] private RealtimeDictionary<EnglishSpeakerModel> _unpairedEnglishSpeakers;

    [RealtimeProperty(4, true, true)] private RealtimeDictionary<SpanishSpeakerModel> _pairedSpanishSpeakers;
    [RealtimeProperty(5, true, true)] private RealtimeDictionary<EnglishSpeakerModel> _pairedEnglishSpeakers;
}