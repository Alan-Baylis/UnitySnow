using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManager : MonoBehaviour {

    const float ACCELATIONCONST = 0.1f;
    const float ROTATIONCONST = 5.0f;
    const float BULLETCOOLDOWN = 1.0f;
    const float BULLETPOSITION = 0.7f;
    const float BULLETPUPPOSITION = 0.0f;


    float snowResource;

    float snowCooldown;
    bool isCooldowning;
    public Camera cam;
    public GameObject bullet;
    public GameObject thisGameObject;

    // Use this for initialization
    void Start () {
        snowResource = 100000.0f;
        if (cam == null)
            cam = GetComponentInChildren<Camera>();
        if (bullet == null)
            bullet = GetComponentInChildren<SnowBulletManager>().gameObject;

		
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

    }
    public void shot()
    {
        if (!isCooldowning && snowResource > 1.0f)
        {
            isCooldowning = true;
            GameObject newSnowBullet = (GameObject)Instantiate(bullet, thisGameObject.transform.position + thisGameObject.transform.forward * BULLETPOSITION + thisGameObject.transform.up * BULLETPUPPOSITION, cam.transform.rotation);
            //print(cam.transform.forward);
            
            //print(newSnowBullet.GetComponent<SnowBulletManager>().forward);
            newSnowBullet.GetComponent<SnowBulletManager>().forward = cam.transform.forward;
            newSnowBullet.SetActive(true);
            snowCooldown = BULLETCOOLDOWN;
            

        }
    }
    public void getSnow()
    {

    }
    public void reLoading()
    {

    }
}
