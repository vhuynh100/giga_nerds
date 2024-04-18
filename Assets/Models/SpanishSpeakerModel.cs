using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;
using System.Numerics;
using UnityEngine.UIElements;

[RealtimeModel]
public partial class SpanishSpeakerModel
{
    [RealtimeProperty(1, true, true)] private uint _spanishSpeakerID;
    [RealtimeProperty(2, true, true)] private uint _lobbyID;
}