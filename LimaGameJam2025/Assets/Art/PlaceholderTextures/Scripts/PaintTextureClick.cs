
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTexture : MonoBehaviour
{
    [SerializeField] private GameObject vCam;
    [SerializeField] private string vCamName = "camPlayer";
    [SerializeField] private Texture2D dirtMaskTextureBase;
    [SerializeField] private Texture2D dirtBrush;
    [SerializeField] private Material material;
    [SerializeField] private int brushSize2 = 20; // Larger brush size
    private Texture2D dirtMaskTexture;
    private bool isFlipped;
    private Animation solarAnimation;
    private Vector2Int lastPaintPixelPosition;
    private float lastPaintTime; // Timer to control painting rate
    [SerializeField] private float paintRate = 0.1f; // Paint every 0.1 seconds
    [SerializeField] private float maxPaintDistance = 4f;
    [SerializeField] private LayerMask wallLayer; // Assign this in the Inspector

    private Vector3 rayOrigin;
    private Vector3 rayDirection;
    private float maxDistanceRay = 10f; // Adjust this to set the maximum distance for raycast
    private RaycastHit lastRaycastHit;

    private void Awake()
    {
        dirtMaskTexture = new Texture2D(dirtMaskTextureBase.width, dirtMaskTextureBase.height, TextureFormat.RGBA32, false);

        RenderTexture temp = RenderTexture.GetTemporary(dirtMaskTextureBase.width, dirtMaskTextureBase.height, 0, RenderTextureFormat.ARGB32);
        Graphics.Blit(dirtMaskTextureBase, temp);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = temp;
        dirtMaskTexture.ReadPixels(new Rect(0, 0, temp.width, temp.height), 0, 0);
        dirtMaskTexture.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(temp);

        material.SetTexture("_CleanMask", dirtMaskTexture);

        solarAnimation = GetComponent<Animation>();
    }

    private void Start()
    {
        vCam = GameObject.Find(vCamName);

        if (vCam == null)
        {
            Debug.LogError("vCam not found! Check if the name matches the GameObject in the scene.");
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= lastPaintTime + paintRate)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit))
            {
                Vector2 textureCoord = raycastHit.textureCoord;

                int pixelX = (int)(textureCoord.x * dirtMaskTexture.width);
                int pixelY = (int)(textureCoord.y * dirtMaskTexture.height);

                Vector2Int paintPixelPosition = new Vector2Int(pixelX, pixelY);

                int paintPixelDistance = Mathf.Abs(paintPixelPosition.x - lastPaintPixelPosition.x) + Mathf.Abs(paintPixelPosition.y - lastPaintPixelPosition.y);
                int maxPaintDistance = 7;
                if (paintPixelDistance < maxPaintDistance)
                {
                    return; // Painting too close to last position
                }
                lastPaintPixelPosition = paintPixelPosition;

                PaintBlack(pixelX, pixelY);
                lastPaintTime = Time.time; // Reset the timer
            }
        }

        
    }

    private void PaintBlack(int pixelX, int pixelY)
    {
        int halfSize = brushSize2 / 2;

        for (int x = 0; x < brushSize2; x++)
        {
            for (int y = 0; y < brushSize2; y++)
            {
                // Calculate target texture coordinates
                int destX = pixelX + x - halfSize;
                int destY = pixelY + y - halfSize;

                // Check bounds to avoid painting outside the mask texture
                if (destX >= 0 && destX < dirtMaskTexture.width &&
                    destY >= 0 && destY < dirtMaskTexture.height)
                {
                    // Sample the brush texture at the current point
                    float brushU = (float)x / brushSize2;
                    float brushV = (float)y / brushSize2;
                    Color brushColor = dirtBrush.GetPixelBilinear(brushU, brushV);

                    // Skip if the brush pixel is fully transparent
                    if (brushColor.a <= 0f) continue;

                    // Blend the current dirt mask pixel with the brush color
                    Color maskColor = dirtMaskTexture.GetPixel(destX, destY);
                    Color resultColor = Color.Lerp(maskColor, Color.black, brushColor.a);

                    // Apply the result color to the mask texture
                    dirtMaskTexture.SetPixel(destX, destY, resultColor);
                }
            }
        }

        // Apply changes to the mask texture
        dirtMaskTexture.Apply();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin, rayOrigin + rayDirection * maxDistanceRay);

        if (lastRaycastHit.collider != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(lastRaycastHit.point, 0.1f);
        }
    }
}



