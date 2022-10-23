using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour
{

    public Button quit;

    public GameObject SettingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        quit.onClick.AddListener(() =>
        {
            SettingsPanel.SetActive(true);
            gameObject.SetActive(false);
        });
    }
}
