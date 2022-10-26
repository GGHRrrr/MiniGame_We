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
public class Qte : MonoBehaviour
{
    public GameObject mid;//�м��ж���
    public GameObject arrow;//�����ļ�ͷ
    public Transform leftPoint;//����յ�λ��
    public Transform rightPoint;//�ұ��յ�λ��
    [SerializeField] private MoveType moveType;//�ƶ�����
    [SerializeField] private float moveSpeed;//�ƶ��ٶ�
    public bool isPress = false;//�Ƿ�ѹ

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
        moveSpeed = Random.Range(10f, 25f);
        isPress = false;
        arrow.transform.localPosition = leftPoint.localPosition;
    }
    private void Update()
    {
        PressKey();
        if (isPress == false)
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
    /// <summary>
    /// ��������
    /// </summary>
    void PressKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPress = true;
            if (Mathf.Abs(arrow.transform.localPosition.x - mid.transform.localPosition.x) <= 0.5f)
            {
                gameObject.SetActive(false);
            }
            else
            {
                InitQte();
                Invoke("ArrowMove", 1f);
            }
        }
    }
}