using UnityEngine;

/// <summary>
/// Open close doors
/// </summary>
public class OpenCloseDoors : MonoBehaviour
{
	#region Doors GameObjects Variables
	[SerializeField] private GameObject[] _waterDoors;
	[SerializeField] private GameObject[] _earthDoors;
	[SerializeField] private GameObject[] _fireDoors;
	public GameObject exitDoor;
	#endregion

	#region Open Close Doors Functions
	/// <summary>
	/// Open Water doors
	/// </summary>
	public void OpenWaterDoors()
	{
		foreach (GameObject waterDoor in _waterDoors)
		{
			waterDoor.SetActive(false);
		}
	}

	/// <summary>
	/// Close Water doors
	/// </summary>
	public void CloseWaterDoors()
	{
		foreach (GameObject waterDoor in _waterDoors)
		{
			waterDoor.SetActive(true);
		}
	}

	/// <summary>
	/// Open Earth doors
	/// </summary>
	public void OpenEarthDoors()
	{
		foreach (GameObject earthDoor in _earthDoors)
		{
			earthDoor.SetActive(false);
		}
	}

	/// <summary>
	/// Close Earth doors
	/// </summary>
	public void CloseEarthDoors()
	{
		foreach (GameObject earthDoor in _earthDoors)
		{
			earthDoor.SetActive(true);
		}
	}

	/// <summary>
	/// Open Fire doors
	/// </summary>
	public void OpenFireDoors()
	{
		foreach (GameObject fireDoor in _fireDoors)
		{
			fireDoor.SetActive(false);
		}
	}

	/// <summary>
	/// Close Fire doors
	/// </summary>
	public void CloseFireDoors()
	{
		foreach (GameObject fireDoor in _fireDoors)
		{
			fireDoor.SetActive(true);
		}
	}
	#endregion
}

