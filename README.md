# ExpressionEvaluator

An Expression evaluator/parser using a chain data structure (linked list)

Example:
*2+3/4*2*

It will create this structure:

```

---------      ---------      ---------      ---------
|   2   |  --> |   3   | -->  |   4   |  --> |   2   |
|   +   |      |   /   |      |   *   |      |       |
---------      ---------      ---------      ---------
```

Also can use parenthesis, they will be evaluated making a substitution of their result on the raw string
