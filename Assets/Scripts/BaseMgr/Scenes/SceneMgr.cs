using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : BaseManager<SceneMgr>
{
    //ͬ�����أ����볡����ȫ������ɲ���ִ�����²�����
    public void LoadScene(string name,UnityAction fun)
    {
        SceneManager.LoadScene(name);
        //������ɺ�Ż�ִ��fun
        fun();
    }

    //�첽����
    public void LoadSceneAsyn(string name,UnityAction fun)
    {
        MonoManager.Instance().StartCoroutine(ReallyLoadSceneAsyn(name, fun));
    }

    //Э���첽���س���
    private IEnumerator ReallyLoadSceneAsyn(string name,UnityAction fun)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            //����ʹ���¼����Ĺ����¼�
            EventManager.Instance().EventTrigger("����������", ao.progress);
            //������������������½������Ĳ���
            yield return ao.progress;
        }
        //������ɺ�ִ��fun
        fun();
    }
}
