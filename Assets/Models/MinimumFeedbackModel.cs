using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class MinimumFeedbackModel
{
    [RealtimeProperty(1, true, true)] private bool _didLobbyEnd;
    [RealtimeProperty(2, true, true)] private int _player1Rating;
    [RealtimeProperty(3, true, true)] private int _player2Rating;
}