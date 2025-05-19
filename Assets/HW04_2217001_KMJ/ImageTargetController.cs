using UnityEngine;
using Vuforia;

public class ImageTargetController : MonoBehaviour
{
    public GameObject uiGroup; // UI 그룹 GameObject

    void Start()
    {
        ObserverBehaviour observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        if (uiGroup != null)
        {
            uiGroup.SetActive(false); // 초기에는 비활성화
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (uiGroup != null)
        {
            bool isTracked = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;
            uiGroup.SetActive(isTracked);
        }
    }
}
