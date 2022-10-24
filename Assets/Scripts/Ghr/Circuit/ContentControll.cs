using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentControll : MonoBehaviour
{
    //��Ҷ��󣨿�����Ч��
    private GameObject player;
    private GameObject yiyi;
    //������բ����Ч
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
        openDoor = Resources.Load<AudioClip>("Audio/Sound/�򿪾���������");
    }
    //���Ƚ��г�ʼ��
    void init()
    {
        itemsList.Clear();
    }
    /// <summary>
    /// ����������Ƿ�ȫ��Ϊ��ȷ״̬
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
            Debug.Log("ȫ������������һ������");
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
