using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;

public class VideoThrough : MonoBehaviour
{
    private void Awake()
    {
        PXR_MixedReality.EnableVideoSeeThroughEffect(true); //ʹ͸�ӹ��ܱ���
    }

    private void OnApplicationPause(bool pause)     //�Է���ͣ����Ϸ,������͸��
    {
        if(!pause)
        {
            PXR_MixedReality.EnableVideoSeeThroughEffect(true);     
        }
    }
}
