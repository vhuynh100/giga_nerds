using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoin : RealtimeComponent<PlayerJoinModel>
{
    private bool _player1Join;
    private bool _player2Join;

    private void Awake()
    {
        _player1Join = false;
        _player2Join = false;
    }

    protected override void OnRealtimeModelReplaced(PlayerJoinModel previousModel, PlayerJoinModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.player1JoinDidChange -= Player1JoinDidChange;
            previousModel.player2JoinDidChange -= Player2JoinDidChange;
        }
        if (currentModel.isFreshModel)
        {
            currentModel.player1Join = _player1Join;
            currentModel.player2Join = _player2Join;
        }

        UpdatePlayer1Join();
        UpdatePlayer2Join();

        currentModel.player1JoinDidChange += Player1JoinDidChange;
        currentModel.player2JoinDidChange += Player2JoinDidChange;
    }

    private void Player1JoinDidChange(PlayerJoinModel model, bool player1Join)
    {
        UpdatePlayer1Join();
    }

    private void Player2JoinDidChange(PlayerJoinModel model, bool player2Join)
    {
        UpdatePlayer2Join();
    }

    private void UpdatePlayer1Join()
    {
        _player1Join = model.player1Join;
    }

    private void UpdatePlayer2Join()
    {
        _player2Join = model.player2Join;
    }

    public void SetPlayer1JoinStatus(bool joinStatus)
    {
        model.player1Join = joinStatus;
    }

    public bool GetPlayer1JoinStatus()
    {
        return model.player1Join;
    }

    public void SetPlayer2JoinStatus(bool joinStatus)
    {
        model.player2Join = joinStatus;
    }

    public bool GetPlayer2JoinStatus()
    {
        return model.player2Join;
    }

    public void JoinPlayer()
    {
        if(model.player1Join == false)
        {
            model.player1Join = true;
        } else if (model.player2Join == false)
        {
            model.player2Join = true;
        }
    }

    public void RemovePlayer()
    {
        if(model.player1Join == true)
        {
            model.player1Join = false;
        } else if (  model.player2Join == true)
        {
            model.player2Join = false;
        }
    }
}
