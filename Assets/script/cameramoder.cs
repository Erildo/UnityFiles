using UnityEngine;
using System.Collections;

public class cameramoder : MonoBehaviour {
    public Transform lookat;

    private Vector3 offset = new Vector3(0,0,-6.5f);
	private void Start () {


    }
    private void Lateupdate()
    {
        transform.position = lookat.transform.position + offset;

    }


}
