using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticks : MonoBehaviour
{
    float tickSpeed = 0.1f;
    float c;
    private void Update()
    {
        float countdown = c -= Time.deltaTime;
        if(countdown <= 0)
        {
            c = tickSpeed;
            CustomEventSystem.customEventSystem.TickEvent();
        }
    }
}
