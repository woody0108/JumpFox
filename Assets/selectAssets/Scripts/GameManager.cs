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

    #region �̱���
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

            // gamePos ����Ʈ���� ������ ��ġ ���� �����ͼ� �����մϴ�.
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
             // ������Ʈ Ǯ�� ��� ������ ������ �ִ��� Ȯ���մϴ�.
             if (coinPool.queue.Count > 0)
             {
                 // ������Ʈ Ǯ���� ������ �����ɴϴ�.
                 GameObject coin = coinPool.queue.Dequeue();
                 coin.SetActive(true);

                 // TODO: ��ġ�� �����ϰ� ������ �ʿ��� �ʱ�ȭ�� �����մϴ�.

                 // ���� ������Ʈ ��ġ���� �����ͼ� ���� ��ġ�� �����մϴ�.
                 int index = (int)position;
                 if (index >= 0 && index < gamePos.Count)
                 {
                     coin.transform.position = gamePos[index].transform.position;
                 }
                 else
                 {
                     Debug.LogWarning("���� ������Ʈ ��ġ �ε����� ������ ������ϴ�: " + index);
                 }
             }
             else
             {
                 //Debug.Log(gamePos[1].transform.position);
                 Debug.LogWarning("��ġ�� ���� ������Ʈ Ǯ�� ��� ������ ������ �����ϴ�: " + position.ToString());
             }
         }
         else
         {
             Debug.LogWarning("��ġ�� ���� ���� ������Ʈ Ǯ�� ã�� �� �����ϴ�: " + position.ToString());
         }
     }*/


}
