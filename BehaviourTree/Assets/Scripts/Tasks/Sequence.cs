using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Task
{
    public List<Task> children;
    public override bool Run()
    {
        foreach(Task c in children)
        {
            if (!c.Run())
            {
                return false;
            }
        }
        return true;
    }
}
