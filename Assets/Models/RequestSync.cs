using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSync : RealtimeComponent<RequestSyncModel>
{
    //private RequestSyncModel _requestSyncModel;// here
    private string _translation;

    private void Awake()
    {
        //_translation = GetComponent<string>();
    }



    protected override void OnRealtimeModelReplaced(RequestSyncModel previousModel, RequestSyncModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.translationDidChange -= TranslationStringDidChange;
        }
        if (currentModel.isFreshModel)
        { // probably change this maybe perhaps possibly
            currentModel.translation = _translation;
        }

        UpdateTranslationString();

        currentModel.translationDidChange += TranslationStringDidChange;
    }

    private void TranslationStringDidChange(RequestSyncModel model, string translationString)
    {
        UpdateTranslationString();
    }

    private void UpdateTranslationString()
    {

        _translation = model.translation;
        //model.translation = translationString.text; // this may be wrong
    }

    public void SetTranslation(string translation)
    {
        model.translation = translation;
    }

    public string GetTranslation()
    {
        return model.translation;
    }



}
