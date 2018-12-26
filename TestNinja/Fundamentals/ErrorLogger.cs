
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 
        
        public void Log(string error)
        {
            // Null
            // Empty String
            // String that has white space

            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error; 
            
            // Write the log to a storage
            // ...

            // After storage, this ErrorLogged event is raised. 
            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }
    }
}