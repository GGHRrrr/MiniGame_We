using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public int sceneNum;
    public string sceneName;
    public string newScenePassWord;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //PlayerController.instance.scenePassWord = newScenePassWord;

            SceneManager.LoadScene(sceneName);

            //PlayerController.instance.XNum = sceneNum;
        }
    }
}
