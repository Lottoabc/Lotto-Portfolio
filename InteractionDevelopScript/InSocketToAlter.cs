using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class InSocketToAlter : MonoBehaviour
{
    public GameObject UIMenu;                       //UI���
    private XRGrabInteractable xrGrabInteractable;  //����һ��Interactable�û���ȡ
    private bool isGrabBySocket = false;            //����ֵ�����ж������״̬

    private void Start()
    {
        UIMenu.SetActive(false);
        xrGrabInteractable = GetComponent<XRGrabInteractable>();            //��ȡInteractable���
        xrGrabInteractable.activated.AddListener(onActivated);              //�ֱ���Ӳ�ͬ״̬�µ��¼�
        xrGrabInteractable.selectEntered.AddListener(onSelectedEntered);
        xrGrabInteractable.selectExited.AddListener(onSelectedExited);
    }

    private void onSelectedExited(SelectExitEventArgs arg0) 
    {
        if(arg0.interactorObject is XRSocketInteractor)     //���뿪��ѡ��״̬ʱ, ��isGrabBySocketΪfalse
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
        if(arg0.interactorObject is XRSocketInteractor)     //�����ص�ֵΪXRSocketInteractorʱ
        {
            isGrabBySocket = true;
        }
    }

    private void onActivated(ActivateEventArgs arg0)
    {
        if(!isGrabBySocket)     //�����Ϸ����û�б���ֹSocket����
        {                       //���µ��߼�Ҳ�Ͳ�ִ��,ֱ�ӷ���
            return;
        }
        
        if(UIMenu.activeSelf)   //activeSelf���������ж�UI�Ƿ���ʾ
        {
            HideMenu();
        }

        else
        {
            ShowMenu();
        }
    }

    //����Menu������ʾ������
    private void ShowMenu()
    {
        UIMenu.SetActive(true);
        UIMenu.transform.localScale = Vector3.zero;      //����UI������Ϊ0,���ڻ���Ч��
        UIMenu.transform.DOScale(Vector3.one * 0.005f,  //֮������DOScale�������ű���, ��ѡ������ʱ���Ч��
            0.3f).SetEase(Ease.OutBack);
    }

    private void HideMenu()
    {
        UIMenu.transform.DOScale(Vector3.zero,                  //ʹ��DOScale���������������
            0.3f).SetEase(Ease.InBack).OnComplete(delegate ()   //��������Ϊ0,��0.3����,��SetEase�������û���������
        {
            UIMenu.SetActive(false);                            //��������������UIMenuȡ������
        });
    }
}
