using UnityEngine;
using Tetris.Managers;

namespace Tetris.Game
{
    public class Pieces : MonoBehaviour
    {
        [Header("Point of Rotation.")]
        [SerializeField]
        private Vector3 rotationPoint = Vector3.zero;

        private float timer = 0f;

        private bool canMove = true;

        private GridManager gridManager;

        private void Start() => gridManager = GridManager.GetInstance();

        private void Update() => CheckInput();

        private void CheckInput()
        {
            if (canMove)
            {
                timer += Time.deltaTime;

                if (Input.GetKey(KeyCode.DownArrow) && timer > gridManager.fastDropTime)
                {
                    transform.position -= new Vector3(0, 1, 0);
                    timer = 0f;

                    if (!CheckValid())
                        DisableBlock();
                }

                else if (timer > gridManager.dropTime)
                {
                    transform.position -= new Vector3(0, 1, 0);
                    timer = 0f;

                    if (!CheckValid())
                        DisableBlock();
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(1, 0, 0);

                    if (!CheckValid())
                        transform.position -= new Vector3(1, 0, 0);
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-1, 0, 0);
                    if (!CheckValid())
                        transform.position += new Vector3(1, 0, 0);
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, 90f);
                    if (!CheckValid())
                        transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, -90f);
                }
            }
        }

        private void DisableBlock()
        {
            canMove = false;
            transform.position += new Vector3(0, 1, 0);
            StoreBlockInGrid();
            gridManager.ClearLine();
            gridManager.SpawnPiece();
        }

        private bool CheckValid()
        {
            foreach (Transform block in transform)
            {
                int x = Mathf.RoundToInt(block.position.x);
                int y = Mathf.RoundToInt(block.position.y);

                if (x >= GridManager.width || x <= 0 || y <= 0 || y >= GridManager.height)
                {
                    return false;
                }

                if (gridManager.grid[x, y] != null)
                {
                    return false;
                }
            }

            return true;
        }

        private void StoreBlockInGrid()
        {
            foreach (Transform block in transform)
            {
                int x = Mathf.RoundToInt(block.transform.position.x);
                int y = Mathf.RoundToInt(block.transform.position.y);
                gridManager.StoreBlockInGrid(block, x, y);
            }

            gridManager.CheckLost();
        }
    }
}