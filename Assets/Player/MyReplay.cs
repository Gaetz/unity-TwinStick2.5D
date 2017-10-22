using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour
{
    private const int bufferFrame = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrame];
    private Rigidbody rbody;

    private ReplayManager manager;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        manager = GameObject.FindObjectOfType<ReplayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.isRecording)
        {
            Record();
        }
        else
        {
            Playback();
        }
    }

    private void Record()
    {
        int frame = Time.frameCount % 100;
        float time = Time.time;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    void Playback()
    {
        rbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrame;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
}

public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float frameTime, Vector3 position, Quaternion rotation)
    {
        this.frameTime = frameTime;
        this.position = position;
        this.rotation = rotation;
    }
}