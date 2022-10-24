using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

public class PhoneMessagesPanel : MonoBehaviour
{
    [SerializeField] public Transform Content;
    [SerializeField] public GameObject TimeMessage;
    [SerializeField] public GameObject ReceivedMessage;
    [SerializeField] public GameObject SendMessage;
    [SerializeField] public GameObject SendBox;
    [SerializeField] public ScrollRect ChatBox;

    [HideInInspector]public PhoneElementBtn ReflectButton;

    [HideInInspector]public List<PhoneMessage> UnReadMessages = new List<PhoneMessage>();
    [HideInInspector]public int unReadNum = 0;

    public void InitPanel(List<PhoneMessageBlock> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            if(data[i].InterID > 0) continue;

            for (int j = 0; j < data[i].messages.Count; j++)
            {
                LoadMessage(data[i].messages[j]);
            }
        }
    }

    public void InterMessage(PhoneMessageBlock data)
    {
        bool Isfirst = false;
        for (int i = 0; i < data.messages.Count; i++)
        {
            UnReadMessages.Add(data.messages[i]);
        }

        if (unReadNum == 0) Isfirst = true;
        while (UnReadMessages.Count > 0)
        {
            PhoneMessage mesdata = UnReadMessages[0];
            if (mesdata.messageType == MessageType.Send)
                break;
            if (mesdata.messageType == MessageType.Received)
                unReadNum++;
            LoadMessage(mesdata);
            UnReadMessages.Remove(mesdata);
        }
        ReflectButton.UnReadMessage.SetActive(true);
        ReflectButton.UnReadMessagesNum.text = unReadNum.ToString();
        if (Isfirst) PhoneMessageDialog.UnReadMessagesSub += unReadNum;
        
        Debug.Log("消息已加载");
    }

    public async void ShowMessage()
    {
        PhoneMessageDialog.UnReadMessagesSub -= unReadNum;
        unReadNum = 0;
        await Delay(2500);
        while (UnReadMessages.Count > 0)
        {
            PhoneMessage mesdata = UnReadMessages[0];
            LoadMessage(mesdata);
            UnReadMessages.Remove(mesdata);
            await Delay(2000);
        }
    }
    
    private async Task Delay(int time)
    {
        await Task.Delay(time);
    }


    public void LoadMessage(PhoneMessage mes)
    {
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

        ChatBox.verticalNormalizedPosition = 0;
    }
}
