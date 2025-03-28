using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_controller : MonoBehaviour
{
    public AudioSource musicSource; // ���ֲ������

    private void Update()
    {
        if (musicSource.GetComponent<MeshRenderer>()) // �������ťʱ
        {
            if (musicSource.isPlaying) // ����������ڲ���
            {
                musicSource.Pause(); // ��ͣ����
            }
            else // �������δ�ڲ���
            {
                musicSource.Play(); // ��������
            }
        }
    }
}
