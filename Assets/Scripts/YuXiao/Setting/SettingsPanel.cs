using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    //������Ϸ��ť
    public Button continueGame;
    //��������˵��
    public Button Instruction;
    //�˳���Ϸ
    public Button ExitGame;

    //�������
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
