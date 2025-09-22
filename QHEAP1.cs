using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int Q = Convert.ToInt32(Console.ReadLine());
        SortedSet<(int val, int id)> heap = new SortedSet<(int, int)>();
        Dictionary<int, Queue<int>> positions = new Dictionary<int, Queue<int>>();
        int counter = 0;

        for (int i = 0; i < Q; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int type = int.Parse(input[0]);

            if (type == 1)
            {
                int v = int.Parse(input[1]);
                heap.Add((v, counter));

                if (!positions.ContainsKey(v))
                    positions[v] = new Queue<int>();
                positions[v].Enqueue(counter);

                counter++;
            }
            else if (type == 2)
            {
                int v = int.Parse(input[1]);
                if (positions.ContainsKey(v) && positions[v].Count > 0)
                {
                    int id = positions[v].Dequeue();
                    heap.Remove((v, id));
                }
            }
            else if (type == 3)
            {
                Console.WriteLine(heap.Min.val);
            }
        }
    }
}
