using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaidanPanel : MonoBehaviour
{
    public Button quit;

    // Start is called before the first frame update
    void Start()
    {
        quit.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
