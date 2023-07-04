using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [Header("# Spawn")]
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnTime;
    public float curspawnTime; // 다음스폰까지 남은시간
    public int spawnCount; // 라운드당 소환할 숫자
    public int curSpawnCount; // 라운드당 소환한 현재 숫자
    [SerializeField] int minSpawnCount;
    [SerializeField] int maxSpawnCount;
    

    [Header("# WaveUI")]
    [SerializeField] Slider minionWaveSilder;
    [SerializeField] GameObject bossTimeSlider;
    [SerializeField] GameObject bossRetryBtn;

    [Header("# Boss")]
    public bool isBoss;
    float curbossTimeLimit;
    [SerializeField] float bossTimeLimit;
    bool isBossWave;



    GameObject[] enemy;
    GameObject boss;

    void Start()
    {
        curspawnTime = spawnTime;
        spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
        curSpawnCount = 0;
        enemy = new GameObject[maxSpawnCount];
    }
    private void Update()
    {
        SpawnTimer();
        Spawner();
        MinionWave();
        SpawnBoss();

        if (!GameManager.instance.player.gameObject.activeSelf)
        {
            GameManager.instance.killCount = 0;
            curSpawnCount = 0;
            BossRetry();
            curspawnTime = spawnTime;
        }
    }

    private void SpawnTimer()
    {
        if (isBoss)
        {
            curbossTimeLimit -= Time.deltaTime;
            bossTimeSlider.GetComponentInChildren<Slider>().value = curbossTimeLimit / bossTimeLimit;

            if (bossTimeSlider.GetComponentInChildren<Slider>().value == 0)
            {
                BossRetry();
                boss.SetActive(false);
            }
            else if (boss != null && boss.GetComponent<Enemy>().health <= 0)
            {
                //보스 잡음
                isBoss = false;
                isBossWave = false;
                GameManager.instance.killCount = 0;

                GameManager.instance.subStage++;
                bossTimeSlider.SetActive(false);
                minionWaveSilder.gameObject.SetActive(true);
            }
        }
        else
        {
            curspawnTime -= Time.deltaTime;
        }
    }
    void BossRetry()
    {
        //보스못잡음
        isBoss = false;
        bossTimeSlider.SetActive(false);
        if(isBossWave)
            bossRetryBtn.SetActive(true);
    }
    private void Spawner()
    {
        if (curspawnTime < 0 && curSpawnCount != spawnCount && !isBoss)
        {

            enemy[curSpawnCount] = PoolManager.instance.EnemyGet(Random.Range(0, 9));
            enemy[curSpawnCount].transform.position = spawnPoints[Random.Range(0, 3)].position;

            curspawnTime = spawnTime;
            curSpawnCount++;
        }
    }
    private void MinionWave()
    {
        if (spawnCount <= GameManager.instance.killCount && !isBoss)
        {
            GameManager.instance.killCount = 0;
            if(!bossRetryBtn.activeSelf)
                minionWaveSilder.value += 0.2f;

            spawnCount = Random.Range(minSpawnCount, maxSpawnCount);

            curSpawnCount = 0;

        }
    }
    void SpawnBoss()
    {
        if(minionWaveSilder.value == 1)
        {
            BtnBossRetry();
            isBossWave = true;
        }
    }
    public void BtnBossRetry()
    {
        isBoss = true;
        curSpawnCount = 0;

        for (int i = 0; i < spawnCount; i++)
        {
            enemy[i].gameObject.SetActive(false);
        }

        boss = PoolManager.instance.BossGet(0);
        boss.transform.position = spawnPoints[0].position;

        bossRetryBtn.SetActive(false);

        minionWaveSilder.gameObject.SetActive(false);
        minionWaveSilder.value = 0;

        bossTimeSlider.gameObject.SetActive(isBoss);
        curbossTimeLimit = bossTimeLimit;
    }
}
