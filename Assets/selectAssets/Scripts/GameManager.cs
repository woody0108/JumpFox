using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public enum EPosFlag
{
    floor,
    middle,
    top,
    tile
}

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CoinCount;
    public int Coin = 0;

    public List<GameObject> gamePos = new List<GameObject>();
    private float nextCoinSpawnTime = 0f;
    private float coinSpawnInterval = 1f;

    #region 싱글톤
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    #endregion
    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private ObjectPoolingManager objectPoolingManager;
    void Start()
    {
        objectPoolingManager = ObjectPoolingManager.Instance;
    }


    void Update()
    {
      
        if (Time.time >= nextCoinSpawnTime)
        {
            EPosFlag randomPosition = (EPosFlag)Random.Range(0, 3);

            // gamePos 리스트에서 랜덤한 위치 값을 가져와서 전달합니다.
            int randomIndex = Random.Range(0, 3);
            objectPoolingManager.Get((EObjectFlag)Random.Range(0,2), gamePos[randomIndex].gameObject.transform.position);

          

            nextCoinSpawnTime = Time.time + coinSpawnInterval;
        }
        CoinCount.text = Coin.ToString();
    }


    /* void GenerateCoin(EPosFlag position)
     {
         ObjectPool coinPool = null;
         coinPool = objectPoolingManager.objectPoolingList.Find(pool => pool.copyObj.name == "Coin");

         if (coinPool != null)
         {
             // 오브젝트 풀에 사용 가능한 동전이 있는지 확인합니다.
             if (coinPool.queue.Count > 0)
             {
                 // 오브젝트 풀에서 동전을 가져옵니다.
                 GameObject coin = coinPool.queue.Dequeue();
                 coin.SetActive(true);

                 // TODO: 위치를 설정하고 동전에 필요한 초기화를 수행합니다.

                 // 게임 오브젝트 위치값을 가져와서 동전 위치로 설정합니다.
                 int index = (int)position;
                 if (index >= 0 && index < gamePos.Count)
                 {
                     coin.transform.position = gamePos[index].transform.position;
                 }
                 else
                 {
                     Debug.LogWarning("게임 오브젝트 위치 인덱스가 범위를 벗어났습니다: " + index);
                 }
             }
             else
             {
                 //Debug.Log(gamePos[1].transform.position);
                 Debug.LogWarning("위치에 대한 오브젝트 풀에 사용 가능한 동전이 없습니다: " + position.ToString());
             }
         }
         else
         {
             Debug.LogWarning("위치에 대한 동전 오브젝트 풀을 찾을 수 없습니다: " + position.ToString());
         }
     }*/


}
