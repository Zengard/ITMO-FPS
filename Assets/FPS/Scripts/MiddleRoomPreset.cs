using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleRoomPreset : MonoBehaviour
{
    public List<GameObject> listOfPrefabs = new List<GameObject>();
    public GameObject enemyPrefab;

    public int presetIndex;

    private int enemyNumbers;

    public GameObject xposition1;
    public GameObject xposition2;
    public GameObject zposition1;
    public GameObject zposition2;

    public float x1, x2;
    public float z1, z2;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        presetIndex = Random.Range(0, listOfPrefabs.Count);

        listOfPrefabs[presetIndex].SetActive(true);

        x1 = xposition1.gameObject.transform.position.x;
        x2 = xposition2.gameObject.transform.position.x;
        z1 = zposition1.gameObject.transform.position.z;
        z2 = zposition2.gameObject.transform.position.z;


        enemyNumbers = Random.Range(3, 6);

        for (int i = 1; i < enemyNumbers; i++)
        {
            var enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(x1, x2), y, Random.Range(z1, z2)), Quaternion.identity);

            enemy.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(presetIndex == 1)
            {
                other.gameObject.transform.rotation = Quaternion.Euler(other.gameObject.transform.rotation.x, other.gameObject.transform.rotation.y, 180);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (presetIndex == 1)
            {
                other.gameObject.transform.rotation = Quaternion.Euler(other.gameObject.transform.rotation.x, other.gameObject.transform.rotation.y, 0);
            }
        }
    }

}
