using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerData spawnerData;

    public Transform spawnPosition;
    public bool playOnAwake = true;

    [SerializeField] Vector2Int numberOfSpawns;
    [SerializeField] Vector2 delayВetweenSpawns;



    private void Start()
    {
        if(playOnAwake)
            StartCoroutine(startSpawnCor());
    }

    public IEnumerator startSpawnCor()
    {
        for (int i = 0; i < Random.Range(numberOfSpawns.x, numberOfSpawns.y); i++)
        {
            yield return new WaitForSeconds(Random.Range(delayВetweenSpawns.x, delayВetweenSpawns.y));
            spawnRandomItem();
        }

        yield break;
    }
    public void spawnRandomItem()
    {
        Instantiate(spawnerData.Prefabs[Random.Range(0, spawnerData.Prefabs.Count)], spawnPosition).transform.localPosition = Vector3.zero;
    }

    // в рандомном радиусе 
    // рандомное кол-во за раз
    // ивенты заспавнил начал спавнить закончил спавнить
    // время жизни 
    // бессконечная генерация
    // шанс выпадения каждого итема отдельно
}
