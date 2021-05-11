using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandedClimbSystem : MonoBehaviour
{
    private CharacterController character;

    public static XRController leftHandController, rightHandController;
    private ContinousMovement continousMovement;
    Vector3 velocity;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        continousMovement = GetComponent<ContinousMovement>();

    }

    private void FixedUpdate()
    {
        if(leftHandController || rightHandController)
        {
            continousMovement.enabled = false;
            ClimbUsingHands();
        }
        else
        {
            continousMovement.enabled = true;
        }
    }

    void ClimbUsingHands()
    {
        if(leftHandController)
        {
            Debug.Log("HAND LEFT");


            InputDevices.GetDeviceAtXRNode(leftHandController.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out velocity);
            character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
        }
        else if(rightHandController)
        {
            Debug.Log("HAND Right");


            InputDevices.GetDeviceAtXRNode(rightHandController.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out velocity);
            character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
        }
    }
}
