module logic

    /// return n if n is even number, 0 in other ways
    let isEven n =
        if(n % 2 = 0)
            then n
        else 0

    /// a main function
    let summOfEvenFibonacciNums =
        let rec loop upperbound firstNum secNum acc =
            if(secNum <= upperbound)
                then loop upperbound secNum (firstNum + secNum) (acc + (isEven secNum))
            else acc
        loop 1000000 1 1 0
    
    let res = summOfEvenFibonacciNums
         