using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;

public class HpticDemo : MonoBehaviour
{
    public void HpticTest()
    {
        PXR_Input.SendHapticImpulse(PXR_Input.VibrateType.BothController, 0.5f, 5000, 100);
    }
}
