using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapControll : MonoBehaviour
{
    public Scene scene;
    public List<GameObject> gameObjects;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        ShowMap();
    }
    public void ShowMapAni(int index)
    {
        switch(index)
        {
            case 0:
                gameObjects[0].gameObject.SetActive(true);
                gameObject.GetComponent<Animator>().Play("1");
                break;
            case 1:
                gameObjects[0].gameObject.SetActive(true);
                gameObjects[1].gameObject.SetActive(true);
                gameObject.GetComponent<Animator>().Play("2");
                break;
            case 2:
                gameObjects[0].gameObject.SetActive(true);
                gameObjects[1].gameObject.SetActive(true);
                gameObjects[2].gameObject.SetActive(true);
                gameObject.GetComponent<Animator>().Play("3");
                break;
            case 3:
                break;
            case 4:
                break;

        }
    }
    void ShowMap()
    {
        switch(scene.name)
        {
            case "0-beginning":
                break;
            case "1-first":
                gameObjects[0].gameObject.SetActive(true);
                break;
            case "2-two":
                gameObjects[0].gameObject.SetActive(true);
                gameObjects[1].gameObject.SetActive(true);
                break;
            case "3-three":
                gameObjects[0].gameObject.SetActive(true);
                gameObjects[1].gameObject.SetActive(true);
                gameObjects[2].gameObject.SetActive(true);
                break;
            case "4-over":
                break;
        }
    }
}
