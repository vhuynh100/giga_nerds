using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class PlayerFeedbackModel
{
    [RealtimeProperty(1, true, true)] private string _player1Goal;
    [RealtimeProperty(2, true, true)] private string _player2Goal;
    [RealtimeProperty(3, true, true)] private string _player1Feedback;
    [RealtimeProperty(4, true, true)] private string _player2Feedback;
}
