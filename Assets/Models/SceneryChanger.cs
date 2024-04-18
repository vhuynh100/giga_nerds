using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryChanger : RealtimeComponent<SceneryChangerModel>
{
    private string _sceneryName;

    private void Awake()
    {
        //_translation = GetComponent<string>();
        _sceneryName = "lobby";
    }

    protected override void OnRealtimeModelReplaced(SceneryChangerModel previousModel, SceneryChangerModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.sceneryNameDidChange -= SceneryNameDidChange;
        }
        if (currentModel.isFreshModel)
        {
            currentModel.sceneryName = _sceneryName;
        }

        UpdateSceneryName();

        currentModel.sceneryNameDidChange += SceneryNameDidChange;
    }

    private void SceneryNameDidChange(SceneryChangerModel model, string translationString)
    {
        UpdateSceneryName();
    }



    private void UpdateSceneryName()
    {
        _sceneryName = model.sceneryName;
    }

    public void SetSceneryName(string sceneryName)
    {
        model.sceneryName = sceneryName;
    }

    public string GetSceneryName()
    {
        return model.sceneryName;
    }

    

}
