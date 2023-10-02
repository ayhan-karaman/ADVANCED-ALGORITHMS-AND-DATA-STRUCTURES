using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Stacks;

namespace Apps
{
    public class PostFixExample
    {
        private string expression;
        LinkedListStack<string> stack = new LinkedListStack<string>();
        public static string Run(string expression)
        {
            PostFixExample e = new PostFixExample();
            e.expression = expression;
            return e.Expression();
        }

        private string Expression()
        {
            int val1, val2, ans;
            
            for (int i = 0; i < expression.Length; i++)
            {
                string chr = expression.Substring(i, 1);
              
                if(chr.Equals("*"))
                {
                    val1 = int.Parse(stack.Pop());
                    val2 = int.Parse(stack.Pop());
                    ans = val2 * val1;
                    stack.Push(ans.ToString());
                }
                else if(chr.Equals("/"))
                {
                    val1 = int.Parse(stack.Pop());
                    val2 = int.Parse(stack.Pop());
                    ans = val2 / val1;
                    stack.Push(ans.ToString());
                }
                else if(chr.Equals("+"))
                {
                    val1 = int.Parse(stack.Pop());
                    val2 = int.Parse(stack.Pop());
                    ans = val2 + val1;
                    stack.Push(ans.ToString());
                }
                else if(chr.Equals("-"))
                {
                    val1 = int.Parse(stack.Pop());
                    val2 = int.Parse(stack.Pop());
                    ans = val2 - val1;
                    stack.Push(ans.ToString());
                }
                else
                {
                     stack.Push(chr);
                }

            }
            return stack.Pop();
        }
    }
}