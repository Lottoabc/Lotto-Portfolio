using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;
using System;

public class UImanager : MonoBehaviour
{
    public GameObject LaserBeam;    //CurvedUI�ļ���ָ��
    public LayerMask LayerMask;    //ѡ���ܱ����߼��е�ͼ��
    public Transform RayOriginTrans;    //���߷���ĳ�����

    public Transform MenuUITrans;   //ϵͳ�˵�
    public float MenuUIDistance = 5.5f;   //�˵���ʾ����������ǰ����
    private bool isMenuShow = false;    //�˵���ʾ��־λ��Ĭ�ϼ�¼����ʾ

    public Slider TemperaturesSlider;   //ɫ�µ���Slider,��ֵ��Χ��-15~15
    public Slider HueSlider;    //ɫ������Slider����ֵ��Χ:-10~10
    public Slider ExposureSlider;   //�ع����Slider����ֵ��Χ:0~2
    public Slider StustionSlider;   //���Ͷ�Slider����ֵ��Χ-98~20

    // Start is called before the first frame update
    void Start()
    {
        MenuUITrans.gameObject.SetActive(false); //��ʼ״̬���ò˵�����
        SteamVR_Actions.default_Menu.onStateUp += Default_Menu_onStateUp;

        //��Ӽ�����
        TemperaturesSlider.onValueChanged.AddListener(ChangeTemperature);
        HueSlider.onValueChanged.AddListener(ChangeHue);
        ExposureSlider.onValueChanged.AddListener(ChangeExposure);
        StustionSlider.onValueChanged.AddListener(ChangeStustion);
    }

    private void ChangeStustion(float value)
    {
        GameManager.Instance.ChangeStustion(value);
    }

    private void ChangeExposure(float value)
    {
        GameManager.Instance.ChangeExposure(value);
    }

    private void ChangeHue(float value)
    {
        GameManager.Instance.ChangeHue(value);
    }

    private void ChangeTemperature(float value)
    {
        GameManager.Instance.ChangeTemperature(value);
    }

    private void Default_Menu_onStateUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        isMenuShow = !isMenuShow; //��ʾ״̬�÷�
        MenuUITrans.gameObject.SetActive(isMenuShow); //��ʾ�����ز˵�

        if(isMenuShow) //����˵���ʾ
        {       //�趨�˵�����λ��Ϊ������λ��+����ռ�λ�ã���ʱ���������ߵġ���ǰ��
            Transform playerHMDTrans = Player.instance.hmdTransform;   //ʹ��ͷ�Ե�λ�������������ߵ�λ��
            MenuUITrans.position = playerHMDTrans.position + Vector3.forward * MenuUIDistance;      //�ò˵���λ���ƶ��������ߵ�λ��+������ʾ�����ֵ
            MenuUITrans.RotateAround(playerHMDTrans.position, Vector3.up, playerHMDTrans.rotation.eulerAngles.y);       //������y�᷽����ת����������ת�ǶȾ���y�᷽�����ת�Ƕ�
         
        }
        else
        {
            MenuUITrans.rotation = Quaternion.Euler(Vector3.zero); //����ת�ĽǶȹ���
        }
    }

    // Update is called once per frame
    void Update()
    {       //���ֱ�����������������Ϊ�������죬����UI��Ʒ���������ײ
        RaycastHit hit;     //��������Ƿ��з�����ײ���                                LayerMask.valueΪѡ���ͼ��
        if (Physics.Raycast(RayOriginTrans.position,RayOriginTrans.forward,out hit,Mathf.Infinity,LayerMask.value))     
        {                   //�����λ��             ����ķ���       �������һ��hit  �������ߵĳ���Ϊ����
            LaserBeam.SetActive(true);
        }
        else
        {
            LaserBeam.SetActive(false);
        }
    
    }
    public void CloseMenu()
    {
        isMenuShow = false; //���ñ�־λ
        MenuUITrans.gameObject.SetActive(false);  //���ز˵�
        MenuUITrans.transform.rotation = Quaternion.Euler(Vector3.zero);    //�˵���ת�Ƕȹ���
    }
    //������Ч����
    public void ResetPostProcessing()
    {   //�����е�Slider�ص�Ĭ��ֵ��Ӧλ��,����Чֵ��ֵΪĬ��ֵ
        HueSlider.value = GameManager.Instance.defaultHue;
        ExposureSlider.value = GameManager.Instance.defaultExposure;
        TemperaturesSlider.value = GameManager.Instance.defaultTemperature;
        StustionSlider.value = GameManager.Instance.defaultStatuation;
        GameManager.Instance.ResetPostProcessing(); //����ResetPostProcessing�������
    }
}
