using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutCharaterManager : CharacterManager {
    /*
    protected float moveSpeed;
    protected float makeSnowBallSpeed;
    protected int HP;
    protected int snowBallMagaine;
    protected float attackPower;
    protected float attackSpeed;
    protected bool weaponState;
    */


    private void Awake()
    {
        initState(isPlayer);
        initValue();
    }
    // Use this for initialization
    void Start () {
        
        
	}
    protected override void initValue()
    {
        moveSpeed = 20.0f;
        makeSnowBallSpeed = 0.1f;
        hp = 80;
        snowBallMagaine = 50;
        attackPower = 1;
        attackSpeed = 0.1f;
        weaponState = false;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
