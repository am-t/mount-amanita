using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

    [SerializeField] private float timer;
    [SerializeField]
    private int nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("Changing scenes");
            Application.LoadLevel(nextLevel);
        }
	}
}
