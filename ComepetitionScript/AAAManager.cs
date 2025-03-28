using Pico.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AAAManager : MonoBehaviour
{
    public GameObject RightUI;
    public GameObject TipUI;

    public Text ConditionText;
    public Text TipText;

    public InputField AccountInput;
    public InputField PasswordInput;

    public List<User> MyList = new List<User>();

    // Start is called before the first frame update
    void Start()
    {
        RightUI.SetActive(false);
        TipUI.SetActive(false);

        AccountInput.text = "";
        PasswordInput.text = "";
    }

    public void ShowRightAccount()
    {
        RightUI.SetActive(true);
        ConditionText.text = "�˺�";
    }

    public void ShowRightPassword()
    {
        RightUI.SetActive(true);
        ConditionText.text = "����";
    }

    public void ConveyNumber(string Receive)
    {
        if (ConditionText.text == "�˺�")
        {
            AccountInput.text += Receive;
        }
        if (ConditionText.text == "����")
        {
            PasswordInput.text += Receive;
        }
    }

    public void RemoveNumber()
    {
        if (ConditionText.text == "�˺�")
        {
            AccountInput.text = "";
        }
        if (ConditionText.text == "����")
        {
            PasswordInput.text = "";
        }
    }
    
    public void ShowTipUI(string Receive)
    {
        TipUI.SetActive(true);
        TipText.text = Receive;
    }

    public void Register()
    {
        bool Judge = false;
        var Account = AccountInput.text;
        var Password = PasswordInput.text;

        foreach (var item in MyList)
        {
            if(item.SaveAccount == Account)
            {
                ShowTipUI("���˺��Ѵ���!");
                Judge = true;
            }
        }

        var UserList = new User()
        {
            SaveAccount = Account,
            SavePassword = Password,
        };

        if(!Judge)
        {
            ShowTipUI("ע��ɹ�!");
        }

        MyList.Add(UserList);
        AccountInput.text = "";
        PasswordInput.text = "";
    }

    public void Loading()
    {
        bool Judge = false;
        var Account = AccountInput.text;
        var Password = PasswordInput.text;

        foreach(var item in MyList)
        {
            if(item.SaveAccount == Account && item.SavePassword == Password)
            {
                ShowTipUI("���ڵ�½��!");
                Invoke(nameof(ToNextScene), 1.5f);
                Judge = true;
            }
        }

        if(!Judge)
        {
            ShowTipUI("�˺Ų����ڻ��������!");
        }

        AccountInput.text = "";
        PasswordInput.text = "";
    }

    public void CloseTipUI()
    {
        TipText.text = "";
        TipUI.SetActive(false);
    }

    public void ToNextScene()
    {
        SceneManager.LoadScene("BBB");
    }

}
