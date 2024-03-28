using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class NormalSceneLoader : MonoBehaviour
{
    private Realtime _realtime;
    [SerializeField] private string roomName = "Classroom";
    [SerializeField] private int sceneIndex = 0;

    public bool isLoading;

    public void LoadScene()
    {
        if (isLoading) return;
        isLoading = true;

        if (_realtime == null)
            _realtime = FindObjectOfType<Realtime>();

        if (_realtime != null)
        {
            _realtime.Disconnect();
            _realtime = null;
        }

        SceneManager.LoadScene(sceneIndex);

        _realtime = FindObjectOfType<Realtime>();
        if (_realtime != null)
        {
            _realtime.Connect(roomName);
        }

        isLoading = false;
    }
}