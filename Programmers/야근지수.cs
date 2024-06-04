using System.Collections.Generic;
using System;
namespace other
{

    public class main
    {
        public static void Main(String[] args)
        {
            Solution solution = new Solution();
            long a = solution.solution(3,[1,1]);
            Console.WriteLine(a);
        }

    }
    //일단 최대로 작은수를 만든다.
    public class Solution
    {
        public long solution(int n, int[] works)
        {
            long answer = 0;
            Que maxQueue = new Que();
            for (int i = 0; i < works.Length; i++)
            {
                maxQueue.addValue(works[i]);
            }

            for (int i = 0; i < n; i++)
            {
                maxQueue.minus();
            }

            foreach (var a in maxQueue.list)
            {
                answer += a * a;
            }

            return answer;
        }

    }
    public class Que
    {
        public List<int> list = new List<int>();
        public void addValue(int value)
        {
            list.Add(value);
            Sort();
        }
        public void Sort()
        {
            int point = list.Count - 1;
            while (point != 0)
            {
                int parent = (point - 1) / 2;

                if (list[parent] < list[point])
                {
                    Swap(parent, point);
                }

                point = parent;
            }
        }
        public void minus()
        {
            list[0]--;
            if(list[0] == -1){
                list[0]++;
                return;
            }

            
            int point = 0;

            while (point < list.Count)
            {
                int left = point * 2 + 1;
                int right = point * 2 + 2;
                int next = point;

                if (left < list.Count && list[point] < list[left]) next = left;
                if (right < list.Count && list[point] < list[right]) next = right;

                if (next == point)
                {
                    break;
                }
                Swap(point, next);
                point = next;
            }
        }
        public void Swap(int parent, int child)
        {
            int temp = list[parent];
            list[parent] = list[child];
            list[child] = temp;
        }
    }
}
