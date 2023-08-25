using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{
    public GameObject readyBtnGO;
    Button readyButton;

    void Awake()
    {
        readyButton = readyBtnGO.GetComponent<Button>();
        readyButton.onClick.AddListener(OnReady);
    }

    public void OnReady()
    {
        
    }
}
