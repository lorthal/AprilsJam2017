using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite level0Sprite;
    public Sprite level1Sprite;
    public Sprite level2Sprite;
    public Sprite level3Sprite;

    public enum SoundLevel
    {
        LEVEL0,
        LEVEL1,
        LEVEL2,
        LEVEL3
    }

    public Button soundButton;
    private AudioSource[] audioSources;
    private SoundLevel soundLvl;
    public SoundLevel SoundLvl
    {
        get
        {
            return soundLvl;
        }
        set
        {
            soundLvl = value;
            audioSources = FindObjectsOfType<AudioSource>();
            switch (soundLvl)
            {
                case SoundLevel.LEVEL0:
                    {
                        foreach(AudioSource aS in audioSources)
                        {
                            aS.volume = 0.0f;
                        }
                    }
                    break;
                case SoundLevel.LEVEL1:
                    {
                        foreach (AudioSource aS in audioSources)
                        {
                            aS.volume = 0.25f;
                        }
                    }
                    break;
                case SoundLevel.LEVEL2:
                    {
                        foreach (AudioSource aS in audioSources)
                        {
                            aS.volume = 0.75f;
                        }
                    }
                    break;
                case SoundLevel.LEVEL3:
                    {
                        foreach (AudioSource aS in audioSources)
                        {
                            aS.volume = 1.0f;
                        }
                    }
                    break;
            }
        }
    }
    

    private void Start()
    {
        SoundLvl = SoundLevel.LEVEL2;
        soundButton.onClick.AddListener(OnSoundButtonClick);
    }

    private void OnSoundButtonClick()
    {
        switch (SoundLvl)
        {
            case SoundLevel.LEVEL0:
                {
                    SoundLvl = SoundLevel.LEVEL1;
                    soundButton.image.sprite = level1Sprite;
                }
                break;
            case SoundLevel.LEVEL1:
                {
                    SoundLvl = SoundLevel.LEVEL2;
                    soundButton.image.sprite = level2Sprite;
                }
                break;
            case SoundLevel.LEVEL2:
                {
                    SoundLvl = SoundLevel.LEVEL3;
                    soundButton.image.sprite = level3Sprite;
                }
                break;
            case SoundLevel.LEVEL3:
                {
                    SoundLvl = SoundLevel.LEVEL0;
                    soundButton.image.sprite = level0Sprite;
                }
                break;
        }
    }
}
