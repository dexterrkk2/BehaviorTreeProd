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
    public override bool Run()
    {
        Debug.Log("target: " + Mtarget);
        Mmover.myTarget = Mtarget;
        return true;
    }
}
