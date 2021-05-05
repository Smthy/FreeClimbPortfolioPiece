using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController TeleportRay;
    public InputHelpers.Button teleportActivation;
    public float activationThreshold = 0.05f;

    public XRRayInteractor rightRay, leftRay;

    public bool enableTeleport { get; set; } = true;

    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();

        int index = 0;
        bool validTarget = false;

        if(TeleportRay)
        {
            bool hovering = rightRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
            TeleportRay.gameObject.SetActive(enableTeleport && CheckIFActivated(TeleportRay) && !hovering);
        }
    }

    public bool CheckIFActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivation, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
