using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //开局播放BGM
        MusicManager.Instance().PlayBGM("废城");
    }
}
