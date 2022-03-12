using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public List<Image> hearts = new List<Image>();
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void removeHeath() {
        if (name == "Player One Health") {
            if (hearts.Count != 0) {
                hearts[hearts.Count-1].enabled = false;
                hearts.RemoveAt(hearts.Count-1);
            } else {
                Destroy(this.gameObject);
            }
        } else {
            if (hearts.Count != 0) {
                hearts[0].enabled = false;
                hearts.RemoveAt(0);
            } else {
                Destroy(this.gameObject);
            }
        }
    }
}
