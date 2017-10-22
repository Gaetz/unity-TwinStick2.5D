﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour
{
    private const int bufferFrame = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrame];
    private Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Record();
    }

    private void Record()
    {
        int frame = Time.frameCount % 100;
        float time = Time.time;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    void Playback()
    {
        rigidbody.isKinematic = false;
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