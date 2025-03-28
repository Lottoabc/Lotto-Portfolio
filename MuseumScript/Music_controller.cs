using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_controller : MonoBehaviour
{
    public AudioSource musicSource; // 音乐播放组件

    private void Update()
    {
        if (musicSource.GetComponent<MeshRenderer>()) // 当点击按钮时
        {
            if (musicSource.isPlaying) // 如果音乐正在播放
            {
                musicSource.Pause(); // 暂停音乐
            }
            else // 如果音乐未在播放
            {
                musicSource.Play(); // 播放音乐
            }
        }
    }
}
