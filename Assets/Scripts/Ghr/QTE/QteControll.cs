using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
  enum Move
{
    left,
    right
}
public class QteControll : MonoBehaviour
{
    public GameObject mid;//中间判定点
    public GameObject arrow;//往返的箭头
    public Transform leftPoint;//左边终点位置
    public Transform rightPoint;//右边终点位置
    [SerializeField] private MoveType moveType;//移动类型
    [SerializeField] private float moveSpeed;//移动速度

    public bool isPress = false;//是否按压
    public GameObject player;
    public GameObject yiyi;
    public GameObject shengzi;

    //音效相关
    private AudioSource audio;
    private AudioClip fall;
    
    private void OnEnable()
    {
        InitQte();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    void InitQte()
    {
        moveType = MoveType.right;
        moveSpeed = Random.Range(10f, 25f);
        isPress = false;
        arrow.transform.localPosition = leftPoint.localPosition;

        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        fall = Resources.Load<AudioClip>("Audio/Sound/跳跃落地-带衣服声");
    }
    private void Update()
    {
         PressKey();
        if (isPress == false)
            //ArrowMove();
            Invoke("ArrowMove", 0.5f);
    }
    /// <summary>
    /// 循环移动
    /// </summary>
    void ArrowMove()
    {
        switch(moveType)
        {
            case MoveType.right:
                if (arrow.transform.localPosition.x - rightPoint.localPosition.x >= 0.1)
                    moveType = MoveType.left;
                arrow.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                break;
            case MoveType.left:
                if (arrow.transform.localPosition.x - leftPoint.localPosition.x <= 0.1)
                    moveType = MoveType.right;
                arrow.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                break;
        }
    }
    void dia()
    {
        string[] info = { "Yiyi:6!(= =)" };
        DialoguePanel.Instance.ShowDialogue(info);
    }
    /// <summary>
    /// 按键反馈
    /// </summary>
    void PressKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        { 
            isPress = true;
            if (Mathf.Abs( arrow.transform.localPosition.x - mid.transform.localPosition.x)<= 0.5f)
            {
                if(player.transform.position.x-gameObject.transform.position.x<0)
                {
                    QteJump(new Vector3(200f, player.transform.localPosition.y, player.transform.localPosition.z));
                    string[] info = 
                    {
                        "Human:有惊无险，呼......身法如何？",
                        "Yiyi:Yiyi:6!(= =)"
                    };
                    DialoguePanel.Instance.ShowDialogue(info);
                    //Invoke("dia", 2f);
                }
                else
                {
                    QteJump(new Vector3(145f, player.transform.localPosition.y, player.transform.localPosition.z));
                }
                //播放音效
                if (!audio.isPlaying)
                {
                    audio.PlayOneShot(fall, 0.8f);
                }
            }
            else
            {
                InitQte();
                //isPress = false;
                Invoke("ArrowMove", 1f);
            }
        }
    }
    void QteJump(Vector3 trans)
    {
        yiyi.GetComponent<YiyiMove>().moveSpeed = 10;
        player.GetComponent<PlayerMove>().moveSpeed = 7;
        shengzi.gameObject.SetActive(false);
        shengzi.gameObject.GetComponent<Animator>().enabled = false;
        shengzi.transform.localRotation = new Quaternion(0, 0, 0, 0);
        shengzi.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localRotation = new Quaternion(0, 0, 0, 0);
        GameObject.Find("Main Camera").gameObject.GetComponent<Camera>().enabled = true;
        GameObject.Find("Min Camera").gameObject.GetComponent<Camera>().enabled = false;
        player.GetComponent<SwitchRole>().IsFollow = true;
        yiyi.transform.GetChild(3).gameObject.SetActive(false);
        player.transform.localPosition = trans;
        player.GetComponent<Animator>().Play("getUp");
        gameObject.SetActive(false);
    }
}
