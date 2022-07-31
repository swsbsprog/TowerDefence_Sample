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
    private IEnumerator Start()
    {
        while (currentWaveIndex < waves.Length)
        {
            var wave = waves[currentWaveIndex];
            //wave.interval; // 필어마운트채우자. 
            yield return new WaitForSeconds(wave.interval);
            // 몬스터 리젠
            for (int i = 0; i < wave.count; i++)
            {
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
}

