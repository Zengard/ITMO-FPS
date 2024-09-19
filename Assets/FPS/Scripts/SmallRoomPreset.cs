using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRoomPreset : MonoBehaviour
{
    public List<GameObject> listOfEnemyPrefabs = new List<GameObject>();

    public int presetIndex;

    private int enemyNumbers;

    public GameObject xposition1;
    public GameObject xposition2;
    public GameObject zposition1;
    public GameObject zposition2;

    public float x1, x2;
    public float z1, z2;
    public float y;

    private void Start()
    {       

        x1 = xposition1.gameObject.transform.position.x;
        x2 = xposition2.gameObject.transform.position.x;
        z1 = zposition1.gameObject.transform.position.z;
        z2 = zposition2.gameObject.transform.position.z;

        for (int i = 1; i < 4; i++)
        {
            presetIndex = Random.Range(0, listOfEnemyPrefabs.Count);
            var enemy = Instantiate(listOfEnemyPrefabs[presetIndex], new Vector3(Random.Range(x1, x2), y, Random.Range(z1, z2)), Quaternion.identity);

            enemy.transform.parent = gameObject.transform;
        }
    }

}
