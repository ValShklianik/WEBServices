using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;

namespace FibonacciLambda
{
    public class Function
    {
        class InputValue
        {
            public long input {get; set;}
        } 

        class ResultValue
        {
            public List<long> result {get; set;}
        } 

        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public List<long> Handler(InputValue input)
        {
            var list = new List<long>();
            list.Add(1);
            list.Add(2);
            return new ResultValue()
            {
                result = list;
            };
        }
    }
}
