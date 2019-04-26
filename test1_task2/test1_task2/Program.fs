module Logic

    let rec reversedInt number partial =
         if number = 0 then partial
         else reversedInt (number / 10) (partial * 10 + (number % 10))

    let isPalindromeInt number =
        number = reversedInt number 0

    let biggestInt firstInt secondInt =
        if firstInt > secondInt then firstInt
        else secondInt

    let biggestPalindromeDotOfTwoNumbers n = 
        let rec biggestPalindromeFunction firstNumber secondNumberConst biggestPalindrome =
            let dotProduct = firstNumber * secondNumberConst
            match firstNumber with
            | x when x = 1000 -> biggestPalindrome
            | _ -> if isPalindromeInt dotProduct then biggestPalindromeFunction (firstNumber + 1) secondNumberConst (biggestInt dotProduct biggestPalindrome)
                    else biggestPalindromeFunction (firstNumber + 1) secondNumberConst biggestPalindrome

        let rec loop secondNumber biggestPalindrome =
            match secondNumber with
            | x when x = 100 -> biggestPalindrome
            | _ -> loop (secondNumber - 1) (biggestInt biggestPalindrome (biggestPalindromeFunction 100 secondNumber 0))
        loop 999 0

    let a = biggestPalindromeDotOfTwoNumbers 0