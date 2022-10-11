using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseManager<InputManager>
{
    //�Ƿ�����ģ�鹦��
    private bool isStart = false;

    public InputManager()
    {
        MonoManager.Instance().AddUpdateListener(InputUpdate);
    }

    //�л�����״̬
    public void SwitchStates(bool isOpen)
    {
        isStart = isOpen;
    }

    private void InputUpdate()
    {
        if (!isStart) return;
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.D);

        CheckKeyCode(KeyCode.Tab);
        CheckKeyCode(KeyCode.F);
    }

    //��ⰴ������
    private void CheckKeyCode(KeyCode keycode)
    {
        if (Input.GetKeyDown(keycode))
        {
            //�¼����ķַ�����̧��
            EventManager.Instance().EventTrigger("KeyDown", keycode);
        }else if (Input.GetKeyUp(keycode))
        {
            EventManager.Instance().EventTrigger("KeyUp", keycode);
        }else if (Input.GetKey(keycode))
        {
            EventManager.Instance().EventTrigger("Key", keycode);
        }
    }
}
