using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Task
{
    public List<Task> children;
    Task currentTask;
    int currentTaskIndex = 0;
    public override void Run()
    {
        //Debug.Log("sequence running child task #" + currentTaskIndex);
        currentTask = children[currentTaskIndex];
        EventBus.StartListening(currentTask.TaskFinished, OnChildTaskFinished);
        currentTask.Run();
    }

    void OnChildTaskFinished()
    {
        //Debug.Log("running Sequence");
        //Debug.Log("Behavior complete! Success = " + currentTask.succeeded);
        if (currentTask.succeeded)
        {
            EventBus.StopListening(currentTask.TaskFinished, OnChildTaskFinished);
            currentTaskIndex++;
            if (currentTaskIndex < children.Count)
            {
                this.Run();
            }
            else
            {
                // we've reached the end of our children and all have succeeded!
                succeeded = true;
                EventBus.TriggerEvent(TaskFinished);
            }
        }
        else
        {
            // sequence needs all children to succeed
            // a child task failed, so we're done
            succeeded = false;
            EventBus.TriggerEvent(TaskFinished);
        }
    }
}
