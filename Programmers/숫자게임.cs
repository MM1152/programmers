namespace 숫자게임
{   
    //A : 1122 , B : 1112 의 경우를 생각하니까 쉽게 품 
    public class Solution
    {

        public int solution(int[] A, int[] B)
        {
            int answer = 0;
            int index = 0;
            int index1 = 0;
            Array.Sort(A);
            Array.Sort(B);

            while (index1 < B.Length)
            {
                if (A[index] < B[index1])
                {
                    answer++;
                    index++;
                    index1++;
                }
                else if (A[index] >= B[index1])
                {
                    index1++;
                }
            }
            return answer;
        }
    }
}