using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayOffOnGrab : MonoBehaviour
{
	[Header("Player Left Hand")]
	[SerializeField] private XRInteractorLineVisual _leftXRInteractorLineVisual;

	[Space(1)]
	[Header("Player Right Hand")]
	[SerializeField] private XRInteractorLineVisual _rightXRInteractorLineVisual;

	/// <summary>
	/// Turn the left hand ray off
	/// </summary>
	public void LeftHandRayOff()
	{
		_leftXRInteractorLineVisual.enabled = false;
	}

	/// <summary>
	/// Turn the left hand ray on
	/// </summary>
	public void LeftHandRayOn()
	{
		_leftXRInteractorLineVisual.enabled = true;
	}

	/// <summary>
	/// Turn the right hand ray off
	/// </summary>
	public void RightHandRayOff()
	{
		_rightXRInteractorLineVisual.enabled = false;
	}

	/// <summary>
	/// Turn the right hand ray on
	/// </summary>
	public void RightHandRayOn()
	{
		_rightXRInteractorLineVisual.enabled = true;
	}
}
