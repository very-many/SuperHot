using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class ControllTime : MonoBehaviour
{
    public ControllerAngularVelocity rightController;
    public ControllerAngularVelocity leftController;

    public ControllerAngularVelocity head;

    public Volume postProcessing;

    //higher number = less movement;
    //public float sensitivity = 10;

    public float sensitivity = 0.8f;

    //higher number = more movement
    //public float headMultiplier = 250f;

    public float minTimeScale = 0.05f;


    void Update()
    {
        var rightHandVelocity = rightController.Velocity;
        var leftHandVelocity = leftController.Velocity;
        var headVelocity = head.Velocity;

        //var totalVelocity = rightHandVelocity.magnitude + leftHandVelocity.magnitude + (headVelocity.magnitude * headMultiplier);
        var totalVelocity = rightHandVelocity.magnitude + leftHandVelocity.magnitude + headVelocity.magnitude;

        //Time.timeScale = totalVelocity / sensitivity;
        Time.timeScale = Mathf.Clamp01(minTimeScale + totalVelocity * sensitivity);
        if (postProcessing.profile.TryGet<ChromaticAberration>(out var chromaticAberration))
        {
            chromaticAberration.intensity.overrideState = true;
            chromaticAberration.intensity.value = 1 - Time.timeScale;
        }
        //0.02f bc 1/50 -> So dass unser physics shit trotz slomo mit 50hz läuft
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
