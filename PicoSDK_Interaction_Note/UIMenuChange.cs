using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuChange : MonoBehaviour
{
    [System.Serializable]           
    public class MaterialElement                //һ�����ڴ洢����
    {
        public Button button;
        public Material material;
        public Sprite thumbnail;
    }

    public GameObject Model;                    //ָ����ģ��
    public MaterialElement[] MaterialElements;  //���õ�����

    private void Start()
    {
        for (int i = 0; i < MaterialElements.Length; i++)   //ʹ��forѭ��Ϊÿ����ť��ӵ���¼�,��������ͼ
        {
            int index = i;                                                          //����һ��ѭ���ڵı�����������ֵ
            MaterialElements[index].button.gameObject.GetComponent<Image>().sprite  //���ð�ť�ϵ�����ͼ
                = MaterialElements[index].thumbnail;                                //�Ȼ�ȡButton�ϵ�Image���,������Sprite
            MaterialElements[index].button.onClick.AddListener(delegate ()          //Ϊ��ť��ӵ���¼�
            {
                Model.GetComponent<Renderer>().material = MaterialElements[index].material; //����ģ�͵Ĳ���
            });
        }
    }
}
