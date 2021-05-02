using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController TeleportRay;
    public InputHelpers.Button teleportActivation;
    public float activationThreshold = 0.05f;

    void Update()
    {
        if(TeleportRay)
        {
            TeleportRay.gameObject.SetActive(CheckIFActivated(TeleportRay));
        }
    }

    public bool CheckIFActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivation, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
