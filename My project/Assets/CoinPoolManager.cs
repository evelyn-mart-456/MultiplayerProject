using UnityEngine;
using System.Collections.Generic;

public class CoinPoolManager : MonoBehaviour
{
    public static CoinPoolManager Instance { get; private set; }

    public GameObject coinPrefab;

    private ObjectPool coinPool;
    private List<Vector3> coinStartPositions;
    private List<GameObject> activeCoins;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeCoins();
    }

    void InitializeCoins()
    {
        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");

        coinStartPositions = new List<Vector3>();
        activeCoins = new List<GameObject>();

        foreach (GameObject coin in existingCoins)
        {
            coinStartPositions.Add(coin.transform.position);
            Destroy(coin);
        }

        coinPool = new ObjectPool(coinPrefab, coinStartPositions.Count);

        SpawnAllCoins();
    }

    public void SpawnAllCoins()
    {
        foreach (Vector3 position in coinStartPositions)
        {
            GameObject coin = coinPool.Get();
            coin.transform.position = position;
            activeCoins.Add(coin);
        }
    }

   public void CollectCoin(GameObject coin)
{
    Debug.Log("Returning coin: " + coin.name);

    coin.SetActive(false);

    if (activeCoins.Contains(coin))
        activeCoins.Remove(coin);

    coinPool.Return(coin);
}

    public void ResetCoins()
    {
        foreach (GameObject coin in activeCoins)
        {
            coin.SetActive(false);
            coinPool.Return(coin);
        }

        activeCoins.Clear();

        SpawnAllCoins();
    }
}
