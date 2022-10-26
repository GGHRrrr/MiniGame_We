using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FourthController : MonoBehaviour
{

    public List<GameObject> cgList;
    public GameObject e;
    public GameObject post;
    public GameObject yiyi;
    bool isEnterRoom = false;
    private GameObject bag;
    private GameObject ca;
    public GameObject end;
    private GameObject PhoneCanvas;

    bool fisScrolling = false;
   public  Text txt_dialogue;
    public string[] dialogueLines;
    [SerializeField] private int currentLine = 0;
    void Start()
    {
        //开局播放BGM
        MusicManager.Instance().PlayBGM("废城");
        bag = GameObject.Find("BagCanvas").gameObject;
        ca = GameObject.Find("Main Camera").gameObject;
        PhoneCanvas = GameObject.Find("PhoneCanvas").gameObject;
    }
    private void Update()
    {
        if(isEnterRoom&&Input.GetKeyDown(KeyCode.E))
        {
            ca.transform.position = new Vector3(17.3f, ca.transform.position.y, ca.transform.position.z);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.GetComponent<PlayerMove>().enabled = false;
            gameObject.GetComponent<SwitchRole>().enabled = false;
            ca.GetComponent<CameraFollow>().enabled = false;
            yiyi.SetActive(false);
            bag.SetActive(false);
            PhoneCanvas.SetActive(false);
            post.SetActive(true);
            cgList[0].gameObject.SetActive(true);
            txt_dialogue.gameObject.SetActive(true);
            StartCoroutine(startAni());
        }
    }

    IEnumerator startAni()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(ScrollingText());
        yield return new WaitForSeconds(35f);
        txt_dialogue.gameObject.SetActive(false);
        cgList[0].gameObject.SetActive(false);
        cgList[1].gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        cgList[1].gameObject.SetActive(false);
        cgList[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        end.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(6);
    }
    private IEnumerator ScrollingText()
    {
        fisScrolling = true;
        txt_dialogue.text = "";

        while(currentLine<5)
        {
            foreach (char letter in dialogueLines[currentLine].ToCharArray())
            {
                txt_dialogue.text += letter;
                yield return new WaitForSeconds(0.15f);
            }
            currentLine++;
        }
        fisScrolling = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "room":
                isEnterRoom = true;
                e.SetActive(true);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "room":
                isEnterRoom = false;
                e.SetActive(false);
                break;
        }
    }
}
