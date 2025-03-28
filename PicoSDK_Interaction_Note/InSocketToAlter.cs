using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class InSocketToAlter : MonoBehaviour
{
    public GameObject UIMenu;                       //UI组件
    private XRGrabInteractable xrGrabInteractable;  //声明一个Interactable用户获取
    private bool isGrabBySocket = false;            //布尔值用于判断组件的状态

    private void Start()
    {
        UIMenu.SetActive(false);
        xrGrabInteractable = GetComponent<XRGrabInteractable>();            //获取Interactable组件
        xrGrabInteractable.activated.AddListener(onActivated);              //分别添加不同状态下的事件
        xrGrabInteractable.selectEntered.AddListener(onSelectedEntered);
        xrGrabInteractable.selectExited.AddListener(onSelectedExited);
    }

    private void onSelectedExited(SelectExitEventArgs arg0) 
    {
        if(arg0.interactorObject is XRSocketInteractor)     //当离开了选择状态时, 将isGrabBySocket为false
        {
            isGrabBySocket = false;
            if(UIMenu.activeSelf)
            {
                HideMenu();
            }
        }
    }

    private void onSelectedEntered(SelectEnterEventArgs arg0)
    {
        if(arg0.interactorObject is XRSocketInteractor)     //当返回的值为XRSocketInteractor时
        {
            isGrabBySocket = true;
        }
    }

    private void onActivated(ActivateEventArgs arg0)
    {
        if(!isGrabBySocket)     //如果游戏对象没有被防止Socket当中
        {                       //以下的逻辑也就不执行,直接返回
            return;
        }
        
        if(UIMenu.activeSelf)   //activeSelf可以用来判断UI是否显示
        {
            HideMenu();
        }

        else
        {
            ShowMenu();
        }
    }

    //控制Menu进行显示与隐藏
    private void ShowMenu()
    {
        UIMenu.SetActive(true);
        UIMenu.transform.localScale = Vector3.zero;      //先令UI的缩放为0,便于缓动效果
        UIMenu.transform.DOScale(Vector3.one * 0.005f,  //之后利用DOScale设置缩放倍率, 并选择缩放时间和效果
            0.3f).SetEase(Ease.OutBack);
    }

    private void HideMenu()
    {
        UIMenu.transform.DOScale(Vector3.zero,                  //使用DOScale来控制组件的缩放
            0.3f).SetEase(Ease.InBack).OnComplete(delegate ()   //令其缩放为0,在0.3秒内,而SetEase用于设置缓动的类型
        {
            UIMenu.SetActive(false);                            //在匿名函数中令UIMenu取消启用
        });
    }
}
