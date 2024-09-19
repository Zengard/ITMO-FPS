using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLogic : MonoBehaviour
{
    public GameObject[] transitionPoints;
    public LevelGenerator levelgenerator;
    public bool enterRoom;

    private void Start()
    {
        levelgenerator = FindObjectOfType<LevelGenerator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterRoom = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           if (enterRoom == true)
              {
                levelgenerator.RemoveRooms();
                enterRoom = false;

                foreach (Transform child in transform)
                 {
                    if (child.name.Contains("TransitionPoint"))
                    {
                        levelgenerator.spawnPoints.Add(child.gameObject);
                    }
                 }

                levelgenerator.SpawnRooms();
                levelgenerator.levelIndex++;
              }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterRoom = false;         
        }
    }
}
