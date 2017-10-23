using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatListener_ColorChange : MonoBehaviour, IBeatListener
{
    public Color baseColor = Color.green;
    public Color beatColor = Color.red;
    public float stayColorTime = 0.125f;

    public void BeatNotify(RhythmCore.BeatInfo beatInfo)
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = this.beatColor;

        Invoke("BackToGreen", this.stayColorTime);
    }

    public void BackToGreen()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = this.baseColor;
    }
}
