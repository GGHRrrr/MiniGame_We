using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicManager : BaseManager<MusicManager>
{
    //��������
    private AudioSource BGM = null;
    //BGM���
    private float BGMVolume = 1;

    //��Чģ��
    private GameObject soundObj = null;
    private List<AudioSource> soundList = new List<AudioSource>();
    //��Ч���
    private float SoundVolume = 1;

    //�˴�ע�⣬���ڵ�ѭ������Ч�޷��ж��Լ��Ƿ񲥷���ɣ���Ҫ�ֶ�ʹ��Update����Ƿ񲥷����
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


    //���ű�������
    public void PlayBGM(string name)
    {
        if (BGM == null)
        {
            GameObject obj = new GameObject("BGM");
            BGM = obj.AddComponent<AudioSource>();
        }
        //�첽����������Դ
        ResourcesManager.Instance().LoadAsync<AudioClip>("Audio/BGM/" + name, (clip) =>
         {
             BGM.clip = clip;
             BGM.volume = BGMVolume;
             BGM.loop = true; // ����ѭ������
             BGM.Play();
         });

    }

    //��ͣ��������
    public void PauseBGM(string name)
    {
        if (BGM == null) return;
        BGM.Pause();
    }

    //ֹͣ��������
    public void StopBGM(string name)
    {
        if (BGM == null) return;
        BGM.Stop();
    }

    //����������С
    public void ChangeBGMVolume(float v)
    {
        BGMVolume = v;
        if (BGM == null) return;
        BGM.volume = BGMVolume;
    }

    //������Ч
    public void PlaySound(string name,bool isLoop,UnityAction<AudioSource> callback = null)
    {
        //��������һ��callback�ص���������ú���ʱ��Ҫ�õ���Ч���в�������ʹ��callback
        if (soundObj == null)
        {
            soundObj = new GameObject("Sound");
        }
        //����Ч��Դ�첽���غ� �����һ����Ч
        ResourcesManager.Instance().LoadAsync<AudioClip>("Audio/Sound/" + name, (clip) =>
        {
            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.loop = isLoop; // �����Ƿ�ѭ��
            source.clip = clip;
            source.volume = SoundVolume;
            source.Play();
            soundList.Add(source);

            //�����⵽�ص�������Ϊ�գ���ص�
            if (callback != null) callback(source);
        });

    }

    //ֹͣ��Ч
    public void StopSound(AudioSource source)
    {
        if (soundList.Contains(source))
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }

    //�ı�������Ч�����
    public void ChangeSoundVolume(float v)
    {
        SoundVolume = v;
        foreach(AudioSource source in soundList)
        {
            source.volume = v;
        }
    }
    
}
