using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScaleReduce : MonoBehaviour
{
    private XRSimpleInteractable xrSimpleInteractable;
    // Start is called before the first frame update
    void Start()
    {
        xrSimpleInteractable = GetComponent<XRSimpleInteractable>();
        xrSimpleInteractable.selectEntered.AddListener(ScaleIncreasing);
        xrSimpleInteractable.selectExited.AddListener(ScaleDecreasing);
    }

    private void ScaleDecreasing(SelectExitEventArgs arg0)
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }

    private void ScaleIncreasing(SelectEnterEventArgs arg0)
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
