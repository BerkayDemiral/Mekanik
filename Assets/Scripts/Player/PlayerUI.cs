using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI prompText;

    void Start()
    {
        
    }

    public void UpdateText(string PromptMessage)
    {
        prompText.text = PromptMessage;
    }

}
