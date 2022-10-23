using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MimaBoxControll : MonoBehaviour
{
    public List<Button> btnList = new List<Button>();
    public GameObject shenfenpai;
    public PlayerMove player; 
    void Start()
    {
        
        for(int i=0;i<btnList.Count;i++)
        {
            int count = i;
            btnList[i].onClick.AddListener(()=> { OnclickBtn(count); });
        }
    }

    void OnclickBtn(int indext)
    {
        string textCount;
        textCount = btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text;
        switch(textCount)
        {
            case "0":
                textCount = "1";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "1":
                textCount = "2";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "2":
                textCount = "3";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "3":
                textCount = "4";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "4":
                textCount = "5";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "5":
                textCount = "6";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "6":
                textCount = "7";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "7":
                textCount = "8";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "8":
                textCount = "9";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
            case "9":
                textCount = "0";
                btnList[indext].transform.GetChild(0).gameObject.GetComponent<Text>().text = textCount;
                CheckTrue();
                break;
        }
    }
    void CheckTrue()
    {
        if (btnList[0].transform.GetChild(0).gameObject.GetComponent<Text>().text != "1")
        {
            gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }
        if (btnList[1].transform.GetChild(0).gameObject.GetComponent<Text>().text != "0")
        {
            gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }
        if (btnList[2].transform.GetChild(0).gameObject.GetComponent<Text>().text != "2")
        {
            gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }
        if (btnList[3].transform.GetChild(0).gameObject.GetComponent<Text>().text != "5")
        {
            gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }

        if (btnList[0].transform.GetChild(0).gameObject.GetComponent<Text>().text=="1")
        {
            if (btnList[1].transform.GetChild(0).gameObject.GetComponent<Text>().text == "0")
                if (btnList[2].transform.GetChild(0).gameObject.GetComponent<Text>().text == "2")
                    if (btnList[3].transform.GetChild(0).gameObject.GetComponent<Text>().text == "5")
                    {
                        gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                        shenfenpai.SetActive(true);
                        player.moveSpeed = 7;
                        player.gameObject.GetComponent<FirstControll>().isHaveShenfen = true;
                        gameObject.SetActive(false);
                    }
        }
         
    }
}
