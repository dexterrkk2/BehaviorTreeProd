﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arriver : Kinematic
{
    Arrive myMoveType;
    Align myRotateType;
    public delegate void Arrived();
    public event Arrived OnArrived;
    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Arrive();
        myMoveType.character = this;
        myMoveType.target = myTarget;

        myRotateType = new Align();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        myMoveType.target = myTarget;

        if (myTarget != null)
        {
            if ((myTarget.transform.position - transform.position).magnitude < 1.5f)
            {
                OnArrived?.Invoke();
            }
        }

        if (myTarget != null)
        {
            //steeringUpdate = new SteeringOutput();
            steeringUpdate = myMoveType.getSteering();
        }
        base.Update();
    }
}
