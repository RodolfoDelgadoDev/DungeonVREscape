using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
	#region Doors GameObjects Variables
	[SerializeField] private GameObject[] _waterDoors;
	//[SerializeField] private GameObject[] _earthDoors;
	//[SerializeField] private GameObject[] _fireDoors;
	#endregion

	[SerializeField] private GameManager _gameManager;

	public void OpenWaterDoors(GameObject chest)
	{
		if (chest.activeSelf == false)
		{
			foreach (GameObject waterDoor in _waterDoors)
			{
				waterDoor.SetActive(false);
			}
		}
	}

	// when chest disabled
	// open doors of the chest room
}
