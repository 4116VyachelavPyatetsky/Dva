using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Pyatnaski_main : MonoBehaviour
{
    public float size = 160f;
    public GameObject[] parts;

    public GameObject seif;
    public GameObject key;

    int[,] matrix_right = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

    int[,] matrix_real = {
            { 9, 4, 6 },
            { 2, 1, 3 },
            { 8, 5, 7 }
        };


    public void Move(int serial_number)
    {
        // Находим позицию числа 9
        (int row9, int col9) = (-1, -1);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix_real[i, j] == 9)
                {
                    row9 = i;
                    col9 = j;
                    break;
                }
            }
            if (row9 != -1) break; // Выход из внешнего цикла, если 9 найдена
        }

        // Проверка соседних ячеек
        int[][] directions = {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
        };
        foreach (int[] dir in directions)
        {
            int newRow = row9 + dir[0];
            int newCol = col9 + dir[1];

            if (newRow >= 0 && newRow < 3 && newCol >= 0 && newCol < 3)
            {
                if (matrix_real[newRow, newCol] == serial_number)
                {
                    // Меняем местами
                    Change_plitku(row9, col9, serial_number);
                    matrix_real[row9, col9] = serial_number;
                    matrix_real[newRow, newCol] = 9;
                    if (AreMatricesEqual()) End();
                    return;
                }
            }
        }
    }

    void Change_plitku(int row,int col,int num)
    {
        transform.GetChild(num).localPosition = new Vector3(size * (col - 1), size * -(row - 1), 0);
    }

    void End()
    {
        Instantiate(key, transform.parent);
        Scripte_for_min_znach.found_key_in_seif = true;
        seif.SetActive(false);
        gameObject.SetActive(false);
    }

    public bool AreMatricesEqual()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix_right[i, j] != matrix_real[i, j])
                    return false;
            }
        }
        return true;
    }
}
