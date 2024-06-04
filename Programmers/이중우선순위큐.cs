using System;

public class main{
    public static void Main(string[] args){
        Solution solution = new Solution();
        string[] word = {"I 100", "I 90", "I 80", "D 1", "D 1", "I 95", "I 105", "D -1", "D -1"};
        Console.WriteLine( solution.solution(word)[0] + " " + solution.solution(word)[1]);
    }
}

public class Solution {
    public int[] solution(string[] operations) {
        int[] answer = new int[2];
        Heap minHeap = new Heap();
        Heap maxHeap = new Heap();

        foreach(var a in operations){
            string[] word = a.Split(" ");
            if(word[0].Equals("I")){
                minHeap.add(int.Parse(word[1]));
                maxHeap.add(-int.Parse(word[1]));
            }
            else if(word[0].Equals("D")){
                if(word[1].Equals("-1") && minHeap.getHeap().Count > 1){
                    minHeap.remove();
                }else if(word[1].Equals("1") && maxHeap.getHeap().Count > 1){
                    maxHeap.remove();
                }
            }
        }
        answer[0] = -maxHeap.getHeap()[0];
        answer[1] = minHeap.getHeap()[1];
        return answer;
    }
}

    public class Heap{
        List<int> heap = new List<int>();
        public Heap(){
            heap.Add(0);
        }

        public void add(int value){
            heap.Add(value);
            sort();
        }
        public void sort(){
            int point = heap.Count - 1;
            while(point / 2 != 0){
                int parent = point / 2;
                if(heap[parent] > heap[point]){
                    Swap(parent , point);
                }
                else {
                    break;
                }
                point = parent;
            }
        }
        public void remove(){
            int point = heap.Count - 1;
            heap[1] = heap[point];
            heap.RemoveAt(point);
            point = 1;
            while(point < heap.Count){
                int left = point * 2;
                int right = point * 2 + 1;
                int next = point;
                if(left < heap.Count && heap[left] < heap[point]) next = left;
                if(right < heap.Count && heap[right] < heap[point]) next = right;
                
                if(next == point){
                    break;
                }
                
                Swap(point , next);
            }
        }
        public void Swap(int parent , int swapPoint){
            int temp = heap[parent];
            heap[parent] = heap[swapPoint];
            heap[swapPoint] = temp;
        }
        public List<int> getHeap(){
            return heap;
        }
    }
