namespace 단어변환
{
    public class Solution
    {
        public int solution(string begin, string target, string[] words)
        {
            int answer = 0;
            bool notCorrect = true;
            
            foreach(var word in words){
                if(word == target){
                    notCorrect = false;
                }
            }

            if(notCorrect){
                return 0;
            }
            // "hit , cog", "log", "lot", "dog", "dot", "hot"
            // words[0]
            int[] answers = new int[words.GetLength(0) + 1];
            answers[0] = 1;
            // true  
            // "hit , cog", "log", "lot", "dog", "dot", "hot"
            bool[] visit = new bool[words.GetLength(0) + 1];
            Queue<string> strings = new Queue<string>();
            Queue<int> ints = new Queue<int>();

            strings.Enqueue(begin);
            ints.Enqueue(0);

            

            while(strings.Count > 0){
                
                string targetString = strings.Dequeue();
                Console.Write($" (targetString : {targetString})  ");
                if(targetString.Equals(target)) break;

                int index = ints.Dequeue();
                //if(visit[index]) continue;
                
                //visit[index] = true;

                for(int i = 0 ; i < words.GetLength(0); i++){
                    if(visit[i + 1]) continue;
                    int count = 0;
                    for(int j = 0; j < words[i].Length; j++){
                        if(words[i][j] != targetString[j]){
                            count--;
                        }
                    }
                    if(count == -1){
                        if(answers[i + 1] == 0){
                            answers[i + 1] = answers[index] + 1;
                        }
                        visit[i + 1] = true;
                        strings.Enqueue(words[i]);
                        ints.Enqueue(i + 1);
                        
                    }
                }
                Console.Write("Queue 내부 : ");
                foreach(var a in strings){
                    Console.Write($"{a} ");
                }
                Console.WriteLine();

                
            }
            Console.WriteLine();
            foreach(var a in answers){
                Console.Write($"{a} ");
            }
            answer = answers[Array.IndexOf(words , target) + 1] - 1;
            Console.WriteLine();
            return answer;
        }
    }
}