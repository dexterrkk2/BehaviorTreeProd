using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargeDoor : Task
{
    Rigidbody door;
    public BargeDoor(Rigidbody someDoor)
    {
        door = someDoor;
    }
    public override bool Run()
    {
        door.AddForce(-10f, 0, 0, ForceMode.VelocityChange);
        return true;
    }
}