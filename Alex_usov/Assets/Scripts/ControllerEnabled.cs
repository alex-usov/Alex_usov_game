using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnabled : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] bool isPlayScene;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (isPlayScene)
        {
            player.enabled = true;
            _animator.SetBool("ShopMode", false);
        }
        else
        {
            player.enabled = false;
            _animator.SetBool("ShopMode", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
