using System.Diagnostics;

Sorter ob = new SelectionSort();
ob.PrintUnsorted();
ob.Sort();
ob = new MergeSort();
ob.Sort();
ob = new ShellSort();
ob.Sort();

abstract class Sorter
{
    protected int[] arr = { 41, 4, 40, 47, 35, 1, 73, 25, 10, 8, 5, 6 };
    public void Sort()
    {
        var watch = new Stopwatch();

        watch.Start();

        for (int gap = gapValue(arr); gapCheck(gap); gapMove(ref gap))
        {
            for (int i = iValue(gap); iCheck(i, arr); iMove(ref i))
            {
                int index = i;
                int temp = arr[i];
                int j;

                for (j = jValue(i); jCheck1(j, arr, gap) && jCheck2(j, gap, arr, temp); jMove(ref j, gap, i))
                {
                    int mid = Math.Min(j + i - 1, arr.Length - 1);
                    int right_end = Math.Min(j + 2 * i - 1, arr.Length - 1);
                    int n1 = mid - j + 1;
                    int n2 = right_end - mid;
                    int[] L = new int[n1];
                    int[] R = new int[n2];
                    int m1 = 0;
                    int m2 = 0;
                    int k = j;

                    ArrL(ref m1, n1, j, arr, L);
                    ArrR(ref m2, n2, mid, arr, R);

                    while (Cond1(m1, n1) && Cond2(m2, n2))
                    {
                        if (Cond3(m1, m2, L, R))
                        {
                            Merge1(ref m1, k, arr, L);
                        }
                        else
                        {
                            Merge2(ref m2, k, arr, R);
                        }
                        k++;
                    }

                    while (Cond1(m1, n1))
                    {
                        Merge1(ref m1, k, arr, L);
                        k++;
                    }

                    while (Cond2(m2, n2))
                    {
                        Merge2(ref m2, k, arr, R);
                        k++;
                    }

                    if (Condition(arr, j, temp))
                    {
                        Swap(arr, ref temp, ref index, j, gap);
                    }
                }

                Swap1(arr, temp, index, i);
                Swap2(arr, temp, j);
            }
        }
        SortName();
        PrintArray();

        watch.Stop();
        ExecutionTime(watch);
    }

    public void PrintUnsorted()
    {
        Console.WriteLine("Unsorted array");
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(arr[i] + " ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(arr[i] + "  ");
                Console.ResetColor();
            }
        }
        Console.WriteLine("\n");
    }
    public void PrintArray()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 9)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(arr[i] + " ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(arr[i] + "  ");
                Console.ResetColor();
            }

        }
        Console.WriteLine("\n");
    }

    public void ExecutionTime(Stopwatch? watch)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Execution Time: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        if (watch is not null)
        {
            Console.Write($"{watch.ElapsedMilliseconds} ms\n\n");
        }
        Console.ResetColor();
    }
    protected abstract void SortName();
    protected abstract int gapValue(int[] arr);
    protected abstract bool gapCheck(int gap);
    protected abstract void gapMove(ref int gap);
    protected abstract int iValue(int gap);
    protected abstract bool iCheck(int i, int[] arr);
    protected abstract void iMove(ref int i);
    protected abstract int jValue(int i);
    protected abstract bool jCheck1(int j, int[] arr, int gap);
    protected abstract bool jCheck2(int j, int gap, int[] arr, int temp);
    protected abstract void jMove(ref int j, int gap, int i);
    protected abstract void ArrL(ref int m1, int n1, int j, int[] arr, int[] L);
    protected abstract void ArrR(ref int m2, int n2, int mid, int[] arr, int[] R);
    protected abstract void Swap(int[] arr, ref int temp, ref int index, int j, int gap);
    protected abstract void Swap1(int[] arr, int temp, int index, int i);
    protected abstract void Swap2(int[] arr, int temp, int j);
    protected abstract void Merge1(ref int m1, int k, int[] arr, int[] L);
    protected abstract void Merge2(ref int m2, int k, int[] arr, int[] R);
    protected abstract bool Condition(int[] arr, int j, int temp);
    protected abstract bool Cond1(int m1, int n1);
    protected abstract bool Cond2(int m2, int n2);
    protected abstract bool Cond3(int m1, int m2, int[] L, int[] R);
}

class SelectionSort : Sorter
{
    protected override void SortName()
    {
        Console.WriteLine("Selection Sort ");
    }
    protected override int gapValue(int[] arr)
    {
        return 1;
    }

    protected override bool gapCheck(int gap)
    {
        return gap > 0;
    }

    protected override void gapMove(ref int gap)
    {
        gap /= 2;
    }

    protected override int iValue(int gap)
    {
        return gap - 1;
    }

    protected override bool iCheck(int i, int[] arr)
    {
        return i < arr.Length - 1;
    }

    protected override void iMove(ref int i)
    {
        i++;
    }

    protected override int jValue(int i)
    {
        return i + 1;
    }

    protected override bool jCheck1(int j, int[] arr, int gap)
    {
        return j < arr.Length;
    }

    protected override bool jCheck2(int j, int gap, int[] arr, int temp)
    {
        return true;
    }

    protected override void jMove(ref int j, int gap, int i)
    {
        j++;
    }

    protected override void ArrL(ref int m1, int n1, int j, int[] arr, int[] L)
    {
        return;
    }

    protected override void ArrR(ref int m2, int n2, int mid, int[] arr, int[] R)
    {
        return;
    }

