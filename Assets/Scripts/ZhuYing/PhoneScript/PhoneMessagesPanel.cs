using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PhoneMessagesPanel : MonoBehaviour
{
    [SerializeField] public Transform Content;
    [SerializeField] public GameObject TimeMessage;
    [SerializeField] public GameObject ReceivedMessage;
    [SerializeField] public GameObject SendMessage;

    public void InitPanel(List<PhoneMessage> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            switch (data[i].messageType)
            {
                case MessageType.Time:
                    break;
                case MessageType.Received:
                    break;
                case MessageType.Send:
                    break;
            }
        }
    }
}
