using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstControll : MonoBehaviour
{
    #region ����
    public GameObject e;
    //���
    public GameObject cam;
    //����
    public GameObject yiyi;
    //����
    public GameObject workEnv;
    public GameObject workInsideEnv;
    public GameObject workInsidUnder;
    public GameObject outPostRoom;
    //����
    private GameObject post;

    //��Ч���
    private AudioSource audio;
    //������Ч�ļ�
    private AudioClip cantOpenDoor;

    #endregion
    #region �ж�����
    public static bool isPlayerEnterWork = false;
    public static bool isNowEnter = false;
     bool isEnterDoor=false;
     bool isEnterWindow = false;
     bool isInsideLeft = false;
     bool isInsideRight = false;
     bool isUnderLeft = false;
     bool isNextLevel = false;
     bool isEnterHole = false;
     bool isEnterOutPostDoor = false;
     bool isExitOutPost = false;
    #endregion
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.USEITEM_SHENGZI.ToString(), UseShengzi);
    }
    private void Start()
    {
        post = GameObject.Find("Post").gameObject;
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        cantOpenDoor = Resources.Load<AudioClip>("Audio/Sound/����ס�򲻿�");
    }
    private void Update()
    {
        #region ��ҽ����¼�
        if (isEnterDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(YiYiControll.isTotalunLocked&&isNowEnter==false)
                {
                    Debug.Log("���빤��");
                    isNowEnter = true;
                    cam.GetComponent<CameraFollow>().maxPos = new Vector2(15f, 0);
                    workEnv.SetActive(false);
                    workInsideEnv.SetActive(true);
                    gameObject.transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
                    yiyi.transform.localPosition = new Vector3(-9f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
                    yiyi.transform.GetChild(0).gameObject.SetActive(true);
                    isPlayerEnterWork = true;
                    post.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("����ڴ��ţ���������");
                    //������Ч
                    if (!audio.isPlaying)
                    {
                        audio.PlayOneShot(cantOpenDoor,0.8f);
                    }
                        
                }
            } 
        }
        if(isEnterWindow&&!isPlayerEnterWork)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialoguePanel.Instance.ShowTriggerDialogue("Human:YiYi,���Ƚ�ȥ�������Ŵ�");
                Debug.Log("����ڴ������������");
            }
        }
        //�뿪����
        if(isInsideLeft&& !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cam.GetComponent<CameraFollow>().maxPos=new Vector2(49f,0);
                transform.localPosition = new Vector3(60f, transform.localPosition.y, transform.localPosition.z);
                yiyi.transform.localPosition = new Vector3(60f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
                workEnv.SetActive(true);
                workInsideEnv.SetActive(false);
                isNowEnter = false;
                post.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        //�������һ��
        if(isInsideRight && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                workInsidUnder.gameObject.SetActive(true);
                workInsideEnv.SetActive(false);
                transform.localPosition = new Vector3(-10f, transform.localPosition.y, transform.localPosition.z);
                yiyi.transform.localPosition = new Vector3(-13f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
            }
        }
        //����һ�㵽����
        if(isUnderLeft&& !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                workInsidUnder.SetActive(false);
                workInsideEnv.SetActive(true);
                gameObject.transform.localPosition = new Vector3(130f, transform.localPosition.y, transform.localPosition.z);
                yiyi.transform.localPosition = new Vector3(130f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
            }
        }
        //������վ
        if(isEnterOutPostDoor&!gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            //49. 2.5
            //44.5/47   44
            if(Input.GetKeyDown(KeyCode.E))
            {
                //cam.transform.position = new Vector3(44, cam.transform.position.y, cam.transform.position.z);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(47, 0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(44.5f, 0);
                cam.transform.position = new Vector3(45, cam.transform.position.y, cam.transform.position.z);
                gameObject.transform.localPosition = new Vector3(203f, transform.localPosition.y, transform.localPosition.z);
                outPostRoom.SetActive(true);
                workEnv.SetActive(false);
            }
            
        }
        //�뿪��վ
        if (isExitOutPost && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                outPostRoom.SetActive(false);
                workEnv.SetActive(true);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(49f, 0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(2.5f, 0);
                gameObject.transform.localPosition = new Vector3(230f, transform.localPosition.y, transform.localPosition.z);
            }
        }
            //������һ��
            if (isNextLevel && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                int count = SceneManager.GetActiveScene().buildIndex ;
                if (count < 2)
                    SceneManager.LoadSceneAsync(count + 1);
            }
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "breakWindow":
                ShowPlayerE(true);
                isEnterWindow = true;
                Debug.Log("���������ˣ�");
                break;
            case "workDoor":
                Debug.Log("�������ˣ�");
                ShowPlayerE(true);
                isEnterDoor = true;
                break;
            case "insideLeft":
                isInsideLeft = true;
                ShowPlayerE(true);
                Debug.Log("������ߵ����ˣ�׼����ȥ��");
                break;
            case "insideRight":
                isInsideRight=true;
                ShowPlayerE(true);
                Debug.Log("������ߵ����ˣ�׼��������һ��");
                break;
            case"under_left":
                isUnderLeft = true;
                ShowPlayerE(true);
                Debug.Log("��������һ������ˣ�׼����һ��");
                break;
            case "holetrigger":
                isEnterHole = true;
                Debug.Log("��������");
                break;
            case "outPostDoor":
                ShowPlayerE(true);
                isEnterOutPostDoor = true;
                Debug.Log("������վ�ˣ�׼������");
                break;
            case "outpostleft":
                ShowPlayerE(true);
                isExitOutPost = true;
                Debug.Log("׼���뿪��վ");
                break;
            case "NextLevel":
                ShowPlayerE(true);
                Debug.Log("������һ�ص����ˣ�׼��������һ��");
                isNextLevel = true;
                break;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                ShowPlayerE(false);
                isEnterWindow=false;
                break;
            case "workDoor":
                isEnterDoor = false;
                ShowPlayerE(false);
                break;
            case "insideLeft":
                isInsideLeft = false;
                ShowPlayerE(false);
                break;
            case "insideRight":
                isInsideRight = false;
                ShowPlayerE(false);
                break;
            case "under_left":
                isUnderLeft = false;
                ShowPlayerE(false);
                break;
            case "NextLevel":
                ShowPlayerE(false);
                isNextLevel = false;
                break;
            case "holetrigger":
                isEnterHole = false;
                ShowPlayerE(false);
                break;
            case "outPostDoor":
                isEnterOutPostDoor = false;
                ShowPlayerE(false);
                break;
            case "outpostleft":
                ShowPlayerE(false);
                isExitOutPost = false;
                break;
        }
    }
    IEnumerator Fade(GameObject gameObj, bool isFade)//дһ�����亯��
    {
        SpriteRenderer spriteRenderer = gameObj.GetComponent<SpriteRenderer>();
        if (isFade)
        {
            while (spriteRenderer.color.a > 0)
            {
                yield return new WaitForSeconds(0.05f);
                spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - 0.05f);
            }
        }
        else
        {
            while (spriteRenderer.color.a < 1)
            {
                yield return new WaitForSeconds(0.05f);
                spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a + 0.05f);
            }
        }
    }
      void ShowPlayerE(bool isEnter)
    {
            if (!gameObject.GetComponent<SwitchRole>().isYiYi && isEnter)
            {
                e.gameObject.SetActive(true);
                StartCoroutine(Fade(e, true));
            }
            if (!gameObject.GetComponent<SwitchRole>().isYiYi && !isEnter)
            {
                e.gameObject.SetActive(false);
                e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
    }
    void UseShengzi(object info)
    {
        if(isEnterHole)
        {
            var shengzi = GameObject.Find("Envrionments/WorkImage").transform.GetChild(1).gameObject;
            shengzi.SetActive(true);
        }
    }
}
