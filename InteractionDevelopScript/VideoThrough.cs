using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;

public class VideoThrough : MonoBehaviour
{
    private void Awake()
    {
        PXR_MixedReality.EnableVideoSeeThroughEffect(true); //使透视功能被打开
    }

    private void OnApplicationPause(bool pause)     //对非暂停的游戏,再启动透视
    {
        if(!pause)
        {
            PXR_MixedReality.EnableVideoSeeThroughEffect(true);     
        }
    }
}
