using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSync : RealtimeComponent<RequestSyncModel>
{
    private string _translation;
    private bool _requested;

    private void Awake()
    {
        //_translation = GetComponent<string>();
        _requested = false;
    }

    protected override void OnRealtimeModelReplaced(RequestSyncModel previousModel, RequestSyncModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.translationDidChange -= TranslationStringDidChange;
            previousModel.requestedDidChange -= RequestedDidChange;
        }
        if (currentModel.isFreshModel)
        {
            currentModel.translation = _translation;
            currentModel.requested = _requested;
        }

        UpdateTranslationString();
        UpdateRequested();

        currentModel.translationDidChange += TranslationStringDidChange;
        currentModel.requestedDidChange += RequestedDidChange;
    }

    private void TranslationStringDidChange(RequestSyncModel model, string translationString)
    {
        UpdateTranslationString();
    }

    private void RequestedDidChange(RequestSyncModel model, bool requested)
    {
        UpdateTranslationString();
    }

    private void UpdateTranslationString()
    {
        _translation = model.translation;
    }

    private void UpdateRequested()
    {
        _requested = model.requested;
    }

    public void SetTranslation(string translation)
    {
        model.translation = translation;
    }

    public string GetTranslation()
    {
        return model.translation;
    }

    public void SetRequested(bool requested)
    {
        model.requested = requested;
    }

    public bool GetRequested()
    {
        return model.requested;
    }

}
