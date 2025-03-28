using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Michsky.UI.ModernUIPack;
public class introTxtwithBotton : MonoBehaviour
{
    public GameObject infoPanel;    //����չʾ���ֽ��ܵ�Panel�����������ж��������ʾ������
    public ButtonManagerIcon ButtonManager;     //��ť�����ڽ��������н���ͼ���л�
    public Sprite InfoIcon;        //��������״̬�µİ�ťͼ�� 
    public Sprite CloseIcon;    //������ʾ״̬�µİ�ťͼ��
    private bool isShow = false;    //����״̬��־λ
    // Start is called before the first frame update
    void Start()
    {
        infoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInfoButtonClick()
    {
        if(isShow)
        {
            CloseIntro();
        }
        else
        {
            ShowIntro();
        }
    }

    private void ShowIntro()
    {
        infoPanel.SetActive(true);  //�Ƚ����ֹ�����ʾ����
        infoPanel.transform.localScale = Vector3.zero;   //����Panel��������Ϊ0���ɴ˿�ʼ����
        infoPanel.transform.DOScale(Vector3.one,0.3f);  //����Panel��0.3���������Ŵ�0��1 
        ButtonManager.buttonIcon = CloseIcon;  //���ð���ͼ��
        ButtonManager.UpdateUI();
        isShow = true;  //���ñ�־λ
    }

    public void CloseIntro()
    {       //����������0.3��Ļ�������ԭʼ���Ŵ�1��0
        Tweener tweener = infoPanel.transform.DOScale(Vector3.zero, 0.3f);
        tweener.onComplete = () => { infoPanel.SetActive(false); }; //������������������
        ButtonManager.buttonIcon = InfoIcon;
        ButtonManager.UpdateUI();   //���°�ť��ͼ��
        isShow = false;     //���ñ�־λ
    }
}
