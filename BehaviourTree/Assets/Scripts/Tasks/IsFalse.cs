using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFalse : Task
{
    bool varToTest;
    public IsFalse(bool someBool)
    {
        varToTest = someBool;
    }
    public override void Run()
    {
        succeeded = !varToTest;
        EventBus.TriggerEvent(TaskFinished);
    }
}
public class IsTrue : Task
{
    bool varToTest;
    public IsTrue(bool someBool)
    {
        varToTest = someBool;
    }
    public override void Run()
    {
        succeeded = varToTest;
        EventBus.TriggerEvent(TaskFinished);
    }
}