//use this aproach combined with the corrections, it updates the texture too slow
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class SolarPanel : MonoBehaviour
//{
//    [SerializeField] private Texture2D dirtMaskTextureBase;
//    [SerializeField] private Texture2D dirtBrush;
//    [SerializeField] private Material material;
//    [SerializeField] private TextMeshProUGUI uiText;
//    [SerializeField] private Collider paintCollider; // Reference to the collider defining the paint area

//    private Texture2D dirtMaskTexture;
//    private bool isFlipped;
//    private Animation solarAnimation;
//    private float dirtAmountTotal;
//    private float dirtAmount;
//    private Vector2Int lastPaintPixelPosition;
//    private float nextUpdateTime = 0f;

//    private void Awake()
//    {
//        dirtMaskTexture = new Texture2D(dirtMaskTextureBase.width, dirtMaskTextureBase.height);
//        dirtMaskTexture.SetPixels(dirtMaskTextureBase.GetPixels());
//        dirtMaskTexture.Apply();
//        material.SetTexture("_CleanMask", dirtMaskTexture);

//        solarAnimation = GetComponent<Animation>();

//        dirtAmountTotal = 0f;
//        for (int x = 0; x < dirtMaskTextureBase.width; x++)
//        {
//            for (int y = 0; y < dirtMaskTextureBase.height; y++)
//            {
//                dirtAmountTotal += dirtMaskTextureBase.GetPixel(x, y).g;
//            }
//        }
//        dirtAmount = dirtAmountTotal;

//        Ensure paintCollider is set in the inspector
//        if (paintCollider == null)
//        {
//            Debug.LogError("Paint collider is not assigned!");
//        }
//    }

//    private void Update()
//    {
//        if (Input.GetMouseButton(0))
//        {
//            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, float.MaxValue, 1 << paintCollider.gameObject.layer))
//            {
//                Check if the hit collider is the one we're painting on
//                if (hit.collider == paintCollider)
//                {
//                    Vector2 pixelUV = hit.textureCoord;
//                    Vector2Int pixelPos = new Vector2Int(
//                        Mathf.RoundToInt(pixelUV.x * dirtMaskTexture.width),
//                        Mathf.RoundToInt(pixelUV.y * dirtMaskTexture.height)
//                    );

//                    PaintArea(pixelPos);
//                }
//            }
//        }

//        Check if it's time to update the texture
//        if (Time.time >= nextUpdateTime)
//        {
//            dirtMaskTexture.Apply();
//            nextUpdateTime = Time.time + 0.1f;
//        }

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            isFlipped = !isFlipped;
//            if (isFlipped)
//            {
//                solarAnimation.Play("SolarPanelFlip");
//            }
//            else
//            {
//                solarAnimation.Play("SolarPanelFlipBack");
//            }
//        }
//    }

//    private void PaintArea(Vector2Int pixelPos)
//    {
//        if (IsWithinBounds(pixelPos.x, pixelPos.y))
//        {
//            Color pixelDirt = dirtBrush.GetPixel(0, 0); // Assuming brush is just a point or you need to adapt for a larger brush
//            Color pixelDirtMask = dirtMaskTexture.GetPixel(pixelPos.x, pixelPos.y);

//            float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
//            dirtAmount -= removedAmount;

//            dirtMaskTexture.SetPixel(pixelPos.x, pixelPos.y,
//                new Color(0, pixelDirtMask.g * pixelDirt.g, 0));

//            If you want to paint more than one pixel, you would need to expand this logic to consider the collider's shape
//        }
//    }

//    private bool IsWithinBounds(int x, int y)
//    {
//        return x >= 0 && x < dirtMaskTexture.width && y >= 0 && y < dirtMaskTexture.height;
//    }

//    private float GetDirtAmount()
//    {
//        return this.dirtAmount / dirtAmountTotal;
//    }
//}