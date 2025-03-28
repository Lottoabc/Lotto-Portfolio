using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFFTrigger : MonoBehaviour
{
    public Material SaveMaterial;
    public static FFFManager Manager;

    private void Awake()
    {
        Manager = FindObjectOfType<FFFManager>();
    }
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == transform.name)
        {
            GetComponent<Renderer>().material = SaveMaterial;
            Destroy(other.gameObject);
            Manager.JudgeOrder(transform.name);
        }
    }



}
