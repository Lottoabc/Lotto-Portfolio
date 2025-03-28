using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuChange : MonoBehaviour
{
    [System.Serializable]           
    public class MaterialElement                //一个用于存储的类
    {
        public Button button;
        public Material material;
        public Sprite thumbnail;
    }

    public GameObject Model;                    //指定的模型
    public MaterialElement[] MaterialElements;  //配置的数组

    private void Start()
    {
        for (int i = 0; i < MaterialElements.Length; i++)   //使用for循环为每个按钮添加点击事件,设置缩略图
        {
            int index = i;                                                          //创建一个循环内的变量保存索引值
            MaterialElements[index].button.gameObject.GetComponent<Image>().sprite  //设置按钮上的缩略图
                = MaterialElements[index].thumbnail;                                //先获取Button上的Image组件,再设置Sprite
            MaterialElements[index].button.onClick.AddListener(delegate ()          //为按钮添加点击事件
            {
                Model.GetComponent<Renderer>().material = MaterialElements[index].material; //设置模型的材质
            });
        }
    }
}
