using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginControll : MonoBehaviour
{
    //过场动画
    private 
    Camera minCamera;//特写摄像机
    Camera mainCamera;//主摄像机
    GameObject openingAniPoint;//开场动画
    GameObject player;//角色
    private void Start()
    {
        minCamera = GameObject.Find("MinCamera").GetComponent<Camera>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        openingAniPoint = GameObject.Find("Opening_Animation");
        player = GameObject.Find("Player");
        StartCoroutine(PlayOpenningAni());
    }
    /// <summary>
    /// 开始过场动画，易拉罐特写切换等
    /// </summary>
    /// <returns></returns>
   IEnumerator PlayOpenningAni()
    {
        yield return new WaitForSecondsRealtime(2f) ;
        Animator opAni = openingAniPoint.transform.GetChild(0).GetComponent<Animator>();
        AnimatorStateInfo stateinfo = opAni.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("yilaguanAni") && (stateinfo.normalizedTime > 1.0f))
        {
            minCamera.GetComponent<Animator>().SetBool("isBegin", true);
            yield return new WaitForSecondsRealtime(2f);
            minCamera.gameObject.SetActive(false);
            mainCamera.enabled = true;
            mainCamera.gameObject.GetComponent<CameraFollow>().enabled = true;
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Animator>().Play("fade");
        }
        else
        {
            StartCoroutine(PlayOpenningAni());
        }
    }
}
