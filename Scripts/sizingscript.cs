using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizingscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GameObject");
        dificultyscript bscript = g.GetComponent<dificultyscript>();
        transform.localScale = new Vector3(bscript.ballSize* 1f, bscript.ballSize* 1f, bscript.ballSize* 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
