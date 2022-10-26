using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToClose : MonoBehaviour
{
    public Animator flower;
    public Animator suger;
    public Animator wine;
    public Animator cup;
    public GameObject qte;
    public int CloseNum;

  
    public void Update()
    {
        if(CloseNum == 3)
        {
            StartCoroutine(Cupcount());
            
            StartCoroutine(Qtecount());
            
        }
    }
    IEnumerator Cupcount()
    {
        yield return new WaitForSeconds(0.5f);
        cup.SetBool("shake", true);
    }
    IEnumerator Qtecount()
    {
        
        yield return new WaitForSeconds(0.5f);
        qte.SetActive(true);
        

    }
    public void flowerClose()
    {

        CloseNum++;
        flower.SetBool("fall", true);
    }
    public void sugerClose()
    {

        CloseNum++;
        suger.SetBool("fall", true);
    }
    public void winrClose()
    {

        CloseNum++;
        wine.SetBool("fall", true);
    }
}
