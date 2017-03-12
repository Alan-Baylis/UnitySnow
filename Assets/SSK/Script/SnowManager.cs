using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManager : MonoBehaviour {


    //UIManager uiManager;
    public CharacterManager ctManager;

    public float snowBallCoolDownTime = 0.2f;
    public float snowBallStartPosition = 0.7f;
    public float MakeSnowBallSpeed = 0.2f;
    
    int haveSnowBallCount;
    int LimitSnowBallCount;

    float snowCooldown;//눈 쏘기 쿨타임
    float getSnowCooldown;


    bool isCooldowning;//쿨다운 중인가?
    
    public Camera cam;
    public GameObject snowBall;
    SnowTerrainManager stManager;
    
    // Use this for initialization
    void Start () {
        
        //haveSnowBallCount = 100;
        //LimitSnowBallCount = 100;
        LimitSnowBallCount=ctManager.SnowBallMagaine;
        haveSnowBallCount = LimitSnowBallCount;
        MakeSnowBallSpeed = ctManager.MakeSnowBallSpeed;
        snowBallCoolDownTime = ctManager.AttackSpeed;


        if (cam == null)
            cam = GetComponentInChildren<Camera>();
        
        if (snowBall == null)
            snowBall = GetComponentInChildren<SnowBallManager>(true).gameObject;
        getSnowCooldown = MakeSnowBallSpeed;
        //GameObject uiRoot = GameObject.Find("GameUIRoot");
        //print(uiRoot);
        //ctManager = uiRoot.GetComponent<CharacterManager>();
        ctManager = GetComponent<CharacterManager>();
        ctManager.setSnowBallLableInit(LimitSnowBallCount);

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
        if (ctManager.IsMakingSnowBall)
            getSnowCooldown -= Time.deltaTime;
        if (getSnowCooldown < 0)
        {
            haveSnowBallCount++;
            stManager.useSnow();

            getSnowCooldown = MakeSnowBallSpeed;
        }
        ctManager.setSnowBallLableI(haveSnowBallCount);
        //ctManager.setSnowResource(haveSnowResource / limitSnowResource);

    }
    //쏘는 메서드
    public void shot()
    {
        if (!isCooldowning && haveSnowBallCount > 0)
        {
            haveSnowBallCount--;
            isCooldowning = true;
            GameObject newSnowBullet = Instantiate(snowBall, ctManager.ThisGameObject.transform.position + ctManager.ThisGameObject.transform.forward * snowBallStartPosition + ctManager.ThisGameObject.transform.up, cam.transform.rotation);

            SnowBallManager sb = newSnowBullet.GetComponent<SnowBallManager>();
            sb.forward = cam.transform.forward;
            sb.theBody = ctManager.ThisGameObject;
            newSnowBullet.SetActive(true);
            snowCooldown = snowBallCoolDownTime;
            

        }
    }
    //스노우볼을 얻는 메서드
    public void makeSnowBall()
    {
        if (ctManager.BottomObject == null)
            return;
        stManager = ctManager.BottomObject.GetComponent<SnowTerrainManager>();
        if (stManager == null)
        {
            ctManager.IsMakingSnowBall = false;
            getSnowCooldown = MakeSnowBallSpeed;
            return;
        }

               
        if (haveSnowBallCount < LimitSnowBallCount &&stManager.CanGetSnow)
        {
            ctManager.IsMakingSnowBall = true;
            
            
        }
        else
        {
            ctManager.IsMakingSnowBall = false;
        }
    }

    public void setInit()
    {

    }
}
