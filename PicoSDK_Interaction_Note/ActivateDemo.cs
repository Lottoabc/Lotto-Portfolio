using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateDemo : MonoBehaviour
{
    private XRSimpleInteractable interactable;  //���ڴ洢��ǰ�Ľ�������
    private bool isOpen;                        //���ڱ�ǵ�ǰ���ӵĿ���״̬
    private Animator animator;                  //���õ���Ϸ�����ϵ�Animator���

    void Start()
    {
        //������������л�ȡ
        interactable = GetComponent<XRSimpleInteractable>();
        animator = GetComponent<Animator>();
        interactable.selectEntered.AddListener(OnSelectEntered);    //��Ӽ�����
    }

    private void OnSelectEntered(SelectEnterEventArgs arg0)
    {
        Debug.Log(transform.name + "���ڱ�" +  arg0.interactableObject.transform.name + "ץȡ");
    }
    
    public void OnActivated()
    {
        if (isOpen)
        {
            animator.SetTrigger("Open");    //����Open�������
        }
        else
        {
            animator.SetTrigger("Close");   //����Close�������
        }
        isOpen =! isOpen;

    }
}
