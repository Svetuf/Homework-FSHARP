module Logic

    // Function that checking bracket sequence in string 'input'.
    let checkBracket input = 

        let brackets =  Map.empty. 
                            Add('(', ')').
                            Add('[', ']').
                            Add('{', '}');

        // A calculation function.
        let rec loop (listOfBrackets: List<char>) listOfChars =
            match listOfChars with
            | [] -> (listOfBrackets.Length = 0)
            | head::tail -> 
                match brackets.ContainsKey head with
                | true -> loop (head :: listOfBrackets) tail
                | false -> if (Map.exists (fun a b -> b = head) brackets) then
                              if (Map.exists (fun a b -> a = listOfBrackets.Head &&  b = head) brackets) then
                                loop (listOfBrackets.Tail) tail
                              else false
                           else loop listOfBrackets tail
        let stackOfClosingBracket = []
        loop stackOfClosingBracket (Seq.toList input)

