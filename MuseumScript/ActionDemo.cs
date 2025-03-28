using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR; //�����ռ�ΪValve

public class ActionDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {                                //������̧��ʱ�ļ���  ���԰��¿�ݼ�Alt + Inter��ݼ�����������������  

        SteamVR_Actions.default_Fire.AddOnStateUpListener(FireActionStateUpHandler, SteamVR_Input_Sources.Any); //Ϊ���õ��Ķ������״̬�ļ���
        SteamVR_Actions.default_Fire.onStateUp += OnFireActionStateUp;             //ָ������������Դͷ
        SteamVR_Actions.default_Squeeze.onAxis += OnSqueezeAxis;
        // onAxis����¼������ǲ�Ϊ0ʱ��ִ��
        
        //SteamVR_Actions.default_Fire.onStateUp �������ö������¼��������ｫOnFireActionsStateUp����¼���������������
          
    }

    private void OnSqueezeAxis(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
    {                                                           //newAxis���������������ֵ  newDelta��һ���ı�ֵ
        Debug.Log("��ǰ�ļ���Ϊ��" + newAxis + "���ȱ�֮ǰ�ı��ˣ�" + newDelta);
    }

    private void OnFireActionStateUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("�����¼������������" + fromSource + "����");
    }

    private void FireActionStateUpHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("����״̬��������" + fromSource + "����");
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
