using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HulkOut : Task
{
    GameObject entity;
    public HulkOut(GameObject someEntity)
    {
        entity = someEntity;
    }
    public override void Run()
    {
        Debug.Log("Hulked");
        entity.transform.localScale *= 2;
        entity.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        succeeded = true;
        EventBus.TriggerEvent(TaskFinished);
    }
}
