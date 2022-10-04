using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhoneMessageDialog : PhoneUIBase
{
    [SerializeField] public Button BackBtn;             //返回按钮
    [SerializeField] public Button SendBtn;             //发送按钮

    [SerializeField] public Transform UserListParent;  //用户按钮列表父物体
    [SerializeField] public GameObject MessageBtnPrefab;
    //private Dictionary<string,PhoneMessageUserBtn> UserBtns = new Dictionary<string,PhoneMessageUserBtn>();
    [SerializeField] public Transform MessagesPannelParent;
    [SerializeField] public GameObject MessagesPannelPrefab;  //消息窗口父
    private Dictionary<string, GameObject> MessageDic;

    public void Init(List<PhoneMessageWindow> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            var BtnObj = Instantiate(MessageBtnPrefab, UserListParent);
            PhoneElementBtn Btn = BtnObj.GetComponent<PhoneElementBtn>();
            Btn.Init(data[i]);
            var PanObj = Instantiate(MessagesPannelPrefab, MessagesPannelParent);
            PhoneMessagesPanel Pan = PanObj.GetComponent<PhoneMessagesPanel>();
            Pan.InitPanel(data[i].messages);
            MessageDic[data[i].name] = PanObj;
            Btn.UserBtn.onClick.AddListener(delegate
            {
                OnCilckUserBtn(Btn.name);
            });
            if(i!=0)
                PanObj.SetActive(false);
        }
    }

    public void OnCilckUserBtn(string key)
    {
        foreach (var Obj in MessageDic.Values)
        {
            Obj.SetActive(false);
        }
        MessageDic[key].SetActive(true);
    }
    
    public readonly static string PATH = "PhonePrefab/PhoneMessageDialog";
}
