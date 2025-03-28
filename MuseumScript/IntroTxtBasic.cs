using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class IntroTxtBasic : MonoBehaviour
{
    // �ɼ����룬С�ڴ˾�����UI��ʾ
    public float VisibleDistance;
    // ��Player������
    protected Player player;
    // ����Ϸ������Transform������
    protected Transform _transform;
    // �������UIԪ�ص�Canvas
    public GameObject IntroCanvas;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // ��ʼ״̬������Canvas
        IntroCanvas.SetActive(false);
        // ��ȡPlayer��ʵ������
        player = Player.instance;
        // ��ȡ��Ϸ�����Transform����
        _transform = transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // �õ�����������Ϸ����ľ���
        float dis = Vector3.Distance(player.hmdTransform.position, _transform.position);
        // ���С���趨�Ŀɼ����룬����ʾUI
        if (dis < VisibleDistance)
        {
            if (!IntroCanvas.activeInHierarchy)
                IntroCanvas.SetActive(true);
        }
        else // ��������趨�ľ��룬������UI
        {
            if (IntroCanvas.activeInHierarchy)
                IntroCanvas.SetActive(false);
        }
    }
}
