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
    public override bool Run()
    {
        return !varToTest;
    }
}
public class IsTrue : Task
{
    bool varToTest;
    public IsTrue(bool someBool)
    {
        varToTest = someBool;
    }
    public override bool Run()
    {
        return varToTest;
    }
}
