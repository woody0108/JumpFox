using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public GameObject startPos; // 시작지점
    private float lastXPosition = 0.0f; // Store the last x position
    private float timeBetweenGenerations = 10.0f; // Time between tile generations

    private GameManager gameManager;
    private ObjectPoolingManager objectPoolingManager;

    void Start()
    {
        objectPoolingManager = ObjectPoolingManager.Instance;
        gameManager = GameManager.Instance;
        StartCoroutine(GenerateTilesWithInterval());
    }

    private IEnumerator GenerateTilesWithInterval()
    {
        while (true)
        {
            GenerateTiles(40);
            yield return new WaitForSeconds(timeBetweenGenerations);
        }
    }

    private void GenerateTiles(int count)
    {
        Vector3 startPosition = startPos.transform.position;
        float jumpDistanceMin = 0;
        float jumpDistanceMax = 100;

        startPosition.x = lastXPosition; // Set the start position to the last x position

        for (int i = 0; i < count; i++)
        {
            float jumpDistance = Random.Range(jumpDistanceMin, jumpDistanceMax);
            float nextX;

            if (jumpDistance >= 90)
            {
                nextX = startPosition.x + 2;
            }
            else if (jumpDistance >= 80)
            {
                nextX = startPosition.x + 1;
            }
            else
            {
                nextX = startPosition.x;
            }

            if (nextX < lastXPosition + 100)
            {
                Vector2 tilePosition = new Vector2(nextX, startPosition.y);
                objectPoolingManager.Get(EObjectFlag.tile, tilePosition);
                lastXPosition = nextX;
                startPosition.x = nextX + 1;
            }
            else
            {
                break;
            }
        }
    }
    






}



