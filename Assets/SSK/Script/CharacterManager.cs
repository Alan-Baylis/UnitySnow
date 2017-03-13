using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CharacterState { Normal, Channeling, Stun }

public abstract class CharacterManager : MonoBehaviour {
    
    
    protected RigidbodyFirstPersonController rigidFPSController;
    protected SnowManager snowManager;
    protected SoundManager soundManager;
    protected AnimScript animScript;
    protected UIManager uiManager;
    protected GameObject thisGameObject;
    protected GameObject bottomObject;
    CharacterState state;
    protected float moveSpeed;
    protected float makeSnowBallSpeed;
    protected int hp;
    protected int snowBallMagaine;
    protected int attackPower;
    protected float attackSpeed;
    protected bool weaponState;
    protected GameObject cam;
    float stunTimer;

    public bool isPlayer;

    float shot2CoolDownTime;

    public CharacterState State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }
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
    public int AttackPower
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
            return attackSpeed;
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


    void Awake()
    {
        initState(isPlayer);
    }
    // Use this for initialization
    void Start () {
        

    }
    protected void initState(bool isPlayer)
    {
        thisGameObject = transform.gameObject;
        cam = transform.FindChild("MainCamera").gameObject;
        if (isPlayer)
        {
            rigidFPSController = thisGameObject.AddComponent<RigidbodyFirstPersonController>();
            rigidFPSController.ctManager = this;

        }else
        {
            cam.SetActive(false);
        }
        snowManager = thisGameObject.AddComponent<SnowManager>();
        soundManager = thisGameObject.AddComponent<SoundManager>();
        animScript = thisGameObject.AddComponent<AnimScript>();
        GameObject uiRoot = GameObject.Find("GameUIRoot");
        //print(uiRoot);
        uiManager = uiRoot.GetComponent<UIManager>();
        snowManager.ctManager = this;
        soundManager.ctManager = this;
        animScript.ctManager = this;
    }
    //protected virtual void initValue()
    //{

    //    moveSpeed = 1.0f;
    //    makeSnowBallSpeed = 0.1f;
    //    hp = 100;
    //    snowBallMagaine = 50;
    //    attackPower = 2;
    //    attackSpeed = 0.1f;
    //    weaponState = false;


    //}
    protected abstract void initValue();
    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        if (state == CharacterState.Stun)
        {
            stunTimer -= Time.fixedDeltaTime;
            if (stunTimer <= 0)
                state = CharacterState.Normal;
        }
        

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
    public virtual void shot1()
    {
        snowManager.shot(attackPower);
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

    public void shot2()
    {

    }


    public void beShot(int inDamage)
    {
        if (this.hp < inDamage)
        {
            //사망
        }
        else
        {
            this.hp -= inDamage;
            print("HP : "+this.hp);
        }
    }
    public void beShot(int inDamage,CharacterState inState,float time)
    {
        beShot(inDamage);
        switch (inState)
        {
            case CharacterState.Stun:
                stunStart(time);
                break;
        }
        
    }
    void stunStart(float time)
    {
        stunTimer = time;
        state= CharacterState.Stun;
    }
}
