module Logic

    /// Main function
    let checkBraket input =
        /// Loop is recursive function, counter1 is '(' and ')' brackets,
        /// counter2 is '[' and ']' brackets, counter3 is '{' and '}' brackets.
        let rec loop listOfChars counter1 counter2 counter3 =
            match listOfChars with
            | [] -> if (counter1 = 0) && (counter2 = 0) && (counter3 = 0) then true
                    else false
            | head::tail -> if (counter1 < 0) || (counter2 < 0) || (counter3 < 0) then false
                            else match head with
                                 | '(' -> loop tail (counter1 + 1) counter2 counter3
                                 | ')' -> loop tail (counter1 - 1) counter2 counter3
                                 | '[' -> loop tail counter1 (counter2 + 1) counter3
                                 | ']' -> loop tail counter1 (counter2 - 1) counter3
                                 | '{' -> loop tail counter1 counter2 (counter3 + 1)
                                 | '}' -> loop tail counter1 counter2 (counter3 - 1)
                                 | _ -> loop tail counter1 counter2 counter3
        loop (Seq.toList input) 0 0 0