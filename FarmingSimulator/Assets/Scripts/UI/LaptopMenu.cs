using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopMenu : MonoBehaviour
{
    public GameObject plotMenu;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlotsMenu()
    {
        bool pMenu = !plotMenu.activeSelf;
        plotMenu.SetActive(pMenu);
    }

    public void TurnOffLaptop()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        CustomEventSystem.customEventSystem.TurnOffPlayerUI(true);
    }
}
