using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinousMovement : MonoBehaviour
{
    public float speed = 1;
    public float gravity = -9.81f * 10;
    private float fallingSpeed;
    public XRNode inputSource;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;
    public LayerMask groundLayer;

    public float additionHeight = 0.2f;


    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        CapFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        //Gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
            character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
            if(fallingSpeed >= 240f)
            {
                fallingSpeed = 240f;
            }
        }
        
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;

        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hit, rayLength, groundLayer);

        return hasHit;
    }

    void CapFollowHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight + additionHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);

        capsuleCenter = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);

    }
}
