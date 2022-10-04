using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PhoneUIHandler : MonoBehaviour
{
    private PhoneItemDialog mphoneItemDialog;
    private PhoneWindowDialog mphoneWindowDialog;
    private PhoneMessageDialog mphoneMessageDialog;
    private PhoneLogsDialog mphoneLogsDialog;
    private GameObject Parent;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        Parent = GameObject.Find("Canvas");
        mphoneItemDialog = CreateDialog<PhoneItemDialog>(PhoneItemDialog.PATH, Parent.GetComponent<Transform>());
        mphoneWindowDialog = CreateDialog<PhoneWindowDialog>(PhoneWindowDialog.PATH, Parent.GetComponent<Transform>());
        mphoneMessageDialog = CreateDialog<PhoneMessageDialog>(PhoneMessageDialog.PATH, Parent.GetComponent<Transform>());
        mphoneLogsDialog = CreateDialog<PhoneLogsDialog>(PhoneLogsDialog.PATH, Parent.GetComponent<Transform>());
        
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
    }

    public void OnClickItem()
    {
        mphoneItemDialog.Hide();
        mphoneWindowDialog.Show();
    }

    public void OnClickMessage()
    {
        mphoneWindowDialog.Hide();
        mphoneMessageDialog.Show();
    }

    public void OnClickMessageBack()
    {
        mphoneWindowDialog.Show();
        mphoneMessageDialog.Hide();
    }

    public void OnClickLogs()
    {
        mphoneItemDialog.Hide();
        mphoneLogsDialog.Show();
    }
    
    public void OnClickLogsBack()
    {
        mphoneItemDialog.Show();
        mphoneLogsDialog.Hide();
    }

    public void OnClickOut()
    {
        mphoneWindowDialog.Hide();
        mphoneMessageDialog.Hide();
        mphoneLogsDialog.Hide();
        mphoneItemDialog.Show();
    }

    public T CreateDialog<T>(string Path,Transform Parent)
    {
        GameObject prefab = Resources.Load(Path) as GameObject;
        GameObject obj = Instantiate(prefab, Parent);
        T dialog = obj.GetComponent<T>();
        return dialog;
    }
}
