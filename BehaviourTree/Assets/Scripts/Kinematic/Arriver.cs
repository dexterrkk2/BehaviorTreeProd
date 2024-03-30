using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arriver : Kinematic
{
    Arrive myMoveType;
    Align myRotateType;

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
        steeringUpdate = new SteeringOutput();
        if(myMoveType.target == null)
        {
            myMoveType.target = myTarget;
            myRotateType.target = myTarget;
        }
        else
        {
            steeringUpdate = myMoveType.getSteering();
            //steeringUpdate.angular = myRotateType.getSteering().angular;
        }
        base.Update();
    }
}
