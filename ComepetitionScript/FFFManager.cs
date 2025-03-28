using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FFFManager : MonoBehaviour
{
    public GameObject FirstUI;
    public GameObject SecondUI;
    public GameObject ThirdUI;

    public static PXR_ScreenFade1 Fade;

    bool IsHead = false;
    bool IsBody = false;
    bool IsLeft = false;
    bool IsRight = false;
    bool IsBottom = false;

    public string SaveText;
    public Text IntroText;

    private void Awake()
    {
        Fade = FindObjectOfType<PXR_ScreenFade1>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade.ScreenFade());
        FirstUI.SetActive(true);
        SecondUI.SetActive(false);
        ThirdUI.SetActive(false);

        Invoke(nameof(ChangeSecondUI), 2.5f);
    }

    public void ChangeSecondUI()
    {
        SecondUI.SetActive(true);
        FirstUI.SetActive(false);
    }

    public void ReLoadScene()
    {
        SceneManager.LoadScene("FFF");
        StartCoroutine(Fade.ScreenFade());    
    }

    public void JudgeOrder(string Receive)
    {
        if (Receive == "foxiang_f_Head")
        {
            IsHead = true;
        }

        if (Receive == "foxiang_f_Body")
        {
            if (IsHead)
            {
                IsBody = true;
            }
            else
            {
                ReLoadScene();
            }
        }

        if (Receive == "foxiang_f_H")
        {
            if (IsBody)
            {
                IsLeft = true;
            }
            else
            {
                ReLoadScene();
            }
        }

        if (Receive == "foxiang_f_Hand")
        {
            if (IsLeft)
            {
                IsRight = true;
            }
            else
            {
                ReLoadScene();
            }
        }

        if (Receive == "foxiang_f_Di")
        {
            if (IsRight)
            {
                IsBottom = true;
                ChangeThirdUI();
            }
            else
            {
                ReLoadScene();
            }
        }
    }

    public void ChangeThirdUI()
    {
        SecondUI.SetActive(false);
        ThirdUI.SetActive(true);
        SaveText = IntroText.text;
        IntroText.text = "";

        StartCoroutine(UIKeyboard());
    }

    IEnumerator UIKeyboard()
    {
        for (int i = 1; i < SaveText.Length; i++)
        {
            IntroText.text = SaveText.Substring(0, i - 1) + "<color=#1234ffff>" + SaveText.Substring(i - 1, 1) + "</color>";
            yield return new WaitForSeconds(0.08f);
        }
        IntroText.text = SaveText;
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
