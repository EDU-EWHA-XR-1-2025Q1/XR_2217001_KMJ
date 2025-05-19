using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pickCountText;
    public TextMeshProUGUI putCountText;
    public Button fireButton;

    void Start()
    {
        
        if (fireButton != null)
            fireButton.interactable = false;

        UpdateUI(); 
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {

        if (GameManager.Instance == null)
            return; 


        pickCountText.text = "Pick Count: " + GameManager.Instance.pickCount;
        putCountText.text = "Put Count: " + GameManager.Instance.putCount;

        if (fireButton != null)
        {
            bool shouldEnable = GameManager.Instance.pickCount > 0;
            
            if (fireButton.interactable != shouldEnable)
                fireButton.interactable = shouldEnable;
        }
    }
}




