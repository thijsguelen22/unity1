using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
    public int maxHealth = 100;
    public int damage = 0;
    private float time;
    public Image dot1;
    public Image dot2;
    public Image dot3;
    public Image dot4;
    public Image dot5;
    public Image dot6;
    public Image dot7;
    public Image dot8;
    public Image dot9;
    public Image dot10;
    private int currentHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        damage += ((int)time / 100);
        currentHealth = maxHealth - damage;
        if(currentHealth < 101 && currentHealth > 89)
        {
            float redFactor = damage * 25.5f;
            changeColor(dot1, redFactor);
            resetDot(dot2);
        }
        if (currentHealth < 91 && currentHealth > 79)
        {
            float redFactor = damage * 25.5f;
            changeColor(dot2, redFactor);
            disableDot(dot1);
            resetDot(dot3);
        }
        if (currentHealth < 81 && currentHealth > 69)
        {
            float redFactor = damage * 25.5f;
            changeColor(dot3, redFactor);
            disableDot(dot2);
            resetDot(dot4);
        }
        if (currentHealth < 71 && currentHealth > 59)
        {
            float redFactor = damage * 25.5f;
            changeColor(dot4, redFactor);
            disableDot(dot3);
            resetDot(dot5);
        }
        if (currentHealth < 61 && currentHealth > 49)
        {
            float redFactor = damage * 25.5f;
            changeColor(dot5, redFactor);
            disableDot(dot4);
            resetDot(dot6);
        }
        if (currentHealth < 51 && currentHealth > 39)
        {
            float redFactor = damage * 25.5f;
            changeColor(dot6, redFactor);
            disableDot(dot5);
            resetDot(dot7);
        }
        if (currentHealth < 41 && currentHealth > 29)
        {
            float redFactor = damage * 25.5f;
            changeColor(dot7, redFactor);
            disableDot(dot6);
            resetDot(dot8);
        }
        if (currentHealth < 31 && currentHealth > 19)
        {
            float redFactor = damage * 25.5f;
            changeColor(dot8, redFactor);
            disableDot(dot7);
            resetDot(dot9);
        }
    }

    void changeColor(Image dot, float redFactor)
    {
        dot.GetComponent<Image>().color = new Color32(255, (byte)(255 - redFactor), (byte)(255 - redFactor), 255);
    }

    void disableDot(Image dot)
    {
        dot.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
    }

    void resetDot(Image dot)
    {
        dot.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
        
}
