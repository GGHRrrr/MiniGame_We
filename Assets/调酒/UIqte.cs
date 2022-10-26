using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
enum Move2
{
    left,
    right
}

public class UIqte : MonoBehaviour
{
    public GameObject mid;//中间判定点
    public GameObject arrow;//往返的箭头
    public Transform leftPoint;//左边终点位置
    public Transform rightPoint;//右边终点位置
    public GameObject wineBag;
    public GameObject wine;
    [SerializeField] private MoveType moveType;//移动类型
    [SerializeField] private float moveSpeed;//移动速度

    public bool isPress = false;//是否按压
    public bool isFinish = false;//是否调酒完成


    //音效相关
    private AudioSource audio;
    private AudioClip fall;

    private void Start()
    {
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

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
        moveSpeed = 500f;
        isPress = false;
        arrow.transform.localPosition = leftPoint.localPosition;

        //audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        //fall = Resources.Load<AudioClip>("Audio/Sound/跳跃落地-带衣服声");
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
        switch (moveType)
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
   

    void PressKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPress = true;
            if (Mathf.Abs(arrow.transform.localPosition.x - mid.transform.localPosition.x) <= 35f)
            {
                wineBag.SetActive(false);
                wine.SetActive(true);
                isFinish = true;
            }
            else
            {
                InitQte();
                //isPress = false;
                Invoke("ArrowMove", 1f);
                Debug.Log("失败");
            }
        }
    }
    
}
