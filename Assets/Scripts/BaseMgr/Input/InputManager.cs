using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseManager<InputManager>
{
    //是否开启该模块功能
    private bool isStart = true;

    public InputManager()
    {
        MonoManager.Instance().AddUpdateListener(InputUpdate);
    }

    //切换开启状态
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

    //检测按键函数
    private void CheckKeyCode(KeyCode keycode)
    {
        if (Input.GetKeyDown(keycode))
        {
            //事件中心分发按下抬起
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
