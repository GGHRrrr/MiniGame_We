using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthController : MonoBehaviour
{
    public List<GameObject> cgList;
    public GameObject e;
    bool isEnterRoom = false;
    void Start()
    {
        //���ֲ���BGM
        MusicManager.Instance().PlayBGM("�ϳ�");
    }
    private void Update()
    {
        if(isEnterRoom&&Input.GetKeyDown(KeyCode.E))
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "room":
                isEnterRoom = true;
                e.SetActive(true);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "room":
                isEnterRoom = false;
                e.SetActive(false);
                break;
        }
    }
}
