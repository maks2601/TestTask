using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action EndGame;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            EndGame.Invoke();
        }
    }
}
