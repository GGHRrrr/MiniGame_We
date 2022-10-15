using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstControll : MonoBehaviour
{
    private bool isEnterDoor=false;
    private bool isEnterWindow = false;
    private void Update()
    {

        #region ��ҽ����¼�
        if (isEnterDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("����ڴ��ţ���������");
            } 
        }
        if(isEnterWindow)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                Debug.Log("����ڴ������������");
            }
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "breakWindow":
                Debug.Log("���������ˣ�");
                
                break;
            case "workDoor":
                Debug.Log("�������ˣ�");
                isEnterDoor = true;
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                Debug.Log("���ڴ�����");
                break;
            case "workDoor":
                isEnterDoor = false;
                break;
        }
    }
}
