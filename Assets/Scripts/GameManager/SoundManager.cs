using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(this.gameObject);
    }

    public AudioSource[] audioSourcesEffects;
    public AudioSource audioSourcesBgm;

    public Sound[] effectsSound;
    public Sound[] bgmSounds;

    public string[] playSoundName;

    private void Start()
    {
        playSoundName = new string[audioSourcesEffects.Length]; //����Ʈ ���ڸ�ŭ ����
    }
    public void PlayBGM(string _name)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (_name == bgmSounds[i].name)
            {
                audioSourcesBgm.clip = bgmSounds[i].clip;
                audioSourcesBgm.Play();
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
    }
    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectsSound.Length; i++)
        {
            if (_name == effectsSound[i].name)
            {
                for(int j = 0; j < audioSourcesEffects.Length; j++)
                {
                    playSoundName[j] = effectsSound[i].name; //ȿ�����־��ֱ�
                    audioSourcesEffects[j].clip = effectsSound[i].clip;
                    audioSourcesEffects[j].Play();
                    return;
                }
                Debug.Log("��� audiosouce �����");
                return;
            }
        }
        Debug.Log(_name + "���尡 soundManager�� ��ϵ��� �ʾҽ��ϴ�");
    }
    public void StopAllSE()
    {
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].Stop();
        }
    }
    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            if (playSoundName[i] == _name)
            {
                audioSourcesEffects[i].Stop();
                break;
            }
            
        }
        Debug.Log("������� " + _name + "���尡 �����ϴ�");
    }
    public void StopBgm(string _name)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (_name == bgmSounds[i].name)
            {
                audioSourcesBgm.clip = bgmSounds[i].clip;
                audioSourcesBgm.Stop();
                return;
            }
        }
    }
}