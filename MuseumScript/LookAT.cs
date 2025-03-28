using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LookAT : MonoBehaviour
{
    private Vector3 lookAtPosition = Vector3.zero;
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
        IntroCanvas.SetActive(true);
        // ��ȡPlayer��ʵ������
        player = Player.instance;
        // ��ȡ��Ϸ�����Transform����
        _transform = transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        lookAtPosition.x = player.hmdTransform.position.x;
        lookAtPosition.y = _transform.position.y;
        lookAtPosition.z = player.hmdTransform.position.z;
        //����������
        _transform.LookAt(lookAtPosition);

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
