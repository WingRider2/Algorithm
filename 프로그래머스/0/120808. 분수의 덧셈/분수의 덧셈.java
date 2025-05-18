class Solution {
    public int[] solution(int numer1, int denom1, int numer2, int denom2) {
        int mun1 = numer1*denom2+denom1*numer2;
        int mun2 = denom1*denom2;
        int gcd = GCD(mun1,mun2);
        int[] answer = {mun1/gcd,mun2/gcd};        
        return answer;
    }
    int GCD(int a, int b)
    {
    while(b != 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
    }
}