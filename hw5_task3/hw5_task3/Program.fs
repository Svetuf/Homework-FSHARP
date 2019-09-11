module Logic
    open System.Collections

    let checkBraket input =
         let rec loop (stack: Stack) listOfChars =
             match listOfChars with
             | [] -> if(stack.Count = 0) then true
                     else false
             | head::tail -> 
                 match head with
                 | '(' -> stack.Push('(')
                          loop stack tail
                 | ')' -> if(stack.Peek().ToString() = "(") then
                             stack.Pop() |> ignore
                             loop stack tail
                          else false
                             
                 | '[' -> stack.Push('[')
                          loop stack tail
                 | ']' -> if(stack.Peek().ToString() = "[") then
                             stack.Pop() |> ignore
                             loop stack tail
                          else false
                 | '{' -> stack.Push('{')
                          loop stack tail
                 | '}' -> if(stack.Peek().ToString() = "{") then
                             stack.Pop() |> ignore
                             loop stack tail
                          else false
                 | _ -> loop stack tail
         let stack1 = new Stack()
         loop (stack1) (Seq.toList input)