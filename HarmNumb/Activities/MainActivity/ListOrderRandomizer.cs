using System.Collections.Generic;
using System;
using System.Linq;

public static class RandomizeListOrderExtention
{
    public static List<T> RandomizeOrder<T>(this List<T> target)
    {
        Random r = new Random();

        return new List<T>(target.OrderBy(x=>(r.Next())));
    }        
}