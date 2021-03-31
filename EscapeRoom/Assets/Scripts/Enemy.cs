using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Lost");
            LoadScene("LoseScreen");

            Cursor.visible = true;
        }
        if (other.CompareTag("Win"))
        {
            LoadScene("WinScreen");
            Cursor.visible = true;
        }
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
