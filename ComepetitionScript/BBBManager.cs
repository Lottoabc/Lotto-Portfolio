using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BBBManager : MonoBehaviour
{
    public GameObject IntroUI;

    public Text IntroText1;
    public Text IntroText2;

    public Image IntroImage;

    // Start is called before the first frame update
    void Start()
    {
        IntroText1.text = "";
        IntroText2.text = "";
        IntroImage.sprite = null;

        IntroUI.SetActive(false);
    }

    public void ShowIntroUI(string Text1,string Text2,Sprite Image)
    {
        IntroUI.SetActive(true);

        IntroText1.text = Text1;
        IntroText2.text = Text2;
        IntroImage.sprite = Image;
    }

    public void CloseIntroUI()
    {
        IntroUI?.SetActive(false);
    }

    public void ToNextScene()
    {
        SceneManager.LoadScene("CCC");
    }

}
