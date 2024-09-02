

import java.util.List;
import java.util.Stack;
import java.util.stream.Collectors;

public class DSAStack {

    Object[] stackArray;
    int count =0;
    int defCapacity = 1;

//    DSAStack dsaStack = new DSAStack();

   static Stack<Integer> stack = new Stack<>();

    public DSAStack()
    {
        stackArray = new Object[defCapacity];
        count =0;
    }

    public DSAStack(int maxElements)

    {
        stackArray = new Object[maxElements];
        count =0;
    }

    public int getCount()
    {
        return count;
    }

    public boolean isEmpty()
    {
        if(getCount() ==0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public boolean isFull()
    {
        if(getCount() == stackArray.length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void push(String value)
    {
        if(isFull() ==true)
        {
            System.out.println("Error! Stack contains maximum amount of values it can contain ");

        }
        else
        {
            stackArray[getCount()] = value;
            count =count +1;
        }
    }

    public Object pop()
    {
        count = (count-1);
        stackArray[count] =  null;

        return top();

    }

    public void popAll(int val)
    {

        for(int ii=0; ii< val; ii++)
        {
            count = (count-1);
            stackArray[count] =  null;
        }

    }

    public Object top()
    {    Object topVal = 0;

        if (isEmpty() ==true)
        {
            System.out.println("Error! Stack is Empty");
        }
        else
        {

            topVal = stackArray[count -1] ;
            // System.out.println("top value is : " + topVal);
        }
        return topVal;

    }

    public void printVal()
    {
        for(int i = 0 ; i<(stackArray.length) ; i++)
        {
            System.out.print(stackArray[i] + " ");
        }
    }

    public static void main(String[] args) {
        int num = 5;

        final DSAStack dsaStack = new DSAStack();

        System.out.println(dsaStack.findFactorial(num, 1, 1));

        final List<Integer> collect = stack.stream().collect(Collectors.toList());
        System.out.println(collect);

    }

    int findFactorial(int num, int count, int fact) {

        if (count <= num){
            fact *= count;
            System.out.println(fact);
            stack.push(fact);
           return findFactorial(num, ++count, fact);
        }else {
            return fact;
        }

    }
}

