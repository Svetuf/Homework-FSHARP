module LazyFactory  
     
    open Logic

    /// Factory to create different Lazy realizations.
    type LazyFactory() =

        /// Returns single thread Lazy class with supplier.
        static member CreateSingleThread supplier = SingleThread<'a>(supplier)

        /// Returns multi thread Lazy class with supplier.
        static member CreateMultiThread supplier = MultiThread<'a>(supplier)

        /// Returns multi thread(lock-free) Lazy class with supplier.
        static member CreateMultiThreadNoLock supplier = MultiThreadNoLock<'a>(supplier)



    
