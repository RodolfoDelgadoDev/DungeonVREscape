using UnityEngine;

/// <summary>
/// Access to other scripts using only this one,
/// gives less variables to read and write
/// </summary>
public class GameManager : MonoBehaviour
{
	public RunesCount runesCount;
	public RunesTriggers runesTriggers;
	public Chests chests;
	public OpenCloseDoors openCloseDoors;
}
