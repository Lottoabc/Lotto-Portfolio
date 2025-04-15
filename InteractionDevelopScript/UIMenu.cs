using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public Transform Player;    //��ҵ�λ��

    private void Update()
    {
        Vector3 PlayerPosition = new Vector3(Player.position.x,             //���һ��UICanvas��Ҫָ��ķ���
            transform.position.y, Player.position.z);
        Vector3 DirectionToPlayer = transform.position - PlayerPosition;    //�õ�UI Canvasָ����ҵķ���
        transform.rotation = Quaternion.LookRotation(DirectionToPlayer);    //��������ת����Ϊ�泯��ҵķ���
    }
}
