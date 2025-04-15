using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateDemo : MonoBehaviour
{
    private XRSimpleInteractable interactable;  //用于存储当前的交互对象
    private bool isOpen;                        //用于标记当前盒子的开启状态
    private Animator animator;                  //引用到游戏对象上的Animator组件

    void Start()
    {
        //对两个组件进行获取
        interactable = GetComponent<XRSimpleInteractable>();
        animator = GetComponent<Animator>();
        interactable.selectEntered.AddListener(OnSelectEntered);    //添加监听器
    }

    private void OnSelectEntered(SelectEnterEventArgs arg0)
    {
        Debug.Log(transform.name + "正在被" +  arg0.interactableObject.transform.name + "抓取");
    }
    
    public void OnActivated()
    {
        if (isOpen)
        {
            animator.SetTrigger("Open");    //播放Open这个动画
        }
        else
        {
            animator.SetTrigger("Close");   //播放Close这个动画
        }
        isOpen =! isOpen;

    }
}
