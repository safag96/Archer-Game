using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
        Application.Quit();
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 2)
        {
            xPos = Random.Range(-8, 2);
            zPos = Random.Range(5, 6);

            if (theEnemy != null) // Check if theEnemy reference is not null
            {
                Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
                yield return new WaitForSeconds(4);
                enemyCount++;
            }
        }

        yield return new WaitForSeconds(6);
        Application.Quit();
    }
}
