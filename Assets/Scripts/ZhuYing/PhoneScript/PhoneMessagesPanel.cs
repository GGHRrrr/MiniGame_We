using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PhoneMessagesPanel : MonoBehaviour
{
    [SerializeField] public Transform Content;
    [SerializeField] public GameObject TimeMessage;
    [SerializeField] public GameObject ReceivedMessage;
    [SerializeField] public GameObject SendMessage;
    [SerializeField] public GameObject SendBox;

    public void InitPanel(List<PhoneMessageBlock> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            if(data[i].InterID > 0) continue;

            for (int j = 0; j < data[i].messages.Count; j++)
            {
                PhoneMessage mes = data[i].messages[j];
                switch (mes.messageType)
                {
                    case MessageType.Received:
                        var RmessageObj = Instantiate(ReceivedMessage, Content);
                        RmessageObj.GetComponent<MessageBox>().mtext.text = mes.messagesContext;
                        RmessageObj.SetActive(true);
                        break;
                    case MessageType.Send:
                        var SmessageObj = Instantiate(SendMessage, Content);
                        SmessageObj.GetComponent<MessageBox>().mtext.text = mes.messagesContext;
                        SmessageObj.SetActive(true);
                        break;
                    case MessageType.Time:
                        var TmessageObj = Instantiate(TimeMessage, Content);
                        TmessageObj.GetComponent<TextMeshProUGUI>().text = mes.messagesContext;
                        TmessageObj.SetActive(true);
                        break;
                }
            }
        }
    }
}
