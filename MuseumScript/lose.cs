
using UnityEngine;

public class RemoveColor : MonoBehaviour
{
    void Start()
    {
        // 获取当前游戏对象的Renderer组件
        Renderer renderer = GetComponent<Renderer>();

        // 如果该组件存在
        if (renderer != null)
        {
            // 获取该组件的材质
            Material material = renderer.material;

            // 将材质颜色设置为纯白色，去掉颜色
            material.color = Color.white;

            // 或者将材质颜色设置为完全透明
            // material.color = new Color(1, 1, 1, 0);
        }
    }
}
