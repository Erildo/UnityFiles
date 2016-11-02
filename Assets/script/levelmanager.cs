using UnityEngine;
using System.Collections;

public class levelmanager : MonoBehaviour {
    public Transform spanposition;
    private int deathpoint = 3;
    private int score = 0;
    public Transform playertransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (playertransform.position.y < -10)
        {
            playertransform.position = spanposition.position;
            deathpoint--;
            if (deathpoint <= 0)
            {
                Debug.Log("Failure");
            }   
         
        }
	}

}
