using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class LightController : MonoBehaviour
{
    public Light Mylight;   //�ƹ�
    private XRLever lever;  //����

    // Start is called before the first frame update
    void Start()
    {
        Mylight.enabled = false;
        lever = GetComponent<XRLever>();
        lever.onLeverActivate.AddListener(onLeverActive);
        lever.onLeverDeactivate.AddListener(onLeverDeactivate);
    }

    private void onLeverDeactivate()
    {
      Mylight.enabled =true;
    }

    private void onLeverActive()
    {
        Mylight.enabled=false;
    }
}
