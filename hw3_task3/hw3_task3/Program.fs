module Logic

    /// Exception to controle dividing by zero.
    exception DividingByZeroException of string

    /// This type support operations for integers : +,-,*,/    
    type Expression =
        | Number of int
        | Plus of Expression * Expression
        | Minus of Expression * Expression
        | Multiply of Expression * Expression
        | Divide of Expression * Expression
    
    /// A main fuction which parses the expression tree
    /// and returns the result of the calculation.
    let rec calculus expression = 
        match expression with 
        | Number n -> n
        | Plus(ex1, ex2) -> (calculus ex1) + (calculus ex2)
        | Minus(ex1, ex2) -> (calculus ex1) - (calculus ex2)
        | Multiply(ex1, ex2) -> (calculus ex1) * (calculus ex2)
        | Divide(ex1, ex2) -> if (ex2 = Number 0) 
                              then raise (DividingByZeroException("Dividing by zero!"))
                              else (calculus ex1) / (calculus ex2)