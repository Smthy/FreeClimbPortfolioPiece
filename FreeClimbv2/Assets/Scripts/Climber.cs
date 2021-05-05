using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHands;
    private ContinousMovement continousMovement;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        continousMovement = GetComponent<ContinousMovement>();

    }

    private void FixedUpdate()
    {
        if(climbingHands)
        {
            continousMovement.enabled = false;
            Climb();
        }
        else
        {
            continousMovement.enabled = true;
        }

    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHands.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
        
    }
}
