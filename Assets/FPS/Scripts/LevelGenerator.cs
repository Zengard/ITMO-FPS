using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> roomsPrefabs = new List<GameObject>();
    public GameObject finalRoomPrefab;
    public GameObject startTransition;
    public GameObject startRoom;
    public List<GameObject> rooms = new List<GameObject>();

    private int roomToSpawn;
    private int pointToSpawn;

    public List<GameObject> spawnPoints = new List<GameObject>();

    public int levelIndex = 0;

    private void Start()
    {
        var connectionPoint = startTransition.transform.Find("ConnectionPoint");

        if (connectionPoint)
        {
            roomToSpawn = Random.Range(0, roomsPrefabs.Count);
        }

        GameObject start_room = Instantiate(startRoom, new Vector3(connectionPoint.position.x, connectionPoint.position.y, connectionPoint.position.z), Quaternion.identity * Quaternion.Euler(0,180,0));
        foreach (Transform child in start_room.transform)
        {
            if (child.name.Contains("TransitionPoint"))
            {
                spawnPoints.Add(child.gameObject);
            }
        }

        rooms.Add(start_room);

        SpawnRooms();

    }

    public void SpawnRooms()
    {
        if(levelIndex < 10)
        {
            foreach (var point in spawnPoints)
            {
                GameObject new_room = null;
                roomToSpawn = Random.Range(0, roomsPrefabs.Count);

                if (point.gameObject.name == "TransitionPointRight")
                {
                    new_room = Instantiate(roomsPrefabs[roomToSpawn], new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z),
                       rooms[0].transform.rotation);

                    new_room.transform.rotation = new_room.transform.rotation * Quaternion.Euler(0, rooms[0].transform.rotation.y + 90, 0);

                }
                else if (point.gameObject.name == "TransitionPointLeft")
                {
                    new_room = Instantiate(roomsPrefabs[roomToSpawn], new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z),
                        rooms[0].transform.rotation);

                    new_room.transform.rotation = new_room.transform.rotation * Quaternion.Euler(0, rooms[0].transform.rotation.y - 90, 0);
                }
                else if (point.gameObject.name == "TransitionPointForward")
                {
                    new_room = Instantiate(roomsPrefabs[roomToSpawn], new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z),
                        rooms[0].transform.rotation);

                    new_room.transform.rotation = new_room.transform.rotation * Quaternion.Euler(0, rooms[0].transform.rotation.y, 0);
                }

                rooms.Add(new_room);
            }
        }
        else if (levelIndex >= 10)
        {
            foreach (var point in spawnPoints)
            {
                GameObject new_room = null;
                roomToSpawn = Random.Range(0, roomsPrefabs.Count);

                if (point.gameObject.name == "TransitionPointRight")
                {
                    new_room = Instantiate(finalRoomPrefab, new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z),
                       rooms[0].transform.rotation);

                    new_room.transform.rotation = new_room.transform.rotation * Quaternion.Euler(0, rooms[0].transform.rotation.y + 90, 0);

                }
                else if (point.gameObject.name == "TransitionPointLeft")
                {
                    new_room = Instantiate(finalRoomPrefab, new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z),
                        rooms[0].transform.rotation);

                    new_room.transform.rotation = new_room.transform.rotation * Quaternion.Euler(0, rooms[0].transform.rotation.y - 90, 0);
                }
                else if (point.gameObject.name == "TransitionPointForward")
                {
                    new_room = Instantiate(finalRoomPrefab, new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z),
                        rooms[0].transform.rotation);

                    new_room.transform.rotation = new_room.transform.rotation * Quaternion.Euler(0, rooms[0].transform.rotation.y, 0);
                }

                rooms.Add(new_room);
            }
        }

        
    }
     public void RemoveRooms()
    {
        foreach(var room in rooms)
        {
            if(room.gameObject.GetComponent<RoomLogic>().enterRoom == false)
            {
                rooms.Remove(room);
                Destroy(room);
            }
        }

        spawnPoints.Clear();
    }
    

    private void Update()
    {
        
    }
}
