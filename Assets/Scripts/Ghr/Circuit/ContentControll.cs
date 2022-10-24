using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentControll : MonoBehaviour
{
    //玩家对象（控制音效）
    private GameObject player;
    private GameObject yiyi;
    //开启卷闸门音效
    private AudioClip openDoor;
    public GameObject light;
    public GameObject post;
    public GameObject cir;
    public static ContentControll instance;
    public List<ItemsControll> itemsList= new List<ItemsControll>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        init();
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<ItemsControll>())
            itemsList.Add(transform.GetChild(i).GetComponent<ItemsControll>());
        }

        player = GameObject.Find("Player").transform.GetChild(0).gameObject;
        yiyi = GameObject.Find("Player").transform.GetChild(1).gameObject;
        openDoor = Resources.Load<AudioClip>("Audio/Sound/打开卷匝门声音");
    }
    //首先进行初始化
    void init()
    {
        itemsList.Clear();
    }
    /// <summary>
    /// 检查子物体是否全部为正确状态
    /// </summary>
    public void CheckItems()
    {
        bool isAllTrue=false;
        for(int i=0;i<itemsList.Count;i++)
        {
            var item = itemsList[i];
            if (item.isTrue != true)
                break;
            if (item.isTrue == true && i == itemsList.Count - 1)
            {
                isAllTrue = true;
            }
                

        }
        if (isAllTrue)
        {
            Debug.Log("全部解锁进行下一步操作");
            if (!player.GetComponent<AudioSource>().isPlaying)
                player.GetComponent<AudioSource>().PlayOneShot(openDoor, 0.8f);
            StartCoroutine(StartEvent_Circuit());
        }
    }
    IEnumerator StartEvent_Circuit()
    {
        yiyi.GetComponent<BoxCollider2D>().enabled = true;
        light.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        post.gameObject.SetActive(false);
        EventManager.Instance().EventTrigger(EventTypeEnum.Unlock_Circuit.ToString(), "");
    }
}
