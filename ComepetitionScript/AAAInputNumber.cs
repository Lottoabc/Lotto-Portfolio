using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AAAInputNumber : MonoBehaviour
{
    public static AAAManager Manager;

    private void Awake()
    {
        Manager = FindObjectOfType<AAAManager>();
    }

    public void ConveyNumber()
    {
        Debug.Log("Received!" + transform.name);
        Manager.ConveyNumber(transform.name);
    }
}
