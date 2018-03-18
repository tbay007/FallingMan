﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePositionUpdate : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        float speed = PublicSettingsManagerScript.platformSpeed;
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (speed * 0.01f));
	}
}
