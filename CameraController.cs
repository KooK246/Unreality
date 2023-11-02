using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OK
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;

        void Update()
        {
                transform.position = new Vector3(player.position.x, player.position.y+1f, transform.position.z);
        }
    }    
}