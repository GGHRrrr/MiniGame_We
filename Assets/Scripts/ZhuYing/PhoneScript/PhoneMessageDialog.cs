using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
    private Dictionary<string, GameObject> MessageDic = new Dictionary<string, GameObject>();
    private List<PhoneElementBtn> _Buttons = new List<PhoneElementBtn>();

    public static int UnReadMessagesSub = 0;

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
            Pan.ReflectButton = Btn;
            MessageDic[data[i].name] = PanObj;
            Btn.UserBtn.onClick.AddListener(delegate
            {
                OnCilckUserBtn(Btn.Id);
                ButtonRefresh();
                Btn.OnClickMessage();
            });
            PanObj.SetActive(false);
            _Buttons.Add(Btn);
        }
        _Buttons[_Buttons.Count-1].OnClickImage.SetActive(true);
        MessageDic[_Buttons[_Buttons.Count-1].Id].SetActive(true);
        base.Init();
    }

    public override void Show()
    {
        foreach (var item in MessageDic)
        {
            if (item.Value.activeSelf)
            {
                item.Value.GetComponent<PhoneMessagesPanel>().ShowMessage();
            }
        }
        base.Show();
    }

    public async void InterNewMessage(KeyValuePair<string, int> NameID)
    {
        PhoneMessageBlock data = PhoneModel.Instance().MPhoneData.userDic[NameID.Key].messageBlocksDic[NameID.Value];
        MessageDic[NameID.Key].GetComponent<PhoneMessagesPanel>().InterMessage(data);
    }
    
    public void OnCilckUserBtn(string key)
    {
        foreach (var Obj in MessageDic.Values)
        {
            Obj.SetActive(false);
        }
        MessageDic[key].SetActive(true);
        MessageDic[key].GetComponent<PhoneMessagesPanel>().ShowMessage();
    }

    public void ButtonRefresh()
    {
        for (int i = 0; i < _Buttons.Count; i++)
        {
            _Buttons[i].OnClickImage.SetActive(false);
        }
    }
    
    public readonly static string PATH = "PhonePrefab/PhoneMessageDialog";
}
