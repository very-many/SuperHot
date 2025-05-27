using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAngularVelocity : MonoBehaviour
{
    public InputActionProperty velocityProperty;

    public Vector3 Velocity { get; private set; } = Vector3.zero;

    private void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
    }
}
