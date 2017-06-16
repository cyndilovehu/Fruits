using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    [Header("水果")]
    public GameObject[] Fruits;
    [Header("炸弹")]
    public GameObject bomb;
    private float spawntime = 1.5f;
    float current = 0;
    bool Isplaying = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Isplaying)
            return;
        current += Time.deltaTime;
        if(current>=spawntime)
        {
            //计时到时间开始产生水果
            int fruitcount = Random.Range(1, 3);
            for(int i=0;i<fruitcount;i++)
            OnSpawn(true);
            current = 0;
            int bomb = Random.Range(0, 100);
            if(bomb>40)
                OnSpawn(false);

        }

    }
    private void OnSpawn(bool isfruit)
    {
        //判断边界
        float x = Random.Range(-8.5f,8.5f);
        float y = transform.position.y;
        int index = Random.Range(0, Fruits.Length);
        GameObject go;
        if(isfruit)
            go = (GameObject)Instantiate(Fruits[index],new Vector3(x,y,0),Random.rotation);
        else
            go = (GameObject)Instantiate(bomb, new Vector3(x, y, 0), Random.rotation);
        //定义水果的速度
        Vector3 velocity = new Vector3(-x*Random.Range(0.2f,0.8f),-Physics.gravity.y*Random.Range(1.2f,1.5f),0);
        Rigidbody rigidbody = go.GetComponent<Rigidbody>();
        rigidbody.velocity = velocity;
    }
}
