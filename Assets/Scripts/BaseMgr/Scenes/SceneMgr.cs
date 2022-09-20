using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : BaseManager<SceneMgr>
{
    //同步加载（必须场景完全加载完成才能执行以下操作）
    public void LoadScene(string name,UnityAction fun)
    {
        SceneManager.LoadScene(name);
        //加载完成后才会执行fun
        fun();
    }

    //异步加载
    public void LoadSceneAsyn(string name,UnityAction fun)
    {
        MonoManager.Instance().StartCoroutine(ReallyLoadSceneAsyn(name, fun));
    }

    //协程异步加载场景
    private IEnumerator ReallyLoadSceneAsyn(string name,UnityAction fun)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            //可以使用事件中心管理事件
            EventManager.Instance().EventTrigger("进度条更新", ao.progress);
            //在这里面可以做到更新进度条的操作
            yield return ao.progress;
        }
        //加载完成后，执行fun
        fun();
    }
}
