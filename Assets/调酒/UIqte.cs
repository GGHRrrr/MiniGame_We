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
    public GameObject mid;//�м��ж���
    public GameObject arrow;//�����ļ�ͷ
    public Transform leftPoint;//����յ�λ��
    public Transform rightPoint;//�ұ��յ�λ��
    public GameObject wineBag;
    public GameObject wine;
    [SerializeField] private MoveType moveType;//�ƶ�����
    [SerializeField] private float moveSpeed;//�ƶ��ٶ�

    public bool isPress = false;//�Ƿ�ѹ
    public bool isFinish = false;//�Ƿ�������


    //��Ч���
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
    /// ��ʼ��
    /// </summary>
    void InitQte()
    {
        moveType = MoveType.right;
        moveSpeed = 500f;
        isPress = false;
        arrow.transform.localPosition = leftPoint.localPosition;

        //audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        //fall = Resources.Load<AudioClip>("Audio/Sound/��Ծ���-���·���");
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
                Debug.Log("ʧ��");
            }
        }
    }
    
}
