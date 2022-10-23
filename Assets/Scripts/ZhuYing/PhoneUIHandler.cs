using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PhoneUIHandler : MonoBehaviour
{
    private PhoneItemDialog mphoneItemDialog;
    private PhoneWindowDialog mphoneWindowDialog;
    private PhoneMessageDialog mphoneMessageDialog;
    private PhoneLogsDialog mphoneLogsDialog;
    private GameObject Parent;

    private bool HasInit = false;
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Test
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            EventManager.Instance().EventTrigger(EventTypeEnum.INTER_LOG.ToString(),1);
        if(Input.GetKeyDown(KeyCode.J))
            EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                new KeyValuePair<string,int>("Alice",1));
    }

    public void Init()
    {
        if (HasInit) return;
        PhoneModel.Instance().Init();
        Parent = GameObject.Find("PhoneCanvas");
        mphoneItemDialog = CreateDialog<PhoneItemDialog>(PhoneItemDialog.PATH, Parent.GetComponent<Transform>());
        mphoneWindowDialog = CreateDialog<PhoneWindowDialog>(PhoneWindowDialog.PATH, Parent.GetComponent<Transform>());
        mphoneMessageDialog = CreateDialog<PhoneMessageDialog>(PhoneMessageDialog.PATH, Parent.GetComponent<Transform>());
        mphoneLogsDialog = CreateDialog<PhoneLogsDialog>(PhoneLogsDialog.PATH, Parent.GetComponent<Transform>());

        EventManager.Instance().AddEventListener(EventTypeEnum.INTER_LOG.ToString(), InterLogs);
        EventManager.Instance().AddEventListener(EventTypeEnum.INTER_MESSAGE.ToString(), InterMessages);
        
        
        mphoneItemDialog.Init();
        mphoneWindowDialog.Init();
        mphoneMessageDialog.Init();
        mphoneLogsDialog.Init();
        
        mphoneItemDialog.Show();
        mphoneItemDialog.phoneButton.onClick.AddListener(OnClickItem);
        mphoneWindowDialog.outBtn.onClick.AddListener(OnClickOut);

        mphoneWindowDialog.messageBtn.onClick.AddListener(OnClickMessage);
        mphoneMessageDialog.BackBtn.onClick.AddListener(OnClickMessageBack);
        
        mphoneWindowDialog.logsBtn.onClick.AddListener(OnClickLogs);
        mphoneLogsDialog.BackBtn.onClick.AddListener(OnClickLogsBack);
        
        DontDestroyOnLoad(Parent);
        DontDestroyOnLoad(this);

        HasInit = true;
    }

    public void InterLogs(object ID)
    {
        int id = (int)ID;
        mphoneLogsDialog.InterNewLog(id);
        mphoneItemDialog.RefreshIcon();
    }

    public void InterMessages(object NameID)
    {
        KeyValuePair<string, int> nameID = (KeyValuePair<string, int>) NameID;
        mphoneMessageDialog.InterNewMessage(nameID);
        mphoneItemDialog.RefreshIcon();
        
    }

    #region ¥∞ø⁄œ‘ æ…Ë÷√

    public void OnClickItem()
    {
        mphoneItemDialog.Hide();
        mphoneWindowDialog.Show();
    }

    public void OnClickMessage()
    {
        mphoneMessageDialog.Show();
        mphoneWindowDialog.Hide();
    }

    public void OnClickMessageBack()
    {
        mphoneWindowDialog.Show();
        mphoneMessageDialog.Hide();
    }

    public void OnClickLogs()
    {
        mphoneLogsDialog.Show();
        mphoneWindowDialog.Hide();
    }
    
    public void OnClickLogsBack()
    {
        mphoneWindowDialog.Show();
        mphoneLogsDialog.Hide();
    }

    public void OnClickOut()
    {
        mphoneWindowDialog.Hide();
        mphoneMessageDialog.Hide();
        mphoneLogsDialog.Hide();
        mphoneItemDialog.Show();
    }

    #endregion

    public T CreateDialog<T>(string Path,Transform Parent)
    {
        GameObject prefab = Resources.Load(Path) as GameObject;
        GameObject obj = Instantiate(prefab, Parent);
        T dialog = obj.GetComponent<T>();
        return dialog;
    }
}
