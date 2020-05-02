using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

	public Slider eSlider;

	public void SetMaxHealth(int health)
	{
		eSlider.maxValue = health;
		eSlider.value = health;

		//fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(int health)
	{
		eSlider.value = health;

		//fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}