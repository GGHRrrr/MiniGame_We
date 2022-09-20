using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicManager : BaseManager<MusicManager>
{
    //背景音乐
    private AudioSource BGM = null;
    //BGM响度
    private float BGMVolume = 1;

    //音效模块
    private GameObject soundObj = null;
    private List<AudioSource> soundList = new List<AudioSource>();
    //音效响度
    private float SoundVolume = 1;

    //此处注意，由于单循环次音效无法判断自己是否播放完成，需要手动使用Update检测是否播放完成
    public MusicManager()
    {
        MonoManager.Instance().AddUpdateListener(Update);
    }

    private void Update()
    {
        for (int i = 0;i < soundList.Count;i++)
        {
            if (!soundList[i].isPlaying)
            {
                GameObject.Destroy(soundList[i]);
                soundList.Remove(soundList[i]);
            }
        }
    }


    //播放背景音乐
    public void PlayBGM(string name)
    {
        if (BGM == null)
        {
            GameObject obj = new GameObject("BGM");
            BGM = obj.AddComponent<AudioSource>();
        }
        //异步加载音乐资源
        ResourcesManager.Instance().LoadAsync<AudioClip>("Music/BGM/" + name, (clip) =>
         {
             BGM.clip = clip;
             BGM.volume = BGMVolume;
             BGM.loop = true; // 设置循环播放
             BGM.Play();
         });

    }

    //暂停背景音乐
    public void PauseBGM(string name)
    {
        if (BGM == null) return;
        BGM.Pause();
    }

    //停止背景音乐
    public void StopBGM(string name)
    {
        if (BGM == null) return;
        BGM.Stop();
    }

    //设置音量大小
    public void ChangeBGMVolume(float v)
    {
        BGMVolume = v;
        if (BGM == null) return;
        BGM.volume = BGMVolume;
    }

    //播放音效
    public void PlaySound(string name,bool isLoop,UnityAction<AudioSource> callback = null)
    {
        //参数引入一个callback回调，如果调用函数时需要拿到音效进行操作，可使用callback
        if (soundObj == null)
        {
            soundObj = new GameObject("Sound");
        }
        //当音效资源异步加载后 再添加一个音效
        ResourcesManager.Instance().LoadAsync<AudioClip>("Sound/" + name, (clip) =>
        {
            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.loop = isLoop; // 设置是否循环
            source.clip = clip;
            source.volume = SoundVolume;
            source.Play();
            soundList.Add(source);

            //如果检测到回调函数不为空，则回调
            if (callback != null) callback(source);
        });

    }

    //停止音效
    public void StopSound(AudioSource source)
    {
        if (soundList.Contains(source))
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }

    //改变所有音效的响度
    public void ChangeSoundVolume(float v)
    {
        SoundVolume = v;
        foreach(AudioSource source in soundList)
        {
            source.volume = v;
        }
    }
    
}
