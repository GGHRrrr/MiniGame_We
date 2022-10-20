using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondControl : MonoBehaviour
{
    public GameObject e;

    #region 状态变量
    private bool isFlowerShop;
    private bool isFlower;
    private bool isFirstFlower = true;
    private bool isTransport;
    #endregion

    #region 游戏对象
    public GameObject Transport;
    #endregion

    void Start()
    {
        
    }

    
    void Update()
    {
        //触碰到花店
        if (isFlowerShop && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                string[] info =
                {
                    "Human:人们走后，花房的花儿竟如此自由的盛放。",
                    "Yiyi:不受约束的美总是令人向往。"
                };
                //触发对话
                DialoguePanel.Instance.ShowDialogue(info);
            }
        }

        //触碰到伸出的花
        if (isFlower && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isFirstFlower)
                {
                    string[] info =
                    {
                        "Human:真美啊。",
                        "Human:如果我有一把剪刀，我一定会把你带走。"
                    };
                    //触发对话
                    DialoguePanel.Instance.ShowDialogue(info);
                    isFirstFlower = false;
                }
                else
                {
                    if (false)
                    {
                        //TODO:无剪刀时的逻辑
                        string[] info =
                        {
                            "Human:如果我有一把剪刀，我一定会把你带走。"
                        };
                        DialoguePanel.Instance.ShowDialogue(info);
                    }
                    else
                    {
                        //TODO:有剪刀时的逻辑
                    }

                }
                
            }
        }

        //触碰到交通机器人
        if (isTransport && !GetComponent<SwitchRole>().isYiYi)
        {
            if (true)
            {
                //没有车票
                string[] info =
                {
                    "如需乘坐，请出示车票。"
                };
                //触发对话
                DialoguePanel.Instance.ShowDialogue(info,Transport.transform);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + Vector3.left;
            }
            else
            {
                //有车票
                string[] info =
                {
                    "感谢本次乘坐，下一站：荒原边境。"
                };
                //触发对话
                DialoguePanel.Instance.ShowDialogue(info, Transport.transform);
            }
            
        }
    }

    #region 触发器相关
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "FlowerShop":
                //展示E图标
                ShowPlayerE(true);
                //修改状态变量
                isFlowerShop = true;
                print("触碰到花店");
                break;
            case "Flower":
                ShowPlayerE(true);
                isFlower = true;
                print("触碰到伸出的花");
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "FlowerShop":
                //展示E图标
                ShowPlayerE(false);
                //修改状态变量
                isFlowerShop = false;
                break;
            case "Flower":
                ShowPlayerE(false);
                isFlower = false;
                break;
        }
    }
    #endregion

    #region 碰撞体相关
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "Transport":
                isTransport = true;
                print("触碰到交通机器人");
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "Transport":
                isTransport = false;
                break;
        }
    }
    #endregion

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
}
