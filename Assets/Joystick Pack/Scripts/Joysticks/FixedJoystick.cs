using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{

    public override void OnPointerDown(PointerEventData eventData)
    {
        Airplane.pionterdown = false;
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Airplane.pionterdown = true;
        base.OnPointerUp(eventData);
    }
}