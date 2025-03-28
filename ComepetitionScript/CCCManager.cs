using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CCCManager : MonoBehaviour
{
    public void ToNextScene()
    {
        SceneManager.LoadScene("DDD");
    }
}
