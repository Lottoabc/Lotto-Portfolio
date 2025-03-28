using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using System;

public class GameManager : Singleton<GameManager> //����̳�Singleton����������ʹ���Ϊһ��������
{
    // �����Ӧ����Ϸ����
    public GameObject[] Floors;
    // ǽ���Ӧ����Ϸ����
    public GameObject[] Walls;

    // ����Ӧ�ĵ������
    public Material[] FloorStyleMats;

    // ����Ӧ��ǽ�����
    public Material[] WallStyleMats;

    //BGM�Ŀ���
    public AudioSource BGM_control;

    public Volume postProcesslingVolume;    //post processing Volume������
    private WhiteBalance whiteBalance;  //��ƽ����Ч
    private ColorAdjustments colorAdjustments;  //��ɫ����

    //HideInInspector��ʾ��ԭ����ʾ������ϵ����л�ֵ��������
    [HideInInspector] public float defaultTemperature;  //Ĭ��ɫ��
    [HideInInspector] public float defaultHue;  //Ĭ��ɫ��
    [HideInInspector] public float defaultExposure; //Ĭ���ع�
    [HideInInspector] public float defaultStatuation;   //Ĭ�ϱ��Ͷ�


    // Start is called before the first frame update
    void Start()
    {
        initPostProcessingData();
    }
    /*
    private void initPostProcessingData()   //��ȡPostProcessing Volume�е�White Balance��Color Adjustments��Ч����
    {
        postProcesslingVolume.profile.TryGet(out whiteBalance);
        postProcesslingVolume.profile.TryGet(out colorAdjustments);
    }
    */

    private void initPostProcessingData()      //Ĭ��ֵ����
    {
        postProcesslingVolume.profile.TryGet(out whiteBalance);     //��ȡwhiteBalance�е�ֵ
        postProcesslingVolume.profile.TryGet(out colorAdjustments);

        defaultTemperature = whiteBalance.temperature.value;
        defaultHue = colorAdjustments.hueShift.value;
        defaultExposure = colorAdjustments.postExposure.value;
        defaultStatuation = colorAdjustments.postExposure.value;
    }
    public void OnInfoButtonClick() 
    {
        if (BGM_control.isPlaying)
        {
            BGM_control.Pause(); // ��ͣ����
        }
        else
        {
            BGM_control.UnPause();  //��ʼ����
        }
    }


    /// <summary>
    /// �л�����ݵķ�񣬵����ݲ���Ϊ0ʱ��ʹ�õ�һ�ײ��ʷ�����������Ϊ1ʱ��ʹ�õڶ��ײ��ʷ���
    /// </summary>
    /// <param name="styleIndex">������</param>
    public void ChangeStyle(int styleIndex)
    {
        // ��Ұ���ݺ���
        SteamVR_Fade.View(Color.black, 0);
        SteamVR_Fade.View(Color.clear, 1);
        //��������Ҫ�л����ʵĵذ���Ϸ�������õذ����
        foreach (GameObject floor in Floors)
        {
            floor.GetComponent<MeshRenderer>().material = FloorStyleMats[styleIndex];
        }

        // ��������Ҫ�л����ʵ�ǽ����Ϸ��������ǽ�����
        foreach (GameObject wall in Walls)
        {
            wall.GetComponent<MeshRenderer>().material = WallStyleMats[styleIndex];
        }
    }

    public void ChangeStustion(float value)
    {  //��ȡ���ڵ���Ч  ָ��Ҫ����������  ���ݻ�ȡ����valueֵ
        colorAdjustments.saturation.Override(value);
    }

    public void ChangeExposure(float value)
    {
        colorAdjustments.postExposure.Override(value);
    }

    public void ChangeHue(float value)
    {
        colorAdjustments.hueShift.Override(value);
    }

    public void ChangeTemperature(float value)
    { //����ǰ������ͬ��ɫ�����ڰ�ƽ����Ч֮�µģ���������Ҫ�ı�Ϊ��ƽ��
        whiteBalance.temperature.Override(value);
    }
    

    public void ResetPostProcessing()       //��ֵ����ΪĬ��ֵ
    {
        whiteBalance.temperature.Override(defaultTemperature);
        colorAdjustments.hueShift.Override(defaultHue);
        colorAdjustments.postExposure.Override(defaultExposure);
        colorAdjustments.saturation.Override(defaultStatuation);
    }
}
