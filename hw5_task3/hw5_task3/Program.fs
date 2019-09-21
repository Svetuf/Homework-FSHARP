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
                Map.tryFindKey (fun key value -> value = phoneNumber) book
                
        /// Finding phone by given name, return "Nothing" if not found.
        member this.FindPhoneByName name (book: Map<string, string>) =
                Map.tryFind name book

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
                use fsIn = new FileStream("PhoneBook.dat", FileMode.Open)
                let res : Map<string, string> = readValue fsIn            
                fsIn.Close()
                res
            with
                | :? System.IO.FileNotFoundException -> printfn "Had not found file!";
                                                        Map.empty

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
        let input = Console.ReadLine()

        match input with
        | "1" -> Environment.Exit(0)
        | "2" -> printfn "Input name and phone"
                 let name = Console.ReadLine()
                 let number = Console.ReadLine()
                 loop (bookPhone.AddNote name number book)
        | "3" -> printfn "input name"
                 let name = Console.ReadLine()
                 let ans = bookPhone.FindPhoneByName name book
                 match ans with
                 | Some(x) -> Console.WriteLine(x)
                 | None -> Console.WriteLine("I found nothing")
                 loop book
        | "4" -> printfn "input phone"
                 let phone = Console.ReadLine()
                 let ans = bookPhone.FindNameByPhone phone book
                 match ans with
                 | Some(x) -> Console.WriteLine(x)
                 | None -> Console.WriteLine("I found nothing")
                 loop book
        | "5" -> bookPhone.PrintPhoneBook book
                 loop book
        | "6" -> bookPhone.Serealize book
                 loop book
        | "7" -> loop bookPhone.Deserealize
        | _ -> printfn "Tis command is not allowed, try again"
               loop book


                