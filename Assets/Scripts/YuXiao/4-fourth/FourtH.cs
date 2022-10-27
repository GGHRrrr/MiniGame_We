using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FourtH : MonoBehaviour
{
    public Button btn_return;

    void Start()
    {
        btn_return.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync(0);
        });
    }
}
