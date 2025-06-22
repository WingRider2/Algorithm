using System;
using System.Text;
using System.Linq;


public class Solution {
    public int solution(int i, int j, int k) {
        StringBuilder sb = new StringBuilder();
        for (int q = i; q <= j; q++) sb.Append(q.ToString());          
        return sb.ToString().Count(c => c == k+'0');
    }
}