using UnityEngine;
using UnityEngine.InputNew;

// GENERATED FILE - DO NOT EDIT MANUALLY
public class PlayerActionMap : ActionMapInput {
	public PlayerActionMap (ActionMap actionMap) : base (actionMap) { }
	
	public AxisInputControl @moveX { get { return (AxisInputControl)this[0]; } }
	public AxisInputControl @moveY { get { return (AxisInputControl)this[1]; } }
	public Vector2InputControl @move { get { return (Vector2InputControl)this[2]; } }
	public AxisInputControl @aimX { get { return (AxisInputControl)this[3]; } }
	public AxisInputControl @aimY { get { return (AxisInputControl)this[4]; } }
	public Vector2InputControl @aim { get { return (Vector2InputControl)this[5]; } }
	public ButtonInputControl @attack { get { return (ButtonInputControl)this[6]; } }
	public ButtonInputControl @changeWeapon { get { return (ButtonInputControl)this[7]; } }
}
