using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//面板基类
//需要找到所有自己面板下的对象
//提供显示或隐藏的接口
public class BasePanel : MonoBehaviour
{
    //里式转换原则
    //使用字典存储UI组件
    private Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();

    void Awake()
    {
        FindChildrenControl<Button>();
        FindChildrenControl<Image>();
        FindChildrenControl<Text>();
        FindChildrenControl<Toggle>();
        FindChildrenControl<Slider>();
    }

    public virtual void ShowMe()
    {

    }

    public virtual void HideMe()
    {

    }


    //得到对应名字的对应控件
    protected T GetControl<T>(string controlName) where T : UIBehaviour
    {
        if (controlDic.ContainsKey(controlName))
        {
            for(int i = 0;i < controlDic[controlName].Count; i++)
            {
                if (controlDic[controlName][i] is T)
                {
                    return controlDic[controlName][i] as T;
                }
            }
        }
        return null;
    }

    //找到子对象的对应控件
    private void FindChildrenControl<T>() where T : UIBehaviour
    {
        T[] controls = GetComponentsInChildren<T>();
        string objName;

        for (int i = 0;i < controls.Length; i++)
        {
            objName = controls[i].gameObject.name;
            if (controlDic.ContainsKey(objName))
            {
                controlDic[objName].Add(controls[i]);
            }
            else
            {
                controlDic.Add(objName, new List<UIBehaviour>() { controls[i] });
            }
        }
    }
}
