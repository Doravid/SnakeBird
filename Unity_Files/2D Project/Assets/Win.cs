using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    //The particle system that will be turned on/off when you are able to win the level
    public ParticleSystem particles;

    //Placeholder next lol
    public string nextLevel = "";

    void Update()
    { 
        //Makes a variable for all objects with the tag "Fruit"
        var numies = GameObject.FindGameObjectsWithTag("Fruit");
        

        //If there there are Fruit left turn off the particles if there are no fruit left turn on the particles
        if (numies.Length == 0 && particles.isPlaying == false)
        {
            particles.Play();
        }
        if (numies.Length != 0 && particles.isPlaying == true)
        {
            particles.Stop();
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Makes a variable for all objects with the tag "Fruit"
        var numies = GameObject.FindGameObjectsWithTag("Fruit");


        //If you collide with the player while there are no frutis left you load the next level
        if (other.tag == "Player" && numies.Length == 0)
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(nextLevel);

        }
    }
}
