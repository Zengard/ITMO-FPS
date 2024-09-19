using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPresets : MonoBehaviour
{
    public List<GameObject> listOfPrefabs = new List<GameObject>();
    public GameObject enemyPrefab;

    private int presetIndex;

    private int enemyNumbers;

    public float x1,x2;
    public float z1, z2;
    public float y;

    private void Start()
    {
        presetIndex = Random.Range(0, listOfPrefabs.Count);

        listOfPrefabs[presetIndex].SetActive(true);

        foreach (Transform child in listOfPrefabs[presetIndex].transform)
        {

            if (child.name == "SpawnEnemyPoint1")
            {
                x1 = child.position.x;
                y = child.position.y;
            }

            if (child.name == "SpawnEnemyPoint2")
            {
                x2 = child.position.x;
            }

            if (child.name == "SpawnEnemyPoint3")
            {
                z1 = child.position.z;
            }

            if (child.name == "SpawnEnemyPoint4")
            {
                z2 = child.position.z;
            }
        }

        enemyNumbers = Random.Range(3, 6);

        for(int i =1; i < enemyNumbers; i++)
        {
           var enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(x1, x2), y, Random.Range(z1, z2)), Quaternion.identity);

            enemy.transform.parent = gameObject.transform;
        }
    }
}
