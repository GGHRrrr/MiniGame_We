using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CGControll : MonoBehaviour
{
    public Animator black;
    public GameObject d;
    public bool isBlackTrue=false;
    public GameObject player;
    public GameObject ca;
    private void Start()
    {
        StartCoroutine(CGcontroll());
    }

    private void Update()
    {
        if(isBlackTrue&& Input.GetKeyDown(KeyCode.D))
        {
            d.gameObject.SetActive(false);
            StartCoroutine(PlayerControll());
        }
    }
    IEnumerator CGcontroll()
    {
        yield return null;
        AnimatorStateInfo stateinfo= black.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("black") && (stateinfo.normalizedTime > 1.0f))
        {
            isBlackTrue = true;
            black.gameObject.SetActive(false);
        }
            else
        {
            StartCoroutine(CGcontroll());
        }

    }
    IEnumerator PlayerControll()
    {
        gameObject.GetComponent<Animator>().SetBool("walk", true);
        gameObject.GetComponent<Animator>().speed = 0.8f;
        player.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        ca.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(7f);
        int num = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(num + 1);
    }
}
