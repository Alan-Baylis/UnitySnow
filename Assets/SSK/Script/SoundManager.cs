using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    bool isOnSnow;
    public bool IsOnSnow{
        get
        {
            return isOnSnow;
        }
        set
        {
            isOnSnow = value;
        }
    }
    bool isWalking;
    AudioSource walkSoilSoundSource;
    AudioSource walkSnowSoundSource;
    GameObject bottomObject;
    public GameObject BottomObject
    {
        get
        {
            return bottomObject;
        }
        set
        {
            bottomObject = value;
        }
    }

    // Use this for initialization
    void Start () {
        foreach (AudioSource audio in GetComponents<AudioSource>())
        {
            if (audio.clip.name == "walkOnSoil")
                walkSoilSoundSource = audio;
            if (audio.clip.name == "walkOnSnow")
                walkSnowSoundSource = audio;


        }

    }
	
	// Update is called once per frame
	void Update () {
        if ( (bottomObject != null) && 
            (bottomObject.transform.gameObject.layer == LayerMask.NameToLayer("snowTerrain")) )
        {
            isOnSnow = true;
        }
        else
        {
            isOnSnow = false;
        }
        if (isWalking)
        {
            //if
            if (IsOnSnow)
            {
                if (!walkSnowSoundSource.isPlaying)
                {
                    walkSnowSoundSource.Play();
                }
            }else
            {
                if (!walkSoilSoundSource.isPlaying)
                {
                    walkSoilSoundSource.Play();
                }

            }
        }else
        {
            walkSoilSoundSource.Stop();
            walkSnowSoundSource.Stop();
        }
		
	}
    public void playWalkingSound()
    {
        isWalking = true;
    }
    public void stopWalkingSound()
    {
        isWalking = false;

    }
}
