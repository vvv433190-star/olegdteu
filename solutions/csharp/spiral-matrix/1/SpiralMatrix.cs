public static class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];

        int value = 1;
        int top = 0;
        int bottom = size - 1;
        int left = 0;
        int right = size - 1;

        while (top <= bottom && left <= right)
        {
            // ⬅ Слева направо
            for (int j = left; j <= right; j++)
                matrix[top, j] = value++;
            top++;

            // ⬇ Сверху вниз
            for (int i = top; i <= bottom; i++)
                matrix[i, right] = value++;
            right--;

            if (top <= bottom)
            {
                // ➡ Справа налево
                for (int j = right; j >= left; j--)
                    matrix[bottom, j] = value++;
                bottom--;
            }

            if (left <= right)
            {
                // ⬆ Снизу вверх
                for (int i = bottom; i >= top; i--)
                    matrix[i, left] = value++;
                left++;
            }
        }

        return matrix;
    }
}

