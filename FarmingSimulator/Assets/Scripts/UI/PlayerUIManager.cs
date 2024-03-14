using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public GameObject playerUI;

    private void Start()
    {
        CustomEventSystem.customEventSystem.OnTurnOffPlayerUI += SwitchUI;
    }
    public void SwitchUI(bool on)
    {
        playerUI.SetActive(on);
    }
}
