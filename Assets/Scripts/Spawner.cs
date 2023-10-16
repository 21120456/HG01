using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected float spawDelay;
    [SerializeField] protected float spawTimer;
    [SerializeField] protected float rangeLow;
    [SerializeField] protected float rangeHigh;
    [SerializeField] protected GameObject spawnerPoint;
    [SerializeField] protected Transform transformListObj;
    [SerializeField] protected List<GameObject> ListObj;

    // Start is called before the first frame update
    void Start()
    {
        getObj();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void FixedUpdate()
    {
        spawner();
    }

    protected virtual void getObj()
    {
        foreach (Transform child in transformListObj)
        {
            ListObj.Add(child.gameObject);
        }
    }

    protected virtual void spawner()
    {
        bool isStart = Bird.Instance.IsStart;
        bool isDead = Bird.Instance.IsDead;
        if (!isStart || isDead) return;
        spawTimer += Time.fixedDeltaTime;
        if (spawTimer < spawDelay) return;
        spawTimer = 0;
        float high = Random.Range(rangeLow, rangeHigh);
        Vector3 pos = spawnerPoint.transform.position;
        pos.y = high;
        GameObject obj = Instantiate(ListObj[0], pos, spawnerPoint.transform.rotation, gameObject.transform);
        obj.SetActive(true);

    }
}
