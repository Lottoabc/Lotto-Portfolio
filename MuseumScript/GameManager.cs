using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using System;

public class GameManager : Singleton<GameManager> //让其继承Singleton并给定自身，使其变为一个单例类
{
    // 地面对应的游戏对象
    public GameObject[] Floors;
    // 墙面对应的游戏对象
    public GameObject[] Walls;

    // 风格对应的地面材质
    public Material[] FloorStyleMats;

    // 风格对应的墙面材质
    public Material[] WallStyleMats;

    //BGM的开关
    public AudioSource BGM_control;

    public Volume postProcesslingVolume;    //post processing Volume的引用
    private WhiteBalance whiteBalance;  //白平衡特效
    private ColorAdjustments colorAdjustments;  //颜色调整

    //HideInInspector表示将原本显示在面板上的序列化值隐藏起来
    [HideInInspector] public float defaultTemperature;  //默认色温
    [HideInInspector] public float defaultHue;  //默认色调
    [HideInInspector] public float defaultExposure; //默认曝光
    [HideInInspector] public float defaultStatuation;   //默认饱和度


    // Start is called before the first frame update
    void Start()
    {
        initPostProcessingData();
    }
    /*
    private void initPostProcessingData()   //获取PostProcessing Volume中的White Balance和Color Adjustments特效引用
    {
        postProcesslingVolume.profile.TryGet(out whiteBalance);
        postProcesslingVolume.profile.TryGet(out colorAdjustments);
    }
    */

    private void initPostProcessingData()      //默认值函数
    {
        postProcesslingVolume.profile.TryGet(out whiteBalance);     //获取whiteBalance中的值
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
            BGM_control.Pause(); // 暂停音乐
        }
        else
        {
            BGM_control.UnPause();  //开始音乐
        }
    }


    /// <summary>
    /// 切换博物馆的风格，当传递参数为0时，使用第一套材质方案，当参数为1时，使用第二套材质方案
    /// </summary>
    /// <param name="styleIndex">风格序号</param>
    public void ChangeStyle(int styleIndex)
    {
        // 视野短暂黑屏
        SteamVR_Fade.View(Color.black, 0);
        SteamVR_Fade.View(Color.clear, 1);
        //遍历所有要切换材质的地板游戏对象，设置地板材质
        foreach (GameObject floor in Floors)
        {
            floor.GetComponent<MeshRenderer>().material = FloorStyleMats[styleIndex];
        }

        // 遍历所有要切换材质的墙面游戏对象，设置墙面材质
        foreach (GameObject wall in Walls)
        {
            wall.GetComponent<MeshRenderer>().material = WallStyleMats[styleIndex];
        }
    }

    public void ChangeStustion(float value)
    {  //获取所在的特效  指定要调整的属性  传递获取到的value值
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
    { //与先前三个不同，色温是在白平衡特效之下的，所以引用要改变为白平衡
        whiteBalance.temperature.Override(value);
    }
    

    public void ResetPostProcessing()       //对值重载为默认值
    {
        whiteBalance.temperature.Override(defaultTemperature);
        colorAdjustments.hueShift.Override(defaultHue);
        colorAdjustments.postExposure.Override(defaultExposure);
        colorAdjustments.saturation.Override(defaultStatuation);
    }
}
