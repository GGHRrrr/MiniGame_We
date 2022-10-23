using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    //继续游戏按钮
    public Button continueGame;
    //弹出操作说明
    public Button Instruction;
    //退出游戏
    public Button ExitGame;

    //操作面板
    public GameObject InstructionPanel;

    // Start is called before the first frame update
    void Start()
    {
        continueGame.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        Instruction.onClick.AddListener(() =>
        {
            InstructionPanel.SetActive(true);
            gameObject.SetActive(false);
        });

        ExitGame.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
