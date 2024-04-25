using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimumFeedback : RealtimeComponent<MinimumFeedbackModel>
{
    private bool _didLobbyEnd;
    private int _player1Rating;
    private int _player2Rating;

    private void Awake()
    {
        _didLobbyEnd = false;
        _player1Rating = 0;
        _player2Rating = 0;
    }

    protected override void OnRealtimeModelReplaced(MinimumFeedbackModel previousModel, MinimumFeedbackModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.player1RatingDidChange -= Player1RatingDidChange;
            previousModel.player2RatingDidChange -= Player2RatingDidChange;
            previousModel.didLobbyEndDidChange -= DidLobbyEndDidChange;
        }
        if (currentModel.isFreshModel)
        {
            currentModel.player1Rating = _player1Rating;
            currentModel.player2Rating = _player2Rating;
            currentModel.didLobbyEnd = _didLobbyEnd;
        }

        UpdatePlayer1Rating();
        UpdatePlayer2Rating();
        UpdateDidLobbyEnd();

        currentModel.player1RatingDidChange += Player1RatingDidChange;
        currentModel.player2RatingDidChange += Player2RatingDidChange;
        currentModel.didLobbyEndDidChange += DidLobbyEndDidChange;
    }

    private void Player1RatingDidChange(MinimumFeedbackModel model, int player1Rating)
    {
        UpdatePlayer1Rating();
    }

    private void Player2RatingDidChange(MinimumFeedbackModel model, int player2Rating)
    {
        UpdatePlayer2Rating();
    }

    private void DidLobbyEndDidChange(MinimumFeedbackModel model, bool didLobbyEnd)
    {
        UpdateDidLobbyEnd();
    }

    private void UpdatePlayer1Rating()
    {
        _player1Rating = model.player1Rating;
    }

    private void UpdatePlayer2Rating()
    {
        _player2Rating = model.player2Rating;
    }

    private void UpdateDidLobbyEnd()
    {
        _didLobbyEnd = model.didLobbyEnd;
    }

    // =============================== getters and setters =====================================
    public void SetPlayer1Rating(int player1Rating)
    {
        model.player1Rating = player1Rating;
    }

    public int GetPlayer1Rating()
    {
        return model.player1Rating;
    }

    public void SetPlayer2Rating(int player2Rating)
    {
        model.player2Rating = player2Rating;
    }

    public int GetPlayer2Rating()
    {
        return model.player2Rating;
    }

    public void SetDidLobbyEnd(bool didLobbyEnd)
    {
        model.didLobbyEnd = didLobbyEnd;
    }

    public bool GetDidLobbyEnd()
    {
        return model.didLobbyEnd;
    }
}
