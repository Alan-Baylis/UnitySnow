using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class UIManager<T> : MonoBehaviour where T:MonoBehaviour{
public class UIManager : MonoBehaviour
{
    //UISprite resourceSprite;
    UILabel snowBallLable;
    int limitSnowBall;
    int nowSnowBall;


    // Use this for initialization
    void Start () {
        //resourceSprite = findInChildren<UISprite>("ResourceSpriteUI");
        snowBallLable = findInChildren<UILabel>("SnowBallLableUI");

    }
	
	// Update is called once per frame
	void Update () {
		

	}

    public void setSnowBallLableInit(int limitSnowBall)
    {
        this.limitSnowBall = limitSnowBall;

    }
    public void setSnowBallLableI(int nowSnowBall)
    {
        snowBallLable.text = string.Format("{0}/{1}", nowSnowBall, limitSnowBall);

    }
    /*
    public void setSnowResource(float snowValue)
    {
        resourceSprite.fillAmount = snowValue;
    }
    */
    T findInChildren<T>(string name) where T:MonoBehaviour
    {
        foreach (T u in GetComponentsInChildren<T>())
        {
            if (u.gameObject.name == name)
            {
                return u;

            }
        }
        return null;
    }
    
}

