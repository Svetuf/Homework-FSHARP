module Logic

    // Function that checking braket sequence in string 'input'.
    let checkBraket input = 

        // Lists of brakets(any type in any way).
        let openBrakets = [ '('; '['; '{' ]
        let closeBrakets = [ ')'; ']'; '}' ]
    
        // If 'braket' is a opening braket than return 0, if it closing braket then 1, if it's not a braket return -1.
        let isItBraket braket =
            match List.tryFindIndex (fun n -> n = braket) (List.concat [openBrakets; closeBrakets]) with
            | Some int -> int / 3
            | None -> -1

        // If it's a braket return it's position in braket list< else retuen -1.
        let braketType braket =
            match List.tryFindIndex (fun n -> n = braket) (List.concat [openBrakets; closeBrakets]) with
            | Some int -> int % 3
            | None -> -1

        // A calculation function.
        let rec loop (listOfBrakets: List<char>) listOfChars =
            match listOfChars with
            | [] -> if (listOfBrakets.Length = 0) then true
                    else false
            | head::tail -> 
                match isItBraket head with
                | x when x = 0 -> loop (List.concat [ listOfBrakets; [head] ]) tail
                | x when x = 1 -> if ((braketType head) = (braketType (List.last listOfBrakets))) then
                                      loop (listOfBrakets |> List.rev |> List.tail |> List.rev) tail
                                      else false
                | _ -> loop listOfBrakets tail
        let stackOfClosingBraket = []
        loop stackOfClosingBraket (Seq.toList input)

