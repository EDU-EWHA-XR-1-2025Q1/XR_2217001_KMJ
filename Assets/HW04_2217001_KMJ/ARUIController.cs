using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ARUIController : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject fireButtonGroup; // FireButton GameObject 자체 (Button 컴포넌트 아님)
    public GameObject putRepoObject;

    public ObserverBehaviour imageTarget;

    void Start()
    {
        SetAllActive(false);

        if (imageTarget != null)
            imageTarget.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

        if (!isTracked)
        {
            SetAllActive(false);
            return;
        }

        if (putRepoObject != null)
            putRepoObject.SetActive(true);

        if (crosshair != null)
            crosshair.SetActive(true);

        if (fireButtonGroup != null)
            fireButtonGroup.SetActive(true);
    }

    private void SetAllActive(bool isActive)
    {
        if (crosshair != null)
            crosshair.SetActive(isActive);

        if (fireButtonGroup != null)
            fireButtonGroup.SetActive(isActive);

        if (putRepoObject != null)
            putRepoObject.SetActive(isActive);
    }
}

