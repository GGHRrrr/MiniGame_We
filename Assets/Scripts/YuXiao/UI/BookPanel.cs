using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPanel : MonoBehaviour
{
    //ÍË³ö°´Å¥
    public Button quit;
    //²Êµ°°´Å¥
    public Button caidan;
    //²Êµ°Ãæ°å
    public GameObject caidanPanel;

    private void Start()
    {
        quit.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        caidan.onClick.AddListener(() =>
        {
            caidanPanel.SetActive(true);
        });
    }
}
