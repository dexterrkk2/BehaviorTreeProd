using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruceBanner : MonoBehaviour
{
    public Door theDoor;
    public GameObject theTreasure;
    public GameObject test;
    bool executingBehavior = false;
    Task myCurrentTask;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!executingBehavior)
            {
                executingBehavior = true;
                myCurrentTask = BuildTask_GetMCMuffin();
                myCurrentTask.Run();
            }
        }
    }
    Task BuildTask_GetMCMuffin()
    {
        List<Task> taskList = new List<Task>();
        Task doorisntLocked = new IsFalse(theDoor.isLocked);
        Task openDoor = new OpenDoor(theDoor);
        Task waitABeat = new Wait(0.5f);
        taskList.Add(doorisntLocked);
        taskList.Add(waitABeat);
        taskList.Add(openDoor);
        Sequence openUnlockedDoor = new Sequence();
        openUnlockedDoor.children = taskList;
        //Barge Door
        taskList = new List<Task>();
        Task isDoorClosed = new IsTrue(theDoor.isClosed);
        Task hulkOut = new HulkOut(this.gameObject);
        Task bargeDoor = new BargeDoor(theDoor.transform.GetChild(0).GetComponent<Rigidbody>());
        taskList.Add(isDoorClosed);
        taskList.Add(waitABeat);
        taskList.Add(hulkOut);
        taskList.Add(waitABeat);
        taskList.Add(bargeDoor);
        Sequence bargeClosedDoor = new Sequence();
        bargeClosedDoor.children = taskList;
        // open a closed door, one way or another
        taskList = new List<Task>();
        taskList.Add(openUnlockedDoor);
        taskList.Add(bargeClosedDoor);
        Selector openTheDoor = new Selector();
        openTheDoor.children = taskList;
        //open a cloased door,
        taskList = new List<Task>();
        Task moveToDoor = new MoveKinematicToObject(this.GetComponent<Kinematic>(), theDoor.gameObject);
        Task movetoMcMuffin = new MoveKinematicToObject(this.GetComponent<Kinematic>(), theTreasure.gameObject);
        taskList.Add(moveToDoor);
        taskList.Add(waitABeat);
        taskList.Add(openTheDoor);
        taskList.Add(waitABeat);
        taskList.Add(movetoMcMuffin);
        Sequence getTreasureBehindClosedDoor = new Sequence();
        getTreasureBehindClosedDoor.children = taskList;
        //get the Mcmuffin
        taskList = new List<Task>();
        Task isDoorOpen = new IsFalse(theDoor.isClosed);
        taskList.Add(isDoorOpen);
        taskList.Add(movetoMcMuffin);
        Sequence getTreasureBehindOpenDoor = new Sequence();
        getTreasureBehindOpenDoor.children = taskList;
        //get the treasure, one way or another
        taskList = new List<Task>();
        taskList.Add(getTreasureBehindOpenDoor);
        taskList.Add(getTreasureBehindClosedDoor);
        Selector getTreasure = new Selector();
        getTreasure.children = taskList;
        //Debug.Log("Return");
        return getTreasure;
    }
}
