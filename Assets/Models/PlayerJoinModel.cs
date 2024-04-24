using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class PlayerJoinModel
{
    [RealtimeProperty(1, true, true)] private bool _player1Join;
    [RealtimeProperty(2, true, true)] private bool _player2Join;
}