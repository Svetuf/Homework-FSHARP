module Logic

    open System.Linq.Expressions
    open System.Runtime.Serialization.Formatters.Binary
    open System.IO
    open System
    
    /// A class of book.
    type phoneBook () = 

        /// Local book.
        let mutable localBook = Map.empty

        /// Book thah can be seen outside.
        member this.phoneBook = localBook

        /// Method that add a new note to book.
        member this.addNote name phone = 
            if this.phoneBook.ContainsKey name then
                localBook <- this.phoneBook.Remove (this.phoneBook.Item name)
                localBook <- this.phoneBook.Add (name, phone)
            else localBook <- this.phoneBook.Add (name, phone)

        /// Finding name by given phone, return "Nothing" if not found.
        member this.findNameByPhone phoneNumber =
            try
                Map.findKey (fun key value -> value = phoneNumber) this.phoneBook
            with
                | :? System.Collections.Generic.KeyNotFoundException as e -> "Nothing"
                
        /// Finding phone by given name, return "Nothing" if not found.
        member this.findPhoneByName name =
            try
                Map.find name this.phoneBook
            with
                | :? System.Collections.Generic.KeyNotFoundException as e -> "Nothing"

        /// Printing all the book.
        member this.printPhoneBook =
            for item in this.phoneBook do
                printfn "%A %A\n" item.Key item.Value

        /// Serializing.
        member this.serealize =
            let writeValue outputStream (x: 'a) =
                let formatter = new BinaryFormatter()
                formatter.Serialize(outputStream, box x)
            
            let fsOut = new FileStream("PhoneBook.dat", FileMode.Create)
            writeValue fsOut this.phoneBook
            fsOut.Close()
            printfn "Saved"
        
        /// Deserializing from Phonebook.dat.
        member this.deserealize =
            let readValue inputStream =
                let formatter = new BinaryFormatter()
                let res = formatter.Deserialize(inputStream)
                unbox res
            try
                let fsIn = new FileStream("PhoneBook.dat", FileMode.Open)
                let res : Map<string, string> = readValue fsIn            
                fsIn.Close()
                localBook <- res
                "Successfully loaded data!"
            with
                | :? System.IO.FileNotFoundException -> "Had not found file!"
           
        /// This method is for interactive.
        member this.ifiniteLoop =
            printf "Input the number of comand \n"
            let mutable inputNumber = Console.ReadLine()

            while true do
                match inputNumber with
                | "1" -> Environment.Exit(0)
                | "2" -> printfn "Input name and phone"
                         let name = Console.ReadLine()
                         let phone = Console.ReadLine()
                         this.addNote name phone
                         printfn "Added"
                | "3" -> printfn "Inpun name"
                         let name = Console.ReadLine()
                         printfn "I found %s" (this.findPhoneByName name)
                | "4" -> printfn "Inpun phone"
                         let phone = Console.ReadLine()
                         printfn "I found %s" (this.findNameByPhone phone)
                | "5" -> this.printPhoneBook
                | "6" -> this.serealize
                         printfn "PhoneBook saved"
                | "7" -> printfn "%s" this.deserealize
                | _ -> printfn "Unlnown command, try again"
                inputNumber <- Console.ReadLine()
                