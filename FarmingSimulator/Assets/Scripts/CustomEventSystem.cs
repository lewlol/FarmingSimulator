using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventSystem : MonoBehaviour
{
    public static CustomEventSystem customEventSystem;

    private void Start()
    {
        customEventSystem = this;
    }

    public event Action OnTickEvent;
    public void TickEvent()
    {
        if(OnTickEvent != null)
        {
            OnTickEvent();
        }
    }
}
