using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Task
{
    public List<Task> children;
    Task currentTask;
    int currentTaskIndex = 0;
    // Selector wants only the first task that succeeds
    // try all tasks in order
    // stop and return true on the first task that succeeds
    // return false if all tasks fail
    public override void Run()
    {
        Debug.Log("selector running child task #" + currentTaskIndex);
        currentTask = children[currentTaskIndex];
        EventBus.StartListening(currentTask.TaskFinished, OnChildTaskFinished);
        currentTask.Run();
    }

    void OnChildTaskFinished()
    {
        //Debug.Log("running Sequence");
        Debug.Log("Behavior complete! Success = " + succeeded);
        if (currentTask.succeeded)
        {
            succeeded = true;
            EventBus.TriggerEvent(TaskFinished);
        }
        else
        {
            EventBus.StopListening(currentTask.TaskFinished, OnChildTaskFinished);
            currentTaskIndex++;
            if (currentTaskIndex < children.Count)
            {
                this.Run();
            }
            else
            {
                // we've reached the end of our children and none have succeeded!
                succeeded = false;
                EventBus.TriggerEvent(TaskFinished);
            }
        }
    }
}
