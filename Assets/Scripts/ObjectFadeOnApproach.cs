﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFadeOnApproach : MonoBehaviour {

    public Player player;
    public ControllerManager controllerManager;
    public float startFadeDistance;
    public float endFadeDistance;

    MeshRenderer rend;
    Material mat;
    Vector3 vectorToPlayer;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        mat = rend.material;
        vectorToPlayer = transform.position - player.transform.position;
        vectorToPlayer.Normalize();
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < startFadeDistance - 1 && distance > endFadeDistance)
        {
            if (rend.enabled == false)
                rend.enabled = true;
            float alpha = (distance - endFadeDistance) / (startFadeDistance - endFadeDistance);
            Color oldColor = mat.color;
            mat.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
        }
        else if (distance <= endFadeDistance && rend.enabled == true)
        {
            rend.enabled = false;
            controllerManager.setVibration(0, 0);
        }
        else if (distance >= startFadeDistance && rend.enabled == false)
        {
            rend.enabled = true;
            controllerManager.setVibration(0, 0);
        }
    }
}
