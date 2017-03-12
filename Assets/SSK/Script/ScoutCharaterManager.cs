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

    // Use this for initialization
    void Start () {
        initState();
	}
    protected override void initValue()
    {
        moveSpeed = 2.0f;
        makeSnowBallSpeed = 0.1f;
        hp = 80;
        snowBallMagaine = 50;
        attackPower = 10;
        attackSpeed = 0.1f;
        weaponState = false;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
