using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Task
{
    Door door;
    public OpenDoor(Door someDoor)
    {
        door = someDoor;
    }
    public override void Run()
    {
        succeeded = door.Open();
        EventBus.TriggerEvent(TaskFinished);
    }
}
