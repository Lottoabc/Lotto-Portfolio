using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR; //命名空间为Valve

public class ActionDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {                                //当按键抬起时的监听  可以按下快捷键Alt + Inter快捷键来创建监听处理函数  

        SteamVR_Actions.default_Fire.AddOnStateUpListener(FireActionStateUpHandler, SteamVR_Input_Sources.Any); //为引用到的动作添加状态的监听
        SteamVR_Actions.default_Fire.onStateUp += OnFireActionStateUp;             //指定动作发出的源头
        SteamVR_Actions.default_Squeeze.onAxis += OnSqueezeAxis;
        // onAxis这个事件监听是不为0时就执行
        
        //SteamVR_Actions.default_Fire.onStateUp 用于引用动作的事件，而这里将OnFireActionsStateUp这个事件处理函数赋给了它
          
    }

    private void OnSqueezeAxis(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
    {                                                           //newAxis是这个动作的坐标值  newDelta是一个改变值
        Debug.Log("当前的键程为：" + newAxis + "，先比之前改变了：" + newDelta);
    }

    private void OnFireActionStateUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("来自事件处理监听，由" + fromSource + "发出");
    }

    private void FireActionStateUpHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("来自状态监听，由" + fromSource + "发出");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {

        }

        if(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Fire").GetStateDown(SteamVR_Input_Sources.Any))
        {

        }
    }
}
