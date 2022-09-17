// Задача №54 и №56

Console.WriteLine($"Задачи 54 и 56 совместно, итак начнем...");
int m = InputNumbers("Enter number of rows: ");
int n = InputNumbers("Enter numbers of columns: ");
int range = InputNumbers("Enter a range of numbers from 1 to ");

int[,] array = new int[m, n];
CreateArray(array);
WriteArray(array);

Console.WriteLine($"\nArray in descending order: ");
OrderArrayLines(array);
WriteArray(array);

void OrderArrayLines(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      for (int k = 0; k < array.GetLength(1) - 1; k++)
      {
        if (array[i, k] < array[i, k + 1])
        {
          int temp = array[i, k + 1];
          array[i, k + 1] = array[i, k];
          array[i, k] = temp;
        }
      }
    }
  }
}

int InputNumbers(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

void CreateArray(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      array[i, j] = new Random().Next(range);
    }
  }
}

void WriteArray(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      Console.Write(array[i, j] + " ");
    }
    Console.WriteLine();
  }
}

// Тут начинается решение для Задачи №56

int minSumLine = 0;
int sumLine = SumLineElements(array, 0);
for (int i = 1; i < array.GetLength(0); i++)
{
  int tempSumLine = SumLineElements(array, i);
  if (sumLine > tempSumLine)
  {
    sumLine = tempSumLine;
    minSumLine = i;
  }
}

Console.WriteLine($"\n{minSumLine+1} - row with smallest sum ({sumLine}) of elements.");

int SumLineElements(int[,] array, int i)
{
  int sumLine = array[i,0];
  for (int j = 1; j < array.GetLength(1); j++)
  {
    sumLine += array[i,j];
  }
  return sumLine;
}

// Задача №58

Console.WriteLine($"Задача 58:");
int rows = ReadInt("Enter row numbers: ");
int columns = ReadInt("Enter column numbers: ");
int[,] NewArray = new int[rows, columns];
int[,] secondArray = new int[rows, columns];
int[,] resultArray = new int[rows, columns];

FillArrayRandom(NewArray);
PrintArray2D(NewArray);

Console.WriteLine();

FillArrayRandom(secondArray);
PrintArray2D(secondArray);

Console.WriteLine();

if (NewArray.GetLength(0) != secondArray.GetLength(1))
{
    Console.WriteLine("Cannot be multiplied!");
    return;
}
for (int i = 0; i < NewArray.GetLength(0); i++)
{
    for (int j = 0; j < secondArray.GetLength(1); j++)
    {
        resultArray[i, j] = 0;
        for (int k = 0; k < NewArray.GetLength(1); k++)
        {
            resultArray[i, j] += NewArray[i, k] * secondArray[k, j];
        }
    }
}

PrintArray2D(resultArray);

int ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

void FillArrayRandom(int[,] NewArray)
{
    for (int i = 0; i < NewArray.GetLength(0); i++)
    {
        for (int j = 0; j < NewArray.GetLength(1); j++)
        {
            NewArray[i, j] = new Random().Next(1, 10);
        }
    }
}

// Функция вывода двумерного массива в терминал 
void PrintArray2D(int[,] NewArray)
{
    for (int i = 0; i < NewArray.GetLength(0); i++)
    {
        for (int j = 0; j < NewArray.GetLength(1); j++)
        {
            Console.Write($"{NewArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

// Задача №60

Console.WriteLine($"Enter array size X x Y x Z");
int x = InputNumbers("Enter X: ");
int y = InputNumbers("Enter Y: ");
int z = InputNumbers("Enter Z: ");
Console.WriteLine($"");

int[,,] array3D = new int[x, y, z];
CreateArray(array3D);
WriteArray(array3D);

int InputNumbers(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

void WriteArray (int[,,] array3D)
{
  for (int i = 0; i < array3D.GetLength(0); i++)
  {
    for (int j = 0; j < array3D.GetLength(1); j++)
    {
      Console.Write($"X({i}) Y({j}) ");
      for (int k = 0; k < array3D.GetLength(2); k++)
      {
        Console.Write( $"Z({k})={array3D[i,j,k]}; ");
      }
      Console.WriteLine();
    }
    Console.WriteLine();
  }
}

void CreateArray(int[,,] array3D)
{
  int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
  int  number;
  for (int i = 0; i < temp.GetLength(0); i++)
  {
    temp[i] = new Random().Next(10, 100);
    number = temp[i];
    if (i >= 1)
    {
      for (int j = 0; j < i; j++)
      {
        while (temp[i] == temp[j])
        {
          temp[i] = new Random().Next(10, 100);
          j = 0;
          number = temp[i];
        }
          number = temp[i];
      }
    }
  }
  int count = 0; 
  for (int x = 0; x < array3D.GetLength(0); x++)
  {
    for (int y = 0; y < array3D.GetLength(1); y++)
    {
      for (int z = 0; z < array3D.GetLength(2); z++)
      {
        array3D[x, y, z] = temp[count];
        count++;
      }
    }
  }
}

// Задача №60

int n = 4;
int[,] sqareMatrix = new int[n, n];

int temp = 1;
int i = 0;
int j = 0;

while (temp <= sqareMatrix.GetLength(0) * sqareMatrix.GetLength(1))
{
  sqareMatrix[i, j] = temp;
  temp++;
  if (i <= j + 1 && i + j < sqareMatrix.GetLength(1) - 1)
    j++;
  else if (i < j && i + j >= sqareMatrix.GetLength(0) - 1)
    i++;
  else if (i >= j && i + j > sqareMatrix.GetLength(1) - 1)
    j--;
  else
    i--;
}

WriteArray(sqareMatrix);

void WriteArray (int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      if (array[i,j] / 10 <= 0)
      Console.Write($" {array[i,j]} ");

      else Console.Write($"{array[i,j]} ");
    }
    Console.WriteLine();
  }
}