﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRhythmCube : MonoBehaviour
                            , IBeatListener
                            , IRhythmFeedbackListener
                            , IRhythmQueueEventListener
{
    private static readonly float offsetMagnitude = 0.25f;
    private readonly Vector3 uOffset = new Vector3( 0.0f,  offsetMagnitude,  0.0f);
    private readonly Vector3 dOffset = new Vector3( 0.0f, -offsetMagnitude,  0.0f);
    private readonly Vector3 lOffset = new Vector3( offsetMagnitude,  0.0f,  0.0f);
    private readonly Vector3 rOffset = new Vector3(-offsetMagnitude,  0.0f,  0.0f);
    private Vector3 originalPos;
    public Color baseColor = Color.gray;
    public Color successColor = Color.green;
    public Color missColor = Color.red;
    public float stayColorTime = 0.125f;

	// Use this for initialization
	void Start ()
    {
        this.originalPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void BackToDefault()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = this.baseColor;
    }

    public void BeatNotify(RhythmCore.BeatInfo beatInfo)
    {
        // Do something when on beat
        //Debug.Log("Beat");
    }

    public void HitNotify()
    {
        // Do something when user hits correct input
        //Debug.Log("Hit");
        this.gameObject.GetComponent<MeshRenderer>().material.color = this.successColor;
        Invoke("BackToDefault", this.stayColorTime);
    }

    public void MissNotify()
    {
        // Do something when user hits incorrect input
        //Debug.Log("Miss");
        this.gameObject.GetComponent<MeshRenderer>().material.color = this.missColor;
        Invoke("BackToDefault", this.stayColorTime);
    }

    public void TimeoutNotify()
    {
        // Do something when beat times out
        //Debug.Log("Timeout");
    }

    public void EventQueuedNotify(RhythmCore.RhythmExpectedEventInfo eventInfo)
    {
        // Do something when a beat is queued up (we enter a beat window)
        //Debug.Log("Event Queued");

        Vector3 offset = new Vector3(0.0f, 0.0f, -16.0f);
        switch(eventInfo.expectedKey)
        {
            case KeyCode.UpArrow:
                {
                    offset = this.uOffset;
                    break;
                }
            case KeyCode.DownArrow:
                {
                    offset = this.dOffset;
                    break;
                }
            case KeyCode.LeftArrow:
                {
                    offset = this.lOffset;
                    break;
                }
            case KeyCode.RightArrow:
                {
                    offset = this.rOffset;
                    break;
                }
            default:
                {
                    Debug.LogError("Unexpected eventInfo.expectedKey value in TestRhythmCube.EventQueuedNotify");
                    break;
                }
        }

        this.transform.position += offset;
    }

    public void EventExpiredNotify(RhythmCore.RhythmExpectedEventInfo eventInfo)
    {
        // Do something when a beat expires (we exit/cancel a beat window)
        //Debug.Log("Event Expired");
        this.transform.position = this.originalPos;
    }
}
