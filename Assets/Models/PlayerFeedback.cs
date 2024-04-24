using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedback : RealtimeComponent<PlayerFeedbackModel>
{
    private string _player1Goal;
    private string _player2Goal;
    private string _player1Feedback;
    private string _player2Feedback;

    private void Awake()
    {
        _player1Goal = "";
        _player2Goal = "";
        _player1Feedback = "";
        _player2Feedback = "";
    }

    protected override void OnRealtimeModelReplaced(PlayerFeedbackModel previousModel, PlayerFeedbackModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.player1GoalDidChange -= Player1GoalDidChange;
            previousModel.player2GoalDidChange -= Player2GoalDidChange;
            previousModel.player1FeedbackDidChange -= Player1FeedbackDidChange;
            previousModel.player2FeedbackDidChange -= Player2FeedbackDidChange;
        }
        if (currentModel.isFreshModel)
        {
            currentModel.player1Goal = _player1Goal;
            currentModel.player2Goal = _player2Goal;
            currentModel.player1Feedback = _player1Feedback;
            currentModel.player2Feedback = _player2Feedback;
        }

        UpdatePlayer1Goal();
        UpdatePlayer2Goal();
        UpdatePlayer1Feedback();
        UpdatePlayer2Feedback();

        currentModel.player1GoalDidChange += Player1GoalDidChange;
        currentModel.player2GoalDidChange += Player2GoalDidChange;
        currentModel.player1FeedbackDidChange += Player1FeedbackDidChange;
        currentModel.player2FeedbackDidChange += Player2FeedbackDidChange;
    }

    private void Player1GoalDidChange(PlayerFeedbackModel model, string player1Goal)
    {
        UpdatePlayer1Goal();
    }

    private void Player2GoalDidChange(PlayerFeedbackModel model, string player1Goal)
    {
        UpdatePlayer1Goal();
    }

    private void Player1FeedbackDidChange(PlayerFeedbackModel model, string player1Goal)
    {
        UpdatePlayer1Goal();
    }

    private void Player2FeedbackDidChange(PlayerFeedbackModel model, string player1Goal)
    {
        UpdatePlayer1Goal();
    }

    private void UpdatePlayer1Goal()
    {
        _player1Goal = model.player1Goal;
    }
    private void UpdatePlayer2Goal()
    {
        _player2Goal = model.player2Goal;
    }
    private void UpdatePlayer1Feedback()
    {
        _player1Feedback = model.player1Feedback;
    }
    private void UpdatePlayer2Feedback()
    {
        _player2Feedback = model.player2Feedback;
    }





    // ====================================== Getters and Setters ============================================

    public void SetPlayer1Goal(string goal)
    {
        model.player1Goal = goal;
    }

    public string GetPlayer1Goal()
    {
        return model.player1Goal;
    }

    public void SetPlayer2Goal(string goal)
    {
        model.player2Goal = goal;
    }

    public string GetPlayer2Goal()
    {
        return model.player2Goal;
    }

    public void SetPlayer1Feedback(string goal)
    {
        model.player1Feedback = goal;
    }

    public string GetPlayer1Feedback()
    {
        return model.player1Feedback;
    }

    public void SetPlayer2Feedback(string goal)
    {
        model.player2Feedback = goal;
    }

    public string GetPlayer2Feedback()
    {
        return model.player2Feedback;
    }






}
