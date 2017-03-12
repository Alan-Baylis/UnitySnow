using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    protected RigidbodyFirstPersonController rigidFPSController;
    protected SnowManager snowManager;
    protected SoundManager soundManager;
    protected AnimScript animScript;
    protected UIManager uiManager;
    protected GameObject thisGameObject;
    protected GameObject bottomObject;

    protected float moveSpeed;
    protected float makeSnowBallSpeed;
    protected int hp;
    protected int snowBallMagaine;
    protected float attackPower;
    protected float attackSpeed;
    protected bool weaponState;

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
    }
    public float MakeSnowBallSpeed
    {
        get
        {
            return makeSnowBallSpeed;
        }
    }
    public int HP
    {
        get
        {
            return hp;
        }
    }
    public int SnowBallMagaine
    {
        get
        {
            return snowBallMagaine;
        }
    }
    public float AttackPower
    {
        get
        {
            return AttackPower;
        }
    }
    public float AttackSpeed
    {
        get
        {
            return attackPower;
        }
    }
    public bool WeaponState
    {
        get
        {
            return weaponState;
        }
    }

    //protected item haveItem;

    bool isMakingSnowBall;


    public bool IsMakingSnowBall
    {
        get
        {
            return isMakingSnowBall;
        }
        set
        {
            isMakingSnowBall = value;
        }
    }
    public GameObject ThisGameObject
    {
        get
        {
            return thisGameObject;
        }
    }
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
        initState();

    }
    protected void initState()
    {
        rigidFPSController = GetComponent<RigidbodyFirstPersonController>();
        snowManager = GetComponent<SnowManager>();
        soundManager = GetComponent<SoundManager>();
        animScript = GetComponent<AnimScript>();
        GameObject uiRoot = GameObject.Find("GameUIRoot");
        //print(uiRoot);
        uiManager = uiRoot.GetComponent<UIManager>();
        thisGameObject = transform.gameObject;
        rigidFPSController.ctManager = this;
        snowManager.ctManager = this;
        soundManager.ctManager = this;
        animScript.ctManager = this;
    }
    protected virtual void initValue()
    {
        moveSpeed = 1.0f;
        makeSnowBallSpeed=0.1f;
        hp=100;
        snowBallMagaine=50;
        attackPower=2;
        attackSpeed=0.1f;
        weaponState=false;
    }
    // Update is called once per frame
    void Update () {
		
	}
    //UIManager

    public void setSnowBallLableInit(int value)
    {
        uiManager.setSnowBallLableInit(value);
    }

    public void setSnowBallLableI(int value)
    {
        uiManager.setSnowBallLableI(value);
    }

    //snowManager
    public virtual void shot()
    {
        snowManager.shot();
    }
    public void makeSnowBall()
    {
        snowManager.makeSnowBall();
    }
    


    //soundManager
    public void playWalkingSound()
    {
        soundManager.playWalkingSound();
    }
    public void stopWalkingSound()
    {
        soundManager.stopWalkingSound();
    }


}
