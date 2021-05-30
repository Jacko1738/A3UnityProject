using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTargets : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 center;
    public Vector3 size;

    public dificultyscript difscript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //testing if spawning new targets will work by temp making a button spawn them
        if (Input.GetKey(KeyCode.Q)){
            spawnTarget();
        }
    }

    public void spawnTarget(){
        Vector3 pos = center + new Vector3(Random.Range(-difscript.maxWidth/2, difscript.maxWidth/2), Random.Range(-size.y / 2, size.y /2), Random.Range(-size.z / 2, size.z /2));
        Instantiate(targetObject, pos, Quaternion.identity);
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
