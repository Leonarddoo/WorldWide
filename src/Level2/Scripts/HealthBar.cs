using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script de la barre de Vie
public class HealthBar : MonoBehaviour
{
    //On initalise l'image de notre bar de vie
    public Image barImage;

    private void Awake(){
        //On récupere l'image de la barre de vie
        barImage = transform.Find("Health").GetComponent<Image>();
    }

    void Update(){

        //Permet de modifier la taille de l'image de façon horizontale selon le resultat de notre méthode
        barImage.fillAmount = Health.GetWaterNormalized();
        //Si le resultat de la méthode est inférieur ou égal à 0, notre joueur est mort
        if(Health.GetWaterNormalized() <= 0){
            GameOverScript.lastScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("GameOverScreen");
        }
    }
}

public class Health {

    //Constante qui indique le montant maximum de vie qu'on peut avoir
    public const int HEALTH_MAX = 100;

    //Attribut qui correspond au montant de vie que l'on a
    public static float healthAmount = 100;


    //Sur Unity la taille de l'image de la barre est compris entre 0 et 1.
    // 0 --> L'image est invisible 
    // 1 --> L'image prend l'intégralité de la zone qui lui est dédié (horizontalement)
    // Ce calcul permet d'avoir un nombre entre 0 et 1 pour modifier la taille de barre
    public static float GetWaterNormalized(){
        return healthAmount / HEALTH_MAX;
    }

    //Permet de remonter notre niveau de vie au MAX.
    public static void FullBar(){
        healthAmount = HEALTH_MAX;
    }

    public static void GetDamage(int damage){
        healthAmount -= damage;
    }
}
