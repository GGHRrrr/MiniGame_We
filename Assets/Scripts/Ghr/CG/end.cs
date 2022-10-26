using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class end : MonoBehaviour
{
    Button btn;
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
