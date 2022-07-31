using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWaveIndex;
    public WaveInfo[] waves;

    [System.Serializable]
    public class WaveInfo
    {
        public Monster monster;
        public int count;
        public float interval = 5;
    }
    public Transform startPosition;
    public float startPositionRange = 1;
    public Transform destination;
    public float monsterRegenDelay = 0.5f;
    private IEnumerator Start()
    {
        while (currentWaveIndex < waves.Length)
        {
            var wave = waves[currentWaveIndex];
            SetFillAmountUI(wave.interval);

            waitEndTime = Time.time + wave.interval;
            while (Time.time < waitEndTime)
                yield return null;

            // 몬스터 리젠
            for (int i = 0; i < wave.count; i++)
            {
                yield return new WaitForSeconds(Random.Range(0, monsterRegenDelay));
                var newMonser = Instantiate(wave.monster);
                var spawnPosition = startPosition.position;
                spawnPosition += new Vector3(Random.Range(-startPositionRange, startPositionRange)
                    , Random.Range(-startPositionRange, startPositionRange), 0);
                newMonser.transform.position = spawnPosition;
                newMonser.SetDestination(destination.position);
            }
            currentWaveIndex++;
        }
    }
    float waitEndTime;
    public void OnClickRegenMonster()
    {
        waitEndTime = 0; // 기다리는 시간 즉시 완료되게 하기.
        fillAmountUI.gameObject.SetActive(false);
    }
    public Animator fillAmountUI;
    private void SetFillAmountUI(float interval)
    {
        fillAmountUI.gameObject.SetActive(true);
        fillAmountUI.speed = 1 / interval;  // interval : 10 => 1 / 10 => 0.1f
        fillAmountUI.Play("FillAmount", 1, 0);
    }
}

