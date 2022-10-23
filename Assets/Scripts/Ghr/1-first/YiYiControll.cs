using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class YiYiControll : MonoBehaviour
{
    //??ßπ???
    private AudioClip openSwitch;
    private AudioClip openDoor;
    //?????????????2.5 49 
    //????????????????2.5 15
    public GameObject e;
    public GameObject workEnv;
    public GameObject workEnv_Inside;
    public GameObject player;
    public GameObject handle;
    public GameObject box;
    public GameObject cir;
    public GameObject qte;
    private GameObject cam;
    private GameObject post;
    public static bool isTotalunLocked=false;//???????????
    public  bool isEnterWork = false;
    private bool isEnterWindow = false;
    private bool isEnterHandle = false;
    private bool isEnterBox=false;
    private Vector2 nowPos;
    private Vector2 palyerNowPos;
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.KeyDown_Tab.ToString(), OnKey_TabDownEvnet);
        EventManager.Instance().AddEventListener(EventTypeEnum.Unlock_Circuit.ToString(), UnlockCircuit);
    }
    private void Start()
    {
        post = GameObject.Find("Post").gameObject;
        cam = GameObject.Find("Main Camera");
        palyerNowPos = player.transform.localPosition;

        //??ßπ
        openSwitch = Resources.Load<AudioClip>("Audio/Sound/??????");
        openDoor = Resources.Load<AudioClip>("Audio/Sound/???????????");
    }
    private void Update()
    {
        #region yiyi???????
        //???????
        if (isEnterHandle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (handle.GetComponent<SpriteRenderer>().enabled == true)
                {
                    handle.transform.GetChild(0).gameObject.SetActive(true);
                    handle.GetComponent<SpriteRenderer>().enabled = false;
                    Debug.Log("???????");
                }
                else
                {
                    handle.transform.GetChild(0).gameObject.SetActive(false);
                    handle.GetComponent<SpriteRenderer>().enabled = true;
                    Debug.Log("???????? ");
                }
                if (!player.GetComponent<AudioSource>().isPlaying)
                    player.GetComponent<AudioSource>().PlayOneShot(openSwitch, 0.8f);
            }
           
        }
        //???¶ƒ??????????????
        if (!FirstControll.isPlayerEnterWork)
        {
            if (isEnterWindow)
            {
                if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<SwitchRole>().isYiYi)
                {
                    Debug.Log("yiyi????????????");
                    isEnterWork = true;
                    workEnv.SetActive(false);
                    workEnv_Inside.SetActive(true);
                    player.GetComponent<SwitchRole>().enabled = false;
                    player.GetComponent<PlayerMove>().enabled = false;
                    gameObject.transform.localPosition = new Vector3(-9f, transform.localPosition.y, transform.localPosition.z);
                    player.transform.GetChild(0).gameObject.SetActive(false);
                    cam.transform.position = new Vector3(14f, cam.transform.position.y, cam.transform.position.z);
                    cam.GetComponent<CameraFollow>().maxPos = new Vector2(15, 0);
                    post.transform.GetChild(0).gameObject.SetActive(true);
                    string[] dialogues = { "Yiyi:??°§?????" };
                    DialoguePanel.Instance.ShowDialogue(dialogues);
                    //player.GetComponent<SwitchRole>().IsFollow = false;
                }
            }//??????
            //???°§?Ÿ¨??,?????°§??
            if (isEnterBox)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("???°§????");
                    if (cir.gameObject.activeSelf == false)
                    {
                        box.GetComponent<BoxCollider2D>().enabled = false;
                        cir.gameObject.SetActive(true);
                        gameObject.GetComponent<YiyiMove>().moveSpeed = 0;
                        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    }

                }
            }
            else
            {
                if (cir.gameObject.activeInHierarchy)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        box.GetComponent<BoxCollider2D>().enabled = true;
                        cir.gameObject.SetActive(false);
                        gameObject.GetComponent<YiyiMove>().moveSpeed = 10;
                        //gameObject.GetComponent<SpriteRenderer>().enabled = true;
                        gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
            //?????????????tab????????????????
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                EventManager.Instance().EventTrigger(EventTypeEnum.KeyDown_Tab.ToString(), "");
            }
        }
 #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                Debug.Log("yiyi???????????");
                isEnterWindow = true;
                ShowYiYiE(true);
                break;
            case "handle(up)":
                isEnterHandle = true;
                ShowYiYiE(true);
                break;
            case "box":
                isEnterBox = true;
                ShowYiYiE(true);
                break;
            case "shengzi":
                GameObject.Find("Min Camera").gameObject.GetComponent<Camera>().enabled = true;
                GameObject.Find("Main Camera").gameObject.GetComponent<Camera>().enabled = false;
                qte.SetActive(true);
                collision.gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<YiyiMove>().moveSpeed = 0;
                player.GetComponent<PlayerMove>().moveSpeed = 0;
                Debug.Log("??????????qte?úQ");
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            switch (collision.name)
            {
                case "breakWindow":
                isEnterWindow = false;
                ShowYiYiE(false);
                break;
            case "handle(up)":
                isEnterHandle = false;
                ShowYiYiE(false);
                break;
            case "box":
                isEnterBox = false;
                ShowYiYiE(false);
                break;
        }
    }
    /// <summary>
    /// ???????????tab????????????
    //??????????ó®?????yiyi¶À??.????????isFollow=false????????????????????????????????¶À??????yiyi??¶À????????????ßπ????
    /// </summary>
    /// <param name="info"></param>
    private void OnKey_TabDownEvnet(object info)
    {
        //?ß›?????????
        if (workEnv_Inside.gameObject.activeInHierarchy && isEnterWork)
        {
            if(player.GetComponent<SwitchRole>().isYiYi)
            //if (player.GetComponent<SwitchRole>().IsFollow == false)
            {
                player.GetComponent<SwitchRole>().enabled = true;
                player.GetComponent<PlayerMove>().enabled = true;
                player.transform.localPosition = palyerNowPos;
                nowPos = transform.localPosition;
                workEnv.gameObject.SetActive(true);
                workEnv_Inside.gameObject.SetActive(false);
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                player.transform.GetChild(0).gameObject.SetActive(true);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(49, 0);
                post.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        //?ß›?????????.
        if (!workEnv_Inside.gameObject.activeInHierarchy && isEnterWork && !player.GetComponent<SwitchRole>().isYiYi)//player.GetComponent<SwitchRole>().IsFollow)
        {
            player.GetComponent<SwitchRole>().enabled = false;
            player.GetComponent<PlayerMove>().enabled = false;
            palyerNowPos = player.transform.localPosition;
            cam.transform.position = new Vector3(14f, cam.transform.position.y, cam.transform.position.z);
            workEnv.gameObject.SetActive(false);
            workEnv_Inside.gameObject.SetActive(true);
            //gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            player.transform.GetChild(0).gameObject.SetActive(false);
            player.transform.localPosition = new Vector3(nowPos.x, player.transform.localPosition.y,player.transform.localPosition.z);
            transform.localPosition = nowPos;
            cam.GetComponent<CameraFollow>().maxPos = new Vector2(15, 0);
            post.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void UnlockCircuit(object info)
    {
      cir.gameObject.SetActive(false);
        isTotalunLocked = true;
        StartCoroutine(CricuitAni());
    }
    //??°§???????????????ßπ?????????????Dotween,????ß¡??????
    IEnumerator CricuitAni()
    {
        yield return null;
        if (!player.GetComponent<AudioSource>().isPlaying)
            player.GetComponent<AudioSource>().PlayOneShot(openDoor, 0.8f);
        workEnv.gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        post.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.localPosition = new Vector3(6f, player.transform.localPosition.y, player.transform.localPosition.z);
        player.transform.GetChild(0).gameObject.SetActive(true);
        SpriteRenderer workEnv_Inside_Spr = workEnv_Inside.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        while (workEnv_Inside_Spr.color.a>=0.05)
        {
            yield return new WaitForSeconds(0.05f);
            workEnv_Inside_Spr.color = new Color(1, 1, 1, workEnv_Inside_Spr.color.a - 0.05f);
        }
        workEnv_Inside.gameObject.SetActive(false);
        workEnv_Inside_Spr.color = new Color(1, 1, 1, 1);
        PlayerManager.Instance().state = E_Player_State.Common;
        player.GetComponent<SwitchRole>().enabled = true;
        player.GetComponent<SwitchRole>().IsFollow = true;
        player.GetComponent<PlayerMove>().enabled = true;
        cam.GetComponent<CameraFollow>().maxPos = new Vector2(49, 0);
        StartCoroutine(Fade(workEnv.transform.GetChild(0).gameObject, false));
        gameObject.GetComponent<YiyiMove>().moveSpeed = 10;
        
    }

    IEnumerator Fade(GameObject gameObj,bool isFade)//ß’??????Åâ??
    {
        SpriteRenderer spriteRenderer = gameObj.GetComponent<SpriteRenderer>();
        if(isFade)
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
    void ShowYiYiE(bool isEnter)
    {
        if (player.GetComponent<SwitchRole>().isYiYi && isEnter)
        {
            e.gameObject.SetActive(true);
            StartCoroutine(Fade(e, true));
        }
        if (player.GetComponent<SwitchRole>().isYiYi && !isEnter)
        {
            e.gameObject.SetActive(false);
            e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
}
