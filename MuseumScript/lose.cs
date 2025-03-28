
using UnityEngine;

public class RemoveColor : MonoBehaviour
{
    void Start()
    {
        // ��ȡ��ǰ��Ϸ�����Renderer���
        Renderer renderer = GetComponent<Renderer>();

        // ������������
        if (renderer != null)
        {
            // ��ȡ������Ĳ���
            Material material = renderer.material;

            // ��������ɫ����Ϊ����ɫ��ȥ����ɫ
            material.color = Color.white;

            // ���߽�������ɫ����Ϊ��ȫ͸��
            // material.color = new Color(1, 1, 1, 0);
        }
    }
}
