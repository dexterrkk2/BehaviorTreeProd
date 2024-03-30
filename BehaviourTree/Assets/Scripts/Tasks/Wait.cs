using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Task
{
    float timeToWait;
    public Wait(float time)
    {
        timeToWait = time;
    }
    public override bool Run()
    {
        return true;
    }
}
