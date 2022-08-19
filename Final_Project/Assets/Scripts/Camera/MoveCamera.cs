using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player;
    public float cameraSmooth;

    /// Start is called before the first frame update
    private void Awake()
    {
        transform.position = player.transform.position;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FocusOnPlayer();
    }


    void FocusOnPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = Vector3.Lerp(transform.position, playerPosition, Time.deltaTime * cameraSmooth);
    }

}
