using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhoneMessageDialog : PhoneUIBase
{
    [SerializeField] public Button BackBtn;             //���ذ�ť
    [SerializeField] public Button SendBtn;             //���Ͱ�ť

    [SerializeField] public Transform UserListParent;  //�û���ť�б�����
    [SerializeField] public GameObject MessageBtnPrefab;
    //private Dictionary<string,PhoneMessageUserBtn> UserBtns = new Dictionary<string,PhoneMessageUserBtn>();
    [SerializeField] public Transform MessagesPannelParent;
    [SerializeField] public GameObject MessagesPannelPrefab;  //��Ϣ���ڸ�
    private Dictionary<string, GameObject> MessageDic = new Dictionary<string, GameObject>();

    public void Init()
    {
        List<PhoneMessageWindow> data = PhoneModel.Instance().MPhoneData.users;
        for (int i = 0; i < data.Count; i++)
        {
            var BtnObj = Instantiate(MessageBtnPrefab, UserListParent);
            PhoneElementBtn Btn = BtnObj.GetComponent<PhoneElementBtn>();
            Btn.Init(data[i]);
            var PanObj = Instantiate(MessagesPannelPrefab, MessagesPannelParent);
            PhoneMessagesPanel Pan = PanObj.GetComponent<PhoneMessagesPanel>();
            Pan.InitPanel(data[i].messageBlocks);
            MessageDic[data[i].name] = PanObj;
            Btn.UserBtn.onClick.AddListener(delegate
            {
                OnCilckUserBtn(Btn.Id);
                ButtonRefresh();
                Btn.OnClickLog();
            });
            if (i != 0)
                PanObj.SetActive(false);
            else
            {
                PanObj.SetActive(true);
            }
        }
        base.Init();
    }

    public void OnCilckUserBtn(string key)
    {
        foreach (var Obj in MessageDic.Values)
        {
            Obj.SetActive(false);
        }
        MessageDic[key].SetActive(true);
    }

    public void ButtonRefresh()
    {
        
    }
    
    public readonly static string PATH = "PhonePrefab/PhoneMessageDialog";
}
