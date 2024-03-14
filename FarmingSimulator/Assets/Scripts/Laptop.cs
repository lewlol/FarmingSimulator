using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    bool canOpen;
    public GameObject laptopMenu;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canOpen = true;

            //Check if Open to Stop Both Being Opened
            other.GetComponent<Inventory>().canOpen = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = false;
            other.GetComponent<Inventory>().canOpen = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            laptopMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            CustomEventSystem.customEventSystem.TurnOffPlayerUI(false);
        }
    }
}
