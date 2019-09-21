module Logic

    open System.Runtime.Serialization.Formatters.Binary
    open System.IO
    open System
    
    /// A class of book.
    type PhoneBook () = 

        /// Method that add a new note to book.
        member this.AddNote name phone (book: Map<string, string>) = 
            if book.ContainsKey name then
                (book.Remove (book.Item name)).Add (name, phone)
            else book.Add (name, phone)

        /// Finding name by given phone, return "Nothing" if not found.
        member this.FindNameByPhone phoneNumber (book: Map<string, string>) =
            try
                Map.findKey (fun key value -> value = phoneNumber) book
            with
                | :? System.Collections.Generic.KeyNotFoundException as e -> "Nothing"
                
        /// Finding phone by given name, return "Nothing" if not found.
        member this.FindPhoneByName name (book: Map<string, string>) =
            try
                Map.find name book
            with
                | :? System.Collections.Generic.KeyNotFoundException as e -> "Nothing"

        /// Printing all the book.
        member this.PrintPhoneBook (book: Map<string, string>) =
            for item in book do
                printfn "%A %A\n" item.Key item.Value

        /// Serializing.
        member this.Serealize (book: Map<string, string>) =
            let writeValue outputStream (x: 'a) =
                let formatter = new BinaryFormatter()
                formatter.Serialize(outputStream, box x)
            
            use fsOut = new FileStream("PhoneBook.dat", FileMode.Create)
            writeValue fsOut book
            fsOut.Close()
            printfn "Saved"
        
        /// Deserializing from Phonebook.dat.
        member this.Deserealize =
            let readValue inputStream =
                let formatter = new BinaryFormatter()
                let res = formatter.Deserialize(inputStream)
                unbox res
            try
                let fsIn = new FileStream("PhoneBook.dat", FileMode.Open)
                let res : Map<string, string> = readValue fsIn            
                fsIn.Close()
                res
            with
                | :? System.IO.FileNotFoundException -> printfn "Had not found file!"; Map.empty

    // a way to use the book
    let rec loop (book: Map<string, string>) =
        printfn "input 1 to exit"
        printfn "input 2 to add new contact"
        printfn "input 3 to search number"
        printfn "input 4 to search name"
        printfn "input 5 to see all contacts"
        printfn "input 6 to save book"
        printfn "input 7 to load book"

        let bookPhone = PhoneBook()
        let mutable locBook = book
        let input = Console.ReadLine()

        match input with
        | "1" -> Environment.Exit(0)
        | "2" -> printfn "Input name and phone"
                 let name = Console.ReadLine()
                 let number = Console.ReadLine()
                 locBook <- bookPhone.AddNote name number book
                 loop locBook
        | "3" -> printfn "input name"
                 let name = Console.ReadLine()
                 let ans = bookPhone.FindPhoneByName name locBook
                 Console.WriteLine(ans)
                 loop locBook
        | "4" -> printfn "input phone"
                 let phone = Console.ReadLine()
                 let ans = bookPhone.FindNameByPhone phone locBook
                 Console.WriteLine(ans)
                 loop locBook
        | "5" -> bookPhone.PrintPhoneBook locBook
                 loop locBook
        | "6" -> bookPhone.Serealize locBook
                 loop locBook
        | "7" -> locBook <- bookPhone.Deserealize
                 loop locBook
        | _ -> printfn "Tis command is not allowed, try again"
               loop locBook


                