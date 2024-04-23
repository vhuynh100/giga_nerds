using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class TimerStartModel
{
    [RealtimeProperty(1, true, true)] private bool _player1Ready;
    [RealtimeProperty(2, true, true)] private bool _player2Ready;
    [RealtimeProperty(3, true, true)] private float _timerDuration;
}
