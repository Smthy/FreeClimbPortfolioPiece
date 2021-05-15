using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hands : MonoBehaviour
{
    public bool showController = false;
    
    public InputDeviceCharacteristics controllerChar;

    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;

    public GameObject handPrefab;
    private GameObject spawnedHandModel;
    private GameObject spawned;
    private Animator handAnimator;

    public CheckPoint checkpoint;

    public GameObject checkPointObject;
    void Start()
    {
        checkPointObject.SetActive(false);
        Try();
    }

    void Try()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerChar, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawned = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("No controller");
                spawned = Instantiate(controllerPrefabs[1], transform);
            }

            spawnedHandModel = Instantiate(handPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }
    /*
    void UpdateAnimator()
    {
        
    }
    */

    void FixedUpdate()
    {
        if (!targetDevice.isValid)
        {
            Try();
        }
        else
        {
            if (showController)
            {
                spawned.SetActive(true);
                spawnedHandModel.SetActive(false);
            }
            else
            {
                spawned.SetActive(false);
                spawnedHandModel.SetActive(true);                
                //UpdateAnimator();
                GameInputs();
            }
        }
    }

    void GameInputs()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);

        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondary))
        {           
            if(secondary)
            {
                Debug.Log("B Pressed: " + secondary + "\n");
                checkPointObject.SetActive(true);                
            }
            if (!secondary)
            {
                checkPointObject.SetActive(false);
            }
        }
    }  
}
