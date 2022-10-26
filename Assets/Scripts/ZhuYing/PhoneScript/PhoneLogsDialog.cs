using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MEEC.ExportedConfigs;
using Unity.VisualScripting;

public class PhoneLogsDialog : PhoneUIBase
{
    [SerializeField] public Button BackBtn;             //返回按钮

    [SerializeField] public Transform TitleListParent;  //用户按钮列表父物体
    [SerializeField] public GameObject TitleBtnPrefab;
    //private Dictionary<string,PhoneMessageUserBtn> UserBtns = new Dictionary<string,PhoneMessageUserBtn>();
    [SerializeField] public Transform LogsPanelParent;
    [SerializeField] public GameObject LogsPanelPrefab;  //消息窗口父
    private Dictionary<string, GameObject> LogsDic = new Dictionary<string, GameObject>();
    private List<PhoneElementBtn> _Buttons = new List<PhoneElementBtn>();
    public static int NewLogsNum = 0;

    public void Init()
    {
        List<PhoneLogs> data = PhoneModel.Instance().MPhoneData.logs;
        for (int i = 0; i < data.Count; i++)
        {
            if(data[i].interID > 0 || data[i].hasIntered) continue;
            var BtnObj = Instantiate(TitleBtnPrefab, TitleListParent);
            PhoneElementBtn Btn = BtnObj.GetComponent<PhoneElementBtn>();
            Btn.Init(data[i]);
            var PanObj = Instantiate(LogsPanelPrefab, LogsPanelParent);
            PhoneLogsPanel Pan = PanObj.GetComponent<PhoneLogsPanel>();
            Pan.Init(data[i]);
            LogsDic[data[i].title] = PanObj;
            Btn.UnReadLog.SetActive(false);
            Btn.UserBtn.onClick.AddListener(delegate
            {
                OnCilckTitleBtn(Btn.Id);
                ButtonRefresh();
                Btn.OnClickLog();
            });
            PanObj.SetActive(false);
            Btn.OnClickImage.SetActive(false);
            BtnObj.transform.SetSiblingIndex(0);
            _Buttons.Add(Btn);
            data[i].hasIntered = true;
        }
        _Buttons[_Buttons.Count-1].OnClickImage.SetActive(true);
        LogsDic[_Buttons[_Buttons.Count-1].Id].SetActive(true);
        base.Init();
    }

    public void InterNewLog(int ID)
    {
        PhoneLogs data = PhoneModel.Instance().MPhoneData.logDic[ID];
        if (data.hasIntered) return;
        NewLogsNum++;
        var BtnObj = Instantiate(TitleBtnPrefab, TitleListParent);
        PhoneElementBtn Btn = BtnObj.GetComponent<PhoneElementBtn>();
        Btn.Init(data);
        var PanObj = Instantiate(LogsPanelPrefab, LogsPanelParent);
        PhoneLogsPanel Pan = PanObj.GetComponent<PhoneLogsPanel>();
        Pan.Init(data);
        LogsDic[data.title] = PanObj;
        Btn.UnReadLog.SetActive(true);
        Btn.UserBtn.onClick.AddListener(delegate
        {
            OnCilckTitleBtn(Btn.Id);
            ButtonRefresh();
            Btn.OnClickLog();
        });
        BtnObj.transform.SetSiblingIndex(0);
        PanObj.SetActive(false);
        Btn.OnClickImage.SetActive(false);
        _Buttons.Add(Btn);

        data.hasIntered = true;
    }
    
    public void OnCilckTitleBtn(string key)
    {
        foreach (var Obj in LogsDic.Values)
        {
            Obj.SetActive(false);
        }
        LogsDic[key].SetActive(true);
    }
    public void ButtonRefresh()
    {
        for (int i = 0; i < _Buttons.Count; i++)
        {
            _Buttons[i].OnClickImage.SetActive(false);
        }
    }
    public readonly static string PATH = "PhonePrefab/PhoneLogsDialog";
}