    protected override void Swap(int[] arr, ref int temp, ref int index, int j, int gap)
    {
        temp = arr[j];
        index = j;
    }

    protected override void Swap1(int[] arr, int temp, int index, int i)
    {
        arr[index] = arr[i];
        arr[i] = temp;
    }

    protected override void Swap2(int[] arr, int temp, int j)
    {
        return;
    }

    protected override void Merge1(ref int m1, int k, int[] arr, int[] L)
    {
        return;
    }

    protected override void Merge2(ref int m2, int k, int[] arr, int[] R)
    {
        return;
    }

    protected override bool Condition(int[] arr, int j, int temp)
    {
        return temp > arr[j];
    }

    protected override bool Cond1(int m1, int n1)
    {
        return false;
    }

    protected override bool Cond2(int m2, int n2)
    {
        return false;
    }

    protected override bool Cond3(int m1, int m2, int[] L, int[] R)
    {
        return false;
    }
}

class MergeSort : Sorter
{
    protected override void SortName()
    {
        Console.WriteLine("Merge Sort ");
    }
    protected override int gapValue(int[] arr)
    {
        return 1;
    }

    protected override bool gapCheck(int gap)
    {
        return gap > 0;
    }

    protected override void gapMove(ref int gap)
    {
        gap /= 2;
    }

    protected override int iValue(int gap)
    {
        return 1;
    }

    protected override bool iCheck(int i, int[] arr)
    {
        return i < arr.Length;
    }

    protected override void iMove(ref int i)
    {
        i = 2 * i;
    }

    protected override int jValue(int i)
    {
        return 0;
    }

    protected override bool jCheck1(int j, int[] arr, int gap)
    {
        return j < arr.Length - 1;
    }

    protected override bool jCheck2(int j, int gap, int[] arr, int temp)
    {
        return true;
    }

    protected override void jMove(ref int j, int gap, int i)
    {
        j += 2 * i;
    }

    protected override void ArrL(ref int m1, int n1, int j, int[] arr, int[] L)
    {
        for (m1 = 0; m1 < n1; m1++)
        {
            L[m1] = arr[j + m1];
        }
        m1 = 0;
    }

    protected override void ArrR(ref int m2, int n2, int mid, int[] arr, int[] R)
    {
        for (m2 = 0; m2 < n2; m2++)
        {
            R[m2] = arr[mid + 1 + m2];
        }
        m2 = 0;
    }

    protected override void Swap(int[] arr, ref int temp, ref int index, int j, int gap)
    {
        return;
    }

    protected override void Swap1(int[] arr, int temp, int index, int i)
    {
        return;
    }

    protected override void Swap2(int[] arr, int temp, int j)
    {
        return;
    }

    protected override void Merge1(ref int m1, int k, int[] arr, int[] L)
    {
        arr[k] = L[m1];
        m1++;
    }

    protected override void Merge2(ref int m2, int k, int[] arr, int[] R)
    {
        arr[k] = R[m2];
        m2++;
    }

    protected override bool Condition(int[] arr, int j, int temp)
    {
        return false;
    }

    protected override bool Cond1(int m1, int n1)
    {
        return m1 < n1;
    }

    protected override bool Cond2(int m2, int n2)
    {
        return m2 < n2;
    }

    protected override bool Cond3(int m1, int m2, int[] L, int[] R)
    {
        return L[m1] <= R[m2];
    }
}

class ShellSort : Sorter
{
    protected override void SortName()
    {
        Console.WriteLine("Shell Sort ");
    }
    protected override int gapValue(int[] arr)
    {
        return arr.Length / 2;
    }

    protected override bool gapCheck(int gap)
    {
        return gap > 0;
    }

    protected override void gapMove(ref int gap)
    {
        gap /= 2;
    }

    protected override int iValue(int gap)
    {
        return gap;
    }

    protected override bool iCheck(int i, int[] arr)
    {
        return i < arr.Length;
    }

    protected override void iMove(ref int i)
    {
        i++;
    }

    protected override int jValue(int i)
    {
        return i;
    }

    protected override bool jCheck1(int j, int[] arr, int gap)
    {
        return j >= gap;
    }

    protected override bool jCheck2(int j, int gap, int[] arr, int temp)
    {
        return arr[j - gap] > temp;
    }

    protected override void jMove(ref int j, int gap, int i)
    {
        j -= gap;
    }

    protected override void ArrL(ref int m1, int n1, int j, int[] arr, int[] L)
    {
        return;
    }

    protected override void ArrR(ref int m2, int n2, int mid, int[] arr, int[] R)
    {
        return;
    }

    protected override void Swap(int[] arr, ref int temp, ref int index, int j, int gap)
    {
        arr[j] = arr[j - gap];
    }

    protected override void Swap1(int[] arr, int temp, int index, int i)
    {
        return;
    }

    protected override void Swap2(int[] arr, int temp, int j)
    {
        arr[j] = temp;
    }

    protected override void Merge1(ref int m1, int k, int[] arr, int[] L)
    {
        return;
    }

    protected override void Merge2(ref int m2, int k, int[] arr, int[] R)
    {
        return;
    }

    protected override bool Condition(int[] arr, int j, int temp)
    {
        return true;
    }

    protected override bool Cond1(int m1, int n1)
    {
        return false;
    }

    protected override bool Cond2(int m2, int n2)
    {
        return false;
    }

    protected override bool Cond3(int m1, int m2, int[] L, int[] R)
    {
        return false;
    }
}