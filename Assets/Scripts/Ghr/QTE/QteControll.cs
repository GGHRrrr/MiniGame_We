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
    public GameObject mid;//�м��ж���
    public GameObject arrow;//�����ļ�ͷ
    public Transform leftPoint;//����յ�λ��
    public Transform rightPoint;//�ұ��յ�λ��
    public GameObject black;
    [SerializeField] private MoveType moveType;//�ƶ�����
    [SerializeField] private float moveSpeed;//�ƶ��ٶ�

    public bool isPress = false;//�Ƿ�ѹ
    public GameObject player;
    public GameObject yiyi;
    public GameObject shengzi;

    //��Ч
    private AudioSource audio;
    private AudioClip fall;
    private void OnEnable()
    {
        InitQte();
    }
    /// <summary>
    /// ��ʼ��
    /// </summary>
    void InitQte()
    {
        //��Ч
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        fall = Resources.Load<AudioClip>("Audio/Sound/��Ծ���-���·���");

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
    /// ѭ���ƶ�
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
        DialoguePanel.Instance.ShowTriggerDialogue("Yiyi:6!(= =)");
    }
    /// <summary>
    /// ��������
    /// </summary>
    void PressKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            isPress = true;
            if (Mathf.Abs( arrow.transform.localPosition.x - mid.transform.localPosition.x)<= 0.5f)
            {
                Debug.Log("�ɹ�");
                if(player.transform.position.x-gameObject.transform.position.x<0)
                {
                    QteJump(new Vector3(220f, player.transform.localPosition.y, player.transform.localPosition.z));
                    DialoguePanel.Instance.ShowTriggerDialogue("Human:����Σ�");
                    Invoke("dia", 2f);
                }
                else
                {
                    QteJump(new Vector3(165f, player.transform.localPosition.y, player.transform.localPosition.z));
                }

            }
            else
            {
                InitQte();
                //isPress = false;
                Invoke("ArrowMove", 1f);
                Debug.Log("ʧ��");
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
        GameObject.Find("Main Camera").gameObject.GetComponent<Camera>().enabled = true;
        GameObject.Find("Min Camera").gameObject.GetComponent<Camera>().enabled = false;
        player.GetComponent<SwitchRole>().IsFollow = true;
        yiyi.transform.GetChild(3).gameObject.SetActive(false);
        player.transform.localPosition = trans;
        player.GetComponent<Animator>().Play("getUp");
        gameObject.SetActive(false);
        //��Ч
        if (!audio.isPlaying)
            audio.PlayOneShot(fall, 0.8f);
    }
}
