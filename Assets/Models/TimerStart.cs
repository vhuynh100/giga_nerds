using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStart : RealtimeComponent<TimerStartModel>
{
    private bool _player1Ready;
    private bool _player2Ready;
    private float _timerDuration;

    private void Awake()
    {
        _player1Ready = false;
        _player2Ready = false;
        _timerDuration = 0;
        //_timerDuration = GetTimerDuration();
    }

    protected override void OnRealtimeModelReplaced(TimerStartModel previousModel, TimerStartModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.player1ReadyDidChange -= Player1ReadyDidChange;
            previousModel.player2ReadyDidChange -= Player2ReadyDidChange;
            previousModel.timerDurationDidChange -= TimerDurationDidChange;
        }
        if (currentModel.isFreshModel)
        {
            currentModel.player1Ready = _player1Ready;
            currentModel.player2Ready = _player2Ready;
            currentModel.timerDuration = _timerDuration;
        }

        UpdatePlayer1Ready();
        UpdatePlayer2Ready();
        UpdateTimerDuration();

        currentModel.player1ReadyDidChange += Player1ReadyDidChange;
        currentModel.player2ReadyDidChange += Player2ReadyDidChange;
        currentModel.timerDurationDidChange += TimerDurationDidChange;
    }

    private void Player1ReadyDidChange(TimerStartModel model, bool player1Ready)
    {
        UpdatePlayer1Ready();
    }

    private void Player2ReadyDidChange(TimerStartModel model, bool player2Ready)
    {
        UpdatePlayer2Ready();
    }

    private void TimerDurationDidChange(TimerStartModel model, float timerDuration)
    {
        UpdateTimerDuration();
    }

    private void UpdatePlayer1Ready()
    {
        _player1Ready = model.player1Ready;
    }

    private void UpdatePlayer2Ready()
    {
        _player2Ready = model.player2Ready;
    }
    private void UpdateTimerDuration()
    {
        _timerDuration = model.timerDuration;
    }

    public void SetPlayer1Ready(bool ready)
    {
        model.player1Ready = ready;
    }

    public bool GetPlayer1Ready()
    {
        return model.player1Ready;
    }

    public void SetPlayer2Ready(bool ready)
    {
        model.player2Ready = ready;
    }

    public bool GetPlayer2Ready()
    {
        return model.player2Ready;
    }


    public void SetTimerDuration(float duration)
    {
        model.timerDuration = duration;
    }

    public float GetTimerDuration()
    {
        return model.timerDuration;
    }


}
