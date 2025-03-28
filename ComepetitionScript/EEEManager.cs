using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EEEManager : MonoBehaviour
{
    public Light MyLight;

    public GameObject NextUI;

    public static PXR_ScreenFade1 Fade;

    bool Judge = false; 
    private void Awake()
    {
        Fade = FindObjectOfType<PXR_ScreenFade1>();
    }

    void Start()
    {
        NextUI.SetActive(false);
        StartCoroutine(IntensityControl());
    }

    IEnumerator IntensityControl()
    {
        MyLight.intensity = 0.5f;
        while(MyLight.intensity < 5f)
        {
            MyLight.intensity += 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ToNextScene()
    {
        SceneManager.LoadScene("FFF");
    }

    private void Update()
    {
        if(MyLight.intensity > 3.0f)
        {
            NextUI.SetActive(true);
        }
        if(MyLight.intensity > 3.5f && Judge == false)
        {
            StartCoroutine(Fade.ScreenFade());
            Judge = true;
            Invoke(nameof(ToNextScene), 2f);
        }
    }
}
