using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sculpture : MonoBehaviour
{
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;     //��transform��ֵ��_transform����ô�����������ܵ�����
        MoveUpAndDown();
    }   

    // Update is called once per frame
    private void MoveUpAndDown()
    {
        Vector3 upDestination = _transform.position + Vector3.up * 2.5f;    //����λ��Ϊ��Ϸ���������ƶ�0.1��
        _transform.DOMove(upDestination, 3.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        //                ����λ��     ����3�� ����ѭ��                ���û�������         
        //yoyoѭ��Ϊ��Ϸ���󵽴����յĵĵص�Ὺʼ����          InOutSineΪ���յ�ʱ���м����˶�
    }
}
