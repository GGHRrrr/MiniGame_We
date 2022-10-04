using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLogsDialog : PhoneUIBase
{
    [SerializeField] public Button BackBtn;             //返回按钮

    [SerializeField] public Transform TitleListParent;  //用户按钮列表父物体
    [SerializeField] public GameObject TitleBtnPrefab;
    //private Dictionary<string,PhoneMessageUserBtn> UserBtns = new Dictionary<string,PhoneMessageUserBtn>();
    [SerializeField] public Transform LogsPanelParent;
    [SerializeField] public GameObject LogsPanelPrefab;  //消息窗口父
    private Dictionary<string, GameObject> LogsDic;

    public void Init(List<PhoneLogs> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            var BtnObj = Instantiate(TitleBtnPrefab, TitleListParent);
            PhoneElementBtn Btn = BtnObj.GetComponent<PhoneElementBtn>();
            Btn.Init(data[i]);
            var PanObj = Instantiate(LogsPanelPrefab, LogsPanelParent);
            PhoneLogsPanel Pan = PanObj.GetComponent<PhoneLogsPanel>();
            Pan.Init(data[i]);
            LogsDic[data[i].title] = PanObj;
            Btn.UserBtn.onClick.AddListener(delegate
            {
                OnCilckRitleBtn(Btn.name);
            });
            if(i!=0)
                PanObj.SetActive(false);
        }
    }

    public void OnCilckRitleBtn(string key)
    {
        foreach (var Obj in LogsDic.Values)
        {
            Obj.SetActive(false);
        }
        LogsDic[key].SetActive(true);
    }
    public readonly static string PATH = "PhonePrefab/PhoneLogsDialog";
}
