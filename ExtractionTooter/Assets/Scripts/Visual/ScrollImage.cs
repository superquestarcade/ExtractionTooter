using UnityEngine;

public class ScrollImage : MonoBehaviour
{
	// Speed of the scrolling pattern
	public Vector2 scrollSpeed = new Vector2(-0.5f, 0f);

	// Reference to the Renderer
	private Material material;
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		// Get the material from the sprite's renderer
		material = GetComponent<Renderer>().material;
		spriteRenderer = GetComponent<SpriteRenderer>();
		material.color = spriteRenderer.color;
	}

	private void Update()
	{
		// Calculate the new offset
		Vector2 offset = scrollSpeed * Time.time;

		// Apply the offset to the material
		material.mainTextureOffset = offset;
	}
}
