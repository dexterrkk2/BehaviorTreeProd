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
    public override void Run()
    {
        door.AddForce(0, 0, -10f, ForceMode.VelocityChange);
        succeeded = true;
        EventBus.TriggerEvent(TaskFinished);
    }
}