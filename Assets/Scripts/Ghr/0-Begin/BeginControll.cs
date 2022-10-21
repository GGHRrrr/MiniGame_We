using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BeginControll : MonoBehaviour
{
    //音效
    private AudioSource audio;
    private AudioClip moveGarbage;

    //过场动画
    private 
    Camera minCamera;//特写摄像机
    Camera mainCamera;//主摄像机
    GameObject openingAniPoint;//开场动画
    GameObject playerPar;//角色父物体
    GameObject player;//角色
    GameObject yiYI;//机器人

    public GameObject e;

    private bool isNextLevel = false;

    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.TALKWITH_YIYI.ToString(), TalkWith_YiYi);
        EventManager.Instance().AddEventListener(EventTypeEnum.TALKWITH_PLAYER.ToString(), TalkWith_Player);
        EventManager.Instance().AddEventListener(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), UseYilaguan_Garbage);
    }
    private void Start()
    {
        //音效
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        moveGarbage = Resources.Load<AudioClip>("Audio/Sound/移动垃圾桶");

        minCamera = GameObject.Find("MinCamera").GetComponent<Camera>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        openingAniPoint = GameObject.Find("Opening_Animation");
        playerPar = GameObject.Find("Player");
        player= playerPar.transform.GetChild(0).gameObject;
        yiYI = playerPar.transform.GetChild(1).gameObject;
        StartCoroutine(PlayOpenningAni());

    }

    private void Update()
    {
        //进入下一关
        if (isNextLevel && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                int count = SceneManager.GetActiveScene().buildIndex;
                print(count);
                if (count < 2)
                {
                    SceneManager.LoadSceneAsync(count + 1);
                }
                    
            }
        }
    }

    /// <summary>
    /// 开始过场动画，易拉罐特写切换等
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayOpenningAni()
    {
        //禁用玩家移动
        player.GetComponent<PlayerMove>().enabled = false;
        yield return new WaitForSecondsRealtime(2f) ;
        Animator opAni = openingAniPoint.transform.GetChild(0).GetComponent<Animator>();
        AnimatorStateInfo stateinfo = opAni.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("yilaguanAni") && (stateinfo.normalizedTime > 1.0f))
        {
            minCamera.GetComponent<Animator>().SetBool("isBegin", true);
            yield return new WaitForSecondsRealtime(2f);
            minCamera.gameObject.SetActive(false);
            mainCamera.enabled = true;
            StartCoroutine(PlayYiYiAni());
        }
        else
        {
            StartCoroutine(PlayOpenningAni());
        }
    }
    /// <summary>
    /// YIYI开场捡易拉罐动画
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayYiYiAni()
    {
        yield return null;
        player.GetComponent<SwitchRole>().IsFollow = false;
        yiYI.GetComponent<Animator>().enabled = true;
        Animator yiyiAni = yiYI.GetComponent<Animator>();
        AnimatorStateInfo stateinfo = yiyiAni.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("Pick") && (stateinfo.normalizedTime > 1.0f))
        {
            yiYI.transform.GetChild(0).GetComponent<Animator>().Play("Idle");
            yiYI.GetComponent<Animator>().enabled = false;
            //yiYI.GetComponent<Animator>().Play("viviidle");
            //切换对象，捡易拉罐逻辑，yiyi颜文字表情
            
            mainCamera.gameObject.GetComponent<CameraFollow>().enabled = true;
            //回去之后移动回复,暂时用测试脚本代替
            player.GetComponent<PlayerMove>().enabled = true;
        }
        else
        {
            StartCoroutine(PlayYiYiAni());
        }
    }
    /// <summary>
    /// yiyi对话事件
    /// </summary>
    /// <param name="info"></param>
     void TalkWith_YiYi(object info)
    {
        Debug.Log("yiyi说话");
    }
    /// <summary>
    /// 玩家对话事件
    /// </summary>
    /// <param name="info"></param>
    void TalkWith_Player(object info)
    {
        Debug.Log("玩家说话");
    }
    /// <summary>
    /// 玩家碰撞事件
    /// </summary>
    /// <param name="collision"></param>
     bool isTouchGar = false;//是否触碰过
     GameObject garbage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        switch (collision.gameObject.name)
        {
            case "Environments_Garbage":
                Debug.Log("我碰到垃圾桶了");
                //if (isTouchGar == false)
                //{
                //    //未触碰过则触发对话;
                //    isTouchGar = !isTouchGar;
                //}
                //else
                //{
                //    garbage= collision.gameObject;
                //}
                break;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (isTouchGar == true)
            //garbage = collision.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.name)
        {
            case "Environments_Garbage":
                Debug.Log("我碰到垃圾桶了");
                if (isTouchGar == false)
                {
                    //未触碰过则触发对话;
                    isTouchGar = !isTouchGar;
                }
                //else
                //{
                //    garbage= collision.gameObject;
                //}
                break;
            case "Environments_Fanmaiji":
                Debug.Log("我碰到贩卖机了");//可以做老虎机玩法,有时间再说
                break;
            case "NextLevel":
                ShowPlayerE(true);
                Debug.Log("碰到下一关的门了，准备进入下一关");
                isNextLevel = true;
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTouchGar == true)
            garbage = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "NextLevel":
                ShowPlayerE(false);
                isNextLevel = false;
                break;
        }
    }
    #region 触碰垃圾桶
    void UseYilaguan_Garbage(object info)
    {
        Debug.Log("执行了吗1");
        if (isTouchGar)
        {
            Debug.Log("执行了吗");
            //移动垃圾桶音效
            if (!audio.isPlaying)
                audio.PlayOneShot(moveGarbage, 0.8f);

            garbage.transform.localPosition = new Vector2(garbage.transform.localPosition.x, garbage.transform.localPosition.y + 0.5f);
            garbage.transform.GetChild(1).GetComponent<Collider2D>().enabled = false;
            EventManager.Instance().RemoveEventListener(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), UseYilaguan_Garbage);
        }
    }
    #endregion

    #region 显示玩家交互
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

    IEnumerator Fade(GameObject gameObj, bool isFade)//写一个渐变函数
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

    #endregion
}
