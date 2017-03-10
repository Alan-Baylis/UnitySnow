using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManager : MonoBehaviour {


    UIManager uiManager;

    const float ACCELATIONCONST = 0.1f;
    const float ROTATIONCONST = 5.0f;
    const float BULLETCOOLDOWN = 0.2f;
    const float BULLETPOSITION = 0.7f;
    const float BULLETPUPPOSITION = 0.0f;
    const float getSnowQuantityOneTime=50.0f;
    const float getSnowTime = 0.2f;

    float haveSnowResource;//가지고있는 눈의 양

    int haveSnowBallCount;
    int LimitSnowBallCount;

    float limitSnowResource;

    float snowCooldown;//눈 쏘기 쿨타임
    float getSnowCooldown;
    float oneSnowBallNeedResource;


    bool isCooldowning;//쿨다운 중인가?
    bool isGettingSnow;
    public bool IsGettingSnow
    {
        get
        {
            return isGettingSnow;
        }
        set
        {
            isGettingSnow = value;
        }
    }

    public Camera cam;
    public GameObject snowBall;
    public GameObject thisGameObject;
    GameObject bottomObject;
    SnowTerrainManager stManager;
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
        haveSnowResource = 900.0f;
        limitSnowResource = 1000.0f;
        haveSnowBallCount = 100;
        LimitSnowBallCount = 100;
        oneSnowBallNeedResource = 100.0f;
        if (cam == null)
            cam = GetComponentInChildren<Camera>();

        if (thisGameObject == null)
            thisGameObject = GetComponent<Transform>().gameObject;
        if (snowBall == null)
            snowBall = GetComponentInChildren<SnowBallManager>(true).gameObject;
        getSnowCooldown = getSnowTime;
        GameObject uiRoot = GameObject.Find("GameUIRoot");
        print(uiRoot);
        uiManager = uiRoot.GetComponent<UIManager>();
        uiManager.setSnowBallLableInit(LimitSnowBallCount);

    }
	
	// Update is called once per frame
	void Update () {
        if(isCooldowning)
            snowCooldown -= Time.deltaTime;
        if (snowCooldown < 0)
            snowCooldown = 0;
        if (snowCooldown == 0) {
            isCooldowning = false;
        }
        if (isGettingSnow)
            getSnowCooldown -= Time.deltaTime;
        if (getSnowCooldown < 0)
        {
            haveSnowResource += getSnowQuantityOneTime;
            stManager.useSnow(getSnowQuantityOneTime);
            getSnowCooldown = getSnowTime;
        }
        uiManager.setSnowBallLableI(haveSnowBallCount);
        uiManager.setSnowResource(haveSnowResource / limitSnowResource);

    }
    //쏘는 메서드
    public void shot()
    {
        if (!isCooldowning && haveSnowBallCount > 0)
        {
            haveSnowBallCount--;
            isCooldowning = true;
            GameObject newSnowBullet = Instantiate(snowBall, thisGameObject.transform.position + thisGameObject.transform.forward * BULLETPOSITION + thisGameObject.transform.up * BULLETPUPPOSITION, cam.transform.rotation);

            SnowBallManager sb = newSnowBullet.GetComponent<SnowBallManager>();
            sb.forward = cam.transform.forward;
            sb.theBody = thisGameObject;
            newSnowBullet.SetActive(true);
            snowCooldown = BULLETCOOLDOWN;
            

        }
    }
    //눈을 얻는 메서드
    public void getSnow()
    {
        if (bottomObject == null)
            return;
        stManager = bottomObject.GetComponent<SnowTerrainManager>();
        if (stManager == null)
        {
            isGettingSnow = false;
            getSnowCooldown = getSnowTime;
            return;
        }
            
        if ((haveSnowResource < limitSnowResource)&& (stManager.snowQuantity> getSnowQuantityOneTime))
        {
            isGettingSnow = true;
            
            //bottomObject.GetComponent<SnowTerrainManager>().C.a -= 0.1f;

        }
        else
        {
            isGettingSnow = false;
            //bottomObject.GetComponent<SnowTerrainManager>().C.a += 0.1f;
        }
    }
    //눈을 뭉치는 메서드
    public void reLoad()
    {
        
        if (haveSnowBallCount < LimitSnowBallCount && haveSnowResource > oneSnowBallNeedResource)
        {
            haveSnowResource -= oneSnowBallNeedResource;
            haveSnowBallCount++;
            
        }
    }
}
