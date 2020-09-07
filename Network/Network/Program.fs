module Logic

    open System
    open MathNet.Numerics.LinearAlgebra

    // Operating system type. Сontains the OS name and the probability of infection for this OS.
    type OS = {name: string; probability: float} with
        static member Create name prob = {name = name; probability = prob}

    // Class of computer. Contains the OS type and the infection flag.
    type Comp(os: OS, infected:bool)=
        let Os = os
        let mutable infected = infected

        // Variable for generating random variables.
        static member Rnd = new Random()
        
        // Discrete time step. Determines whether this computer will be infected after this step.
        member this.Tick =
            match infected with
                | true -> true
                | false -> (Comp.Rnd.NextDouble() <= Os.probability)
        
        // Function to infect this computer.
        member this.Infect =
            infected <- true

        // Infected status.
        member this.Status =
            infected

    // Network description class. Contains a list of all computers and an adjacency matrix.
    type Network(computers: list<Comp>, matrix: Matrix<double>)=
        let matrix = matrix
        let computers = computers

        // Discrete time step. Makes calculations to infect computers.
        // At the end of the step, the infect() method is called for all infected computers.
        member this.Tick =
            let mutable infectedOnThisTurn = []
            for i in 0 .. computers.Length - 1 do
                if computers.Item(i).Status then 
                    for j in 0 .. matrix.ColumnCount - 1 do
                        if matrix.Item(i, j) > 0.0 then
                            if (computers.Item j).Tick then infectedOnThisTurn <- computers.Item(j)::infectedOnThisTurn
            List.iter (fun (comp:Comp) -> comp.Infect) infectedOnThisTurn

        // Current infection status of network.
        member this.Status =
            List.map (fun (comp:Comp)  -> comp.Status) computers
