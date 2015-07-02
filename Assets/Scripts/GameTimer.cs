using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

    [SerializeField] private float timer;
    [SerializeField] private int level;
    private bool run;

	// Use this for initialization
	void Start () {
        run = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(run){
            timer += Time.deltaTime;
            /*if (timer <= 0)
            {
                Debug.Log("Changing scenes");
                Application.LoadLevel(level);
            }*/
        }
	}
    public void start(){
        run = true;
    }
    public float stop(){
        run = false;
        return timer;
    }
}
