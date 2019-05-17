module Logic

    open System.Collections.Generic

    exception EmptyStack of string

    /// A type of stack, may be Empty or Stack.
    type Stack<'T> = 
        | Empty
        | Stack of 'T * Stack<'T>

        /// Bool value that true if stack is empty.
        member stack.isEmpty = 
            match stack with
            | Empty -> true
            | Stack(_,_) -> false

        /// Pushing element in stack.
        member stack.Push element =
            Stack(element, stack)
        
        /// Pop a top element of stack, return a new stack.
        member stack.Pop = 
            match stack with
            | Empty -> raise (EmptyStack("Stack is empty."))
            | Stack(x,tail) -> tail
        
        /// Return a top element of stack(returns a 'T type).
        member stack.Top =
            match stack with
            | Empty -> raise (EmptyStack("Stack is empty."))
            | Stack(x,tail) -> x