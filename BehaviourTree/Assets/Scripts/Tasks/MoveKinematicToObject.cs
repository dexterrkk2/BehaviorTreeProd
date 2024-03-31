using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKinematicToObject : Task
{
    Arriver Mmover;
    GameObject Mtarget;
    public MoveKinematicToObject(Kinematic mover, GameObject target)
    {
        Mmover = mover as Arriver;
        Mtarget = target;
    }
    public override void Run()
    {
        Debug.Log("target: " + Mtarget);
        Mmover.OnArrived += MoverArrived;
        Mmover.myTarget = Mtarget;
    }
    public void MoverArrived()
    {
        Mmover.OnArrived -= MoverArrived;
        succeeded = true;
        EventBus.TriggerEvent(TaskFinished);
    }
}
