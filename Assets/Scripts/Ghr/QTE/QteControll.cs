using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
  enum MoveType
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
    /// <summary>
    /// 按键反馈
    /// </summary>
    void PressKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            isPress = true;
            if (Mathf.Abs( arrow.transform.localPosition.x - mid.transform.localPosition.x)<= 0.5f)
            {
                Debug.Log("成功");
                yiyi.GetComponent<YiyiMove>().moveSpeed = 10;
                player.GetComponent<PlayerMove>().moveSpeed = 7;
                shengzi.gameObject.SetActive(false);
                gameObject.SetActive(false);
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
