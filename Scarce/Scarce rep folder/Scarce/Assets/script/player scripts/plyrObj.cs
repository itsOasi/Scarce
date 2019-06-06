﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyrObj : MonoBehaviour
{
    public GameObject plyrbod;
    
    public camObj camObj;
    public cam cam;
    public actions player;
    public bool jumpOk;
    //public plyrData data;

    public string ID;
    public int xp;
    public float hlth;
    public float stmn;
    public int moveSpd;
    public int jumpStr;
    public int ammo;
    public int money;
    public int shield;

    public float mx;
    public float my;
    public float rx;
    public float ry;

    private void Start()
    {
        saveSystem.LoadData();
    }

    void Update()
    {

        cam = GetComponentInChildren<cam>();
        camObj = GetComponentInChildren<camObj>();
        player = GetComponentInChildren<actions>();

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        float RotX = Input.GetAxis("Mouse X");
        float RotY = Input.GetAxis("Mouse Y");

        mx = Mathf.Clamp(moveX, -1, 1);
        my = Mathf.Clamp(moveY, -1, 1);
        rx = Mathf.Clamp(RotX, -1, 1);
        ry = Mathf.Clamp(RotY, -1, 1);

        player.Move(mx * 10, rx, my * 10, moveSpd);
        if (mx != 0 || my != 0)
        {
            if (stmn > 0)
            {
                stmn -= .01f;
            }
            else { hlth -= .01f; }
        }

        if (hlth <= 0)
        {
            defButton.ToSceneStat("menu");
        }

        if (camObj.rotOk)
        {
            camObj.CamRot(ry * 3f, moveSpd);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (jumpOk)
            {
                player.Jump(jumpStr);
                jumpOk = false;
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (ammo > 0)
            {
                cam.Shoot();
                ammo--;
            }
        }
    }

    public void DestroyChild()
    {
        Destroy(transform.GetChild(0).gameObject);
    }

    public void CollectAmmo(int a)
    {
        ammo += a;
    }
    public void CollectHealth(int h)
    {
        hlth += h;
    }
    public void CollectCoin(int c)
    {
        money += c;
    }
    public void CollectXp(int p)
    {
        xp += p;
    }
}
