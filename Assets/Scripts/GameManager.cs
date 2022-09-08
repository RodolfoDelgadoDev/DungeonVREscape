using UnityEngine;

/// <summary>
/// Access to other scripts using only this one,
/// gives less variables to read and write
/// </summary>
public class GameManager : MonoBehaviour
{
	public WaterRuneTrigger waterRuneTrigger;
	public EarthRuneTrigger earthRuneTrigger;
	public FireRuneTrigger fireRuneTrigger;
	public RunesCount runesCount;
	public Chests chests;
	public OpenCloseDoors openCloseDoors;

	// SMoke
}
