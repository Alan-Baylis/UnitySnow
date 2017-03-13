using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManager : MonoBehaviour {


    //UIManager uiManager;
    public CharacterManager ctManager;

    public float snowBallCoolDownTime;
    public float snowBallStartPosition;
    public float MakeSnowBallSpeed;
    
    int haveSnowBallCount;
    int LimitSnowBallCount;

    float snowCooldownTimer;//눈 쏘기 쿨타임
    float makeSnowBallCooldownTimer;


    bool isCooldowning;//쿨다운 중인가?
    
    public Camera cam;
    public GameObject snowBall;
    SnowTerrainManager stManager;
    
    // Use this for initialization
    void Start () {
        LimitSnowBallCount = ctManager.SnowBallMagaine;
        haveSnowBallCount = LimitSnowBallCount;
        MakeSnowBallSpeed = ctManager.MakeSnowBallSpeed;
        snowBallCoolDownTime = ctManager.AttackSpeed;
        makeSnowBallCooldownTimer = MakeSnowBallSpeed;
        ctManager.setSnowBallLableInit(LimitSnowBallCount);

        if (cam == null)
            cam = GetComponentInChildren<Camera>();
        
        if (snowBall == null)
            snowBall = GetComponentInChildren<SnowBallManager>(true).gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        if (isCooldowning)
        {
            snowCooldownTimer -= Time.deltaTime;
            //print(snowCooldownTimer);
        }
        if (snowCooldownTimer <= 0 && isCooldowning) {
            snowCooldownTimer = 0;
            isCooldowning = false;
        }
        if (ctManager.State == CharacterState.Channeling && makeSnowBallCooldownTimer>0)
            makeSnowBallCooldownTimer -= Time.deltaTime;
        if (makeSnowBallCooldownTimer < 0)
        {
            haveSnowBallCount++;
            stManager.useSnow();

            makeSnowBallCooldownTimer = MakeSnowBallSpeed;
        }
        ctManager.setSnowBallLableI(haveSnowBallCount);

    }
    private void FixedUpdate()
    {

    }    //쏘는 메서드
    public void shot(int damage)
    {
        if (!isCooldowning && haveSnowBallCount > 0)
        {
            haveSnowBallCount--;
            isCooldowning = true;
            GameObject newSnowBullet = Instantiate(snowBall, 
                ctManager.ThisGameObject.transform.position + ctManager.ThisGameObject.transform.forward * snowBallStartPosition + ctManager.ThisGameObject.transform.up*0.5f, 
                cam.transform.rotation);

            SnowBallManager sb = newSnowBullet.GetComponent<SnowBallManager>();
            sb.initSnowBall(cam.transform.forward, damage);
            newSnowBullet.SetActive(true);
            snowCooldownTimer = snowBallCoolDownTime;
            

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
            //ctManager.IsMakingSnowBall = false;
            ctManager.State = CharacterState.Normal;
            makeSnowBallCooldownTimer = MakeSnowBallSpeed;
            return;
        }

               
        if (haveSnowBallCount < LimitSnowBallCount &&stManager.CanGetSnow)
        {
            ctManager.State = CharacterState.Channeling;


        }
        else
        {
            ctManager.State = CharacterState.Normal;
        }
    }

    public void setInit()
    {

    }
}
