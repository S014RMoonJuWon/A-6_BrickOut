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
        playSoundName = new string[audioSourcesEffects.Length]; //이펙트 숫자만큼 생성
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
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }
    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectsSound.Length; i++)
        {
            if (_name == effectsSound[i].name)
            {
                for(int j = 0; j < audioSourcesEffects.Length; j++)
                {
                    playSoundName[j] = effectsSound[i].name; //효과음넣어주기
                    audioSourcesEffects[j].clip = effectsSound[i].clip;
                    audioSourcesEffects[j].Play();
                    return;
                }
                Debug.Log("모든 audiosouce 사용중");
                return;
            }
        }
        Debug.Log(_name + "사운드가 soundManager에 등록되지 않았습니다");
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
        Debug.Log("재생중인 " + _name + "사운드가 없습니다");
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