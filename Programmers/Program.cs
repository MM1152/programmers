using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[,] clothes = { { 1, 0, 1, 1, 1 }, { 1, 0, 1, 0, 1 }, { 1, 0, 1, 1, 1 }, { 1, 1, 1, 0, 1 }, { 0, 0, 0, 0, 1 } };
        Console.WriteLine(solution.solution(clothes));

    }
}

public class Solution {
    public int solution(int[] topping) {
        int answer = 0;
        int[] cnt = new int[2];
        HashSet<int> list = new HashSet<int>();
        HashSet<int> list2 = new HashSet<int>();
        for(int i = 1; i < topping.Length; i++){
            for(int j = 0; j < i; j++){
                list.Add(topping[j]);
            }
            for(int k = i; k < topping.Length; i++){
                list2.Add(topping[k]);
            }
            if(list.Count == list2.Count){
                answer++;
            }
            list.Clear();
            list2.Clear();
        }
        return answer;
    }
}