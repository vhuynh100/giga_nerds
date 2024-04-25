using Normal.Realtime;
using UnityEngine;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction;
using Unity.VisualScripting;

public class RequestOwnership : MonoBehaviour
{
    [SerializeField] private RealtimeView realtimeView;
    [SerializeField] private RealtimeTransform realtimeTransform;
    [SerializeField] private InteractableUnityEventWrapper wrapper;
    
    private void OnEnable()
    {
        wrapper.WhenSelect.AddListener(RequestObjectOwnership);
    }

    
    private void RequestObjectOwnership()
    {
        realtimeView.RequestOwnership();
        realtimeTransform.RequestOwnership();
    }
    private void OnDisable()
    {
        wrapper.WhenUnselect.RemoveListener(RequestObjectOwnership);
    }
}