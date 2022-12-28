using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDestroyer : MonoBehaviour
{
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 20 && transform.position.z < player.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
