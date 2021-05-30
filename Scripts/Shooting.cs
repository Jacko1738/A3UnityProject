using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private string targetTag = "target";
    [SerializeField] private Material higlighedMaterial;
    [SerializeField] private Material defaultMaterial;


    public spawnTargets targetsScript;
    public Score scoreScript;
    private Transform _selection;

    private float targetHit;
    private float shotsTotal;
    public float accuracy;

    public pausingscript pausedscr;

    public Text accuracyText;
    public Text TPMText;
    public Text targetsHit;

    public float TPM;

    // Start is called before the first frame update
    void Start()
    {
        targetHit = 0;
        shotsTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //game is unpaused
        if (Input.GetMouseButtonDown(0) && pausedscr.GameIsPaused == false)
        {
            shotsTotal = shotsTotal + 1;
            Debug.Log(shotsTotal);
        }
        if (_selection != null){
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        //acccorocy
        accuracy = targetHit / shotsTotal;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            var selection = hit.transform;
            if (selection.CompareTag(targetTag)){
                    var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null){
                    selectionRenderer.material = higlighedMaterial;
                }
                if (Input.GetMouseButtonDown(0)){
                       GameObject[] targets = GameObject.FindGameObjectsWithTag("target");
                        foreach(GameObject target in targets){
                             GameObject.Destroy(target);
                        }
                    targetHit = targetHit + 1;
                    Debug.Log(targetHit);
                    //Destroy(hit.transform.GetComponent<GameObject>());
                    targetsScript.spawnTarget();
                    scoreScript.addScore();
                }
                _selection = selection;


            } 
            TPM = targetHit * 2;
            accuracyText.text = "Accuracy: " + accuracy.ToString();
            TPMText.text = "Targets Per Minute: " + TPM.ToString();
            targetsHit.text = "Targets Hit: " + targetHit.ToString();
        }
    }
}
