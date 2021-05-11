using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Collectables : MonoBehaviour
{
    public GameObject particle;

    public void Collect()
    {
        GameObject part = Instantiate(particle, transform);
        Destroy(part, 0.5f);
        
        this.gameObject.SetActive(false);
    }
   



}
