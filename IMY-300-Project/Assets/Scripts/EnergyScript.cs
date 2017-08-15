using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
	public Image EnergyImg;
	public Text EnergyText;
  private float energy = 200;
  private float MAX_ENERGY = 200;

  //float ticker = energy/1000;

  void Start()
  {
    updateEnergyBar();
		//Debug.Log("Energy Updated");
  }

  void Update()
  {
    float ticker = energy/200000;
    removeEnergy(ticker);
    updateEnergyBar();
  }

  private void updateEnergyBar()
  {
    float ratio = energy/MAX_ENERGY;
		EnergyImg.rectTransform.localScale = new Vector3(ratio, 1, 1);
		EnergyText.text = "Energy: " + (ratio*100).ToString("0") + "%";
		//Debug.Log("Health updated");
  }

  public void removeEnergy(float e)
  {
    energy -= e;
    if(energy <= 0)
		{
			energy = 0;
		}
		//Debug.Log("Energy Lost");
    updateEnergyBar();
  }

  public void giveEnergy(float e)
  {
    energy += e;
    if(energy >= MAX_ENERGY)
		{
			energy = MAX_ENERGY;
		}
    updateEnergyBar();
		//Debug.Log("Energy Recieved");
  }
}
