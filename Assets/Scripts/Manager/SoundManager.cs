using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource[] audioSources = new AudioSource[(int)Define.Sound.Count];
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
    public AudioClip prevBgm;
    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
        AudioSource a1 = GameManager.Resource.Instantiate<AudioSource>("Sounds/SFX");
        a1.name = soundNames[(int)Define.Sound.Effect];
        audioSources[(int)Define.Sound.Effect] = a1;
        a1.transform.SetParent(transform);
        AudioSource a2 = GameManager.Resource.Instantiate<AudioSource>("Sounds/BGM");
        a2.name = soundNames[(int)Define.Sound.Bgm];
        audioSources[(int)Define.Sound.Bgm] = a2;
        a2.transform.SetParent(transform);
    }
    public void Clear()
    {
        // ����� ���� ��� ��ž, ���� ����
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        // ȿ���� Dictionary ����
        audioClips.Clear();
    }
    public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (type == Define.Sound.Bgm) // BGM ������� ���
        {
            AudioSource audioSource = audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();
            prevBgm = audioSource.clip;

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else // Effect ȿ���� ���
        {
            AudioSource audioSource = audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }
    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}"; // Sound ���� �ȿ� ����� �� �ֵ���

        AudioClip audioClip = null;

        if (type == Define.Sound.Bgm) // BGM ������� Ŭ�� ���̱�
        {
            audioClip = GameManager.Resource.Load<AudioClip>(path);
        }
        else // Effect ȿ���� Ŭ�� ���̱�
        {
            if (audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = GameManager.Resource.Load<AudioClip>(path);
                audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    }
}
